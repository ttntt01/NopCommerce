using Microsoft.AspNetCore.Http;
using Nop.Core.Domain.Media;

namespace Nop.Services.Media;

/// <summary>
/// File service interface
/// </summary>
public partial interface IFileService
{
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
    Task<ProductFile> InsertFileAsync(int productId, byte[] fileBinary, string mimeType, string seoFilename,
        string altAttribute = null, string titleAttribute = null,
        bool isNew = true, bool validateBinary = true);

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
    Task<ProductFile> InsertFileAsync(int productId, IFormFile formFile, string defaultFileName = "", string virtualPath = "");

    /// <summary>
    /// Get product file binary by file identifier
    /// </summary>
    /// <param name="fileId">The file identifier</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the file binary
    /// </returns>
    Task<FileBinary> GetFileBinaryByFileIdAsync(int fileId);

    /// <summary>
    /// Soft delete file
    /// </summary>
    /// <param name="id">File identifier</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    Task DeleteFileAsync(int id);

    /// <summary>
    /// Gets a file
    /// </summary>
    /// <param name="fileId">File identifier</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the file
    /// </returns>
    Task<ProductFile> GetFileByIdAsync(int fileId);
}
