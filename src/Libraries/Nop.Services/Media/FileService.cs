using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Nop.Core;
using Nop.Core.Domain.Media;
using Nop.Core.Infrastructure;
using Nop.Data;
using Nop.Services.Logging;


namespace Nop.Services.Media;

/// <summary>
/// File service
/// </summary>
public partial class FileService : IFileService
{
    #region Fields

    protected readonly ILogger _logger;
    protected readonly INopFileProvider _fileProvider;
    protected readonly IDownloadService _downloadService;
    protected readonly IRepository<ProductFile> _productFileRepository;
    protected readonly IRepository<FileBinary> _fileBinaryRepository;
    private readonly IWebHelper _webHelper;
    private readonly IWebHostEnvironment _env;

    #endregion


    #region Ctor

    public FileService(ILogger logger, INopFileProvider fileProvider, IDownloadService downloadService, IRepository<ProductFile> productFileRepository, IRepository<FileBinary> fileBinaryRepository, IWebHelper webHelper, IWebHostEnvironment env)
    {
        _logger = logger;
        _fileProvider = fileProvider;
        _downloadService = downloadService;
        _productFileRepository = productFileRepository;
        _fileBinaryRepository = fileBinaryRepository;
        _webHelper = webHelper;
        _env = env;
    }

    #endregion


    #region Utilities

    /// <summary>
    /// Inserts a picture
    /// </summary>
    /// <param name="fileBinary">The file binary</param>
    /// <param name="mimeType">The picture MIME type</param>
    /// <param name="seoFilename">The SEO filename</param>
    /// <param name="altAttribute">"alt" attribute for "img" HTML element</param>
    /// <param name="titleAttribute">"title" attribute for "img" HTML element</param>
    /// <param name="isNew">A value indicating whether the picture is new</param>
    /// <param name="validateBinary">A value indicating whether to validated provided picture binary</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the picture
    /// </returns>
    public virtual async Task<ProductFile> InsertFileAsync(int productId, byte[] fileBinary, string mimeType, string seoFilename,
        string altAttribute = null, string titleAttribute = null,
        bool isNew = true, bool validateBinary = true)
    {
        mimeType = CommonHelper.EnsureNotNull(mimeType);
        mimeType = CommonHelper.EnsureMaximumLength(mimeType, 20);

        seoFilename = CommonHelper.EnsureMaximumLength(seoFilename, 100);

        var productFile = new ProductFile
        {
            ProductId = productId,
            MimeType = mimeType,
            SeoFilename = seoFilename,
            AltAttribute = altAttribute,
            TitleAttribute = titleAttribute,
            CreatedDateTimeUTC = DateTime.UtcNow,
            IsNew = isNew,
            IsDeleted = false,
            UpdatedDateTimeUTC = DateTime.UtcNow
        };

        
        await _productFileRepository.InsertAsync(productFile);
        await UpdateFileBinaryAsync(productFile, fileBinary);
        var virtualPath = await SaveFileInFileAsync(productFile.Id, fileBinary, mimeType);
        var fileUrl = GetFileUrl(virtualPath);
        productFile.VirtualPath = fileUrl;

        return productFile;
    }


    /// <summary>
    /// Inserts a file
    /// </summary>
    /// <param name="productId">Product identifier file</param>
    /// <param name="formFile">Form file</param>
    /// <param name="defaultFileName">File name which will be use if IFormFile.FileName not present</param>
    /// <param name="virtualPath">Virtual path</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the file
    /// </returns>
    public virtual async Task<ProductFile> InsertFileAsync(int productId, IFormFile formFile, string defaultFileName = "", string virtualPath = "")
    {
        var fileExt = new List<string>
        {
            ".pdf",
            ".docx",
            ".doc"
        } as IReadOnlyCollection<string>;

        var fileName = formFile.FileName;
        if (string.IsNullOrEmpty(fileName) && !string.IsNullOrEmpty(defaultFileName))
            fileName = defaultFileName;

        //remove path (passed in IE)
        fileName = _fileProvider.GetFileName(fileName);

        var contentType = formFile.ContentType;

        var fileExtension = _fileProvider.GetFileExtension(fileName);
        if (!string.IsNullOrEmpty(fileExtension))
            fileExtension = fileExtension.ToLowerInvariant();

        if (fileExt.All(ext => !ext.Equals(fileExtension, StringComparison.CurrentCultureIgnoreCase)))
            return null;

        //contentType is not always available 
        //that's why we manually update it here
        //https://mimetype.io/all-types/
        if (string.IsNullOrEmpty(contentType))
            contentType = GetFileContentTypeByFileExtension(fileExtension);


        var productFile = await InsertFileAsync(productId, await _downloadService.GetDownloadBitsAsync(formFile),
            contentType,
            _fileProvider.GetFileNameWithoutExtension(fileName));


        if (string.IsNullOrEmpty(productFile.VirtualPath))
            return productFile;

        //productFile.VirtualPath = _fileProvider.GetVirtualPath(productFile.VirtualPath);

        await UpdateFileAsync(productFile);

        return productFile;
    }


    /// <summary>
    /// Updates the product file
    /// </summary>
    /// <param name="productFile">The file to update</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the file
    /// </returns>
    protected virtual async Task<ProductFile> UpdateFileAsync(ProductFile productFile)
    {
        if (productFile == null)
            return null;

        productFile.UpdatedDateTimeUTC = DateTime.UtcNow;
        await _productFileRepository.UpdateAsync(productFile);

        return productFile;
    }


