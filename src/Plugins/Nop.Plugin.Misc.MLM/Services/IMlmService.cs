using Nop.Plugin.Misc.MLM.Model;

namespace Nop.Plugin.Misc.MLM.Services;

public interface IMlmService
{
    Task AddMlmRelationship(MlmModel mlm);
}
