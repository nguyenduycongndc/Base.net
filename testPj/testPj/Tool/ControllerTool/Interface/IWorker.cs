using System.Threading;
using System.Threading.Tasks;

namespace testPj.Tool.ControllerTool
{
    public interface IWorker
    {
        Task DoWork(CancellationToken cancellationToken);
    }
}