    /// <summary>
    /// Updates the file binary data
    /// </summary>
    /// <param name="productFile">The file object</param>
    /// <param name="binaryData">The file binary data</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the file binary
    /// </returns>
    protected virtual async Task<FileBinary> UpdateFileBinaryAsync(ProductFile productFile, byte[] binaryData)
    {
        ArgumentNullException.ThrowIfNull(productFile);

        var fileBinary = await GetFileBinaryByFileIdAsync(productFile.Id);

        var isNew = fileBinary == null;

        if (isNew)
            fileBinary = new FileBinary
            {
                FileId = productFile.Id
            };

        fileBinary.BinaryData = binaryData;

        if (isNew)
            await _fileBinaryRepository.InsertAsync(fileBinary);
        else
            await _fileBinaryRepository.UpdateAsync(fileBinary);

        return fileBinary;
    }


    /// <summary>
    /// Get product file binary by file identifier
    /// </summary>
    /// <param name="fileId">The file identifier</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the file binary
    /// </returns>
    public virtual async Task<FileBinary> GetFileBinaryByFileIdAsync(int fileId)
    {
        return await _fileBinaryRepository.Table
            .FirstOrDefaultAsync(pb => pb.FileId == fileId);
    }


    /// <summary>
    /// Save file on file system
    /// </summary>
    /// <param name="fileId">File identifier</param>
    /// <param name="fileBinary">File binary</param>
    /// <param name="mimeType">MIME type</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    protected virtual async Task<string> SaveFileInFileAsync(int fileId, byte[] fileBinary, string mimeType)
    {
        var lastPart = await GetFileExtensionFromMimeTypeAsync(mimeType);
        var fileName = $"{fileId:0000000}_0.{lastPart}";
        var filePath = await GetFileLocalPathAsync(fileName);

        // Ensure folder exists
        var directory = Path.GetDirectoryName(filePath);
        if (!System.IO.Directory.Exists(directory))
        {
            System.IO.Directory.CreateDirectory(directory);
        }

        // Save file
        await _fileProvider.WriteAllBytesAsync(filePath, fileBinary);

        // Return file path
        return filePath;
    }


    /// <summary>
    /// Returns the file extension from mime type.
    /// </summary>
    /// <param name="mimeType">Mime type</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the file extension
    /// </returns>
    public virtual Task<string> GetFileExtensionFromMimeTypeAsync(string mimeType)
    {
        if (mimeType == null)
            return Task.FromResult<string>(null);

        var parts = mimeType.Split('/');
        var lastPart = parts[^1];
        lastPart = lastPart switch
        {
            "pdf" => "pdf",
            "docx" => "docx",
            "doc" => "doc",
            _ => "",
        };
        return Task.FromResult(lastPart);
    }


    /// <summary>
    /// Get file local path. Used when file stored on file system (not in the database)
    /// </summary>
    /// <param name="fileName">Filename</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the local file path
    /// </returns>
    protected virtual Task<string> GetFileLocalPathAsync(string fileName)
    {
        return Task.FromResult(_fileProvider.GetAbsolutePath("file", fileName));
    }


    /// <summary>
    /// Get content type for file by file extension
    /// </summary>
    /// <param name="fileExtension">The file extension</param>
    /// <returns>File's content type</returns>
    protected string GetFileContentTypeByFileExtension(string fileExtension)
    {
        string contentType = null;

        switch (fileExtension.ToLower())
        {
            case ".pdf":
            case ".docx":
            case ".doc":
            default:
                break;
        }

        return contentType;
    }


    /// <summary>
    /// Soft delete file
    /// </summary>
    /// <param name="id">File identifier</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    public virtual async Task DeleteFileAsync(int id)
    {
        ArgumentNullException.ThrowIfNull(id);

        var productFile = await _productFileRepository.Table
            .FirstOrDefaultAsync(pf => pf.Id == id);

        productFile.IsDeleted = true;
        productFile.UpdatedDateTimeUTC = DateTime.UtcNow;

        await _productFileRepository.UpdateAsync(productFile);
    }


    /// <summary>
    /// Gets a file
    /// </summary>
    /// <param name="fileId">File identifier</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the file
    /// </returns>
    public virtual async Task<ProductFile> GetFileByIdAsync(int fileId)
    {
        return await _productFileRepository.GetByIdAsync(fileId, cache => default);
    }


    /// <summary>
    /// Convert file virtual path to url
    /// </summary>
    /// <param name="filePath">File virtual path</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the file url
    /// </returns>
    protected string GetFileUrl(string filePath)
    {
        // strip the physical wwwroot path
        var relativePath = filePath
            .Replace(_env.WebRootPath, "")
            .Replace("\\", "/");

        if (!relativePath.StartsWith("/"))
            relativePath = "/" + relativePath;

        // build full url from store base url
        return $"{_webHelper.GetStoreLocation().TrimEnd('/')}{relativePath}";
    }


    /// <summary>
    /// Gets a file
    /// </summary>
    /// <param name="productId">Product identifier</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the file
    /// </returns>
    public virtual async Task<ProductFile> GetFileByProductIdAsync(int productId)
    {
        return await _productFileRepository.Table.FirstOrDefaultAsync(pf => pf.ProductId == productId);
    }

    #endregion
}
