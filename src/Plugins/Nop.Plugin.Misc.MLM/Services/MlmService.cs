using Nop.Data;
using Nop.Plugin.Misc.MLM.Model;
using Nop.Services.Logging;

namespace Nop.Plugin.Misc.MLM.Services;

public class MlmService : IMlmService
{
    protected readonly IRepository<MlmModel> _mlmRepository;
    protected readonly ILogger _logger;

    public MlmService(IRepository<MlmModel> mlmRepository, ILogger logger)
    {
        _mlmRepository = mlmRepository;
        _logger = logger;
    }

    public Task AddMlmRelationship(MlmModel mlm)
    {
        try
        {
            _mlmRepository.Insert(mlm);

            return Task.CompletedTask;
        }
        catch (Exception ex) 
        {
            _logger.InsertLog(Core.Domain.Logging.LogLevel.Error, $"Error happen at Nop.Plugin.Misc.MLM.Services.Service,  AddMlmRelationship({mlm.Id}, {mlm.ParentId}, {mlm.ParentName}, {mlm.CustomerId}, {mlm.CustomerName}, {mlm.CreatedDateTimeUTC}):" + ex.Message);

            return Task.FromException(ex);
        }
    }
}
