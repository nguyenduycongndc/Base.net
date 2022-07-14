using System.Threading;
using System.Threading.Tasks;

namespace ToolMM.Tool.ControllerTool
{
    public interface IWorker
    {
        Task DoWork(CancellationToken cancellationToken);
    }
}