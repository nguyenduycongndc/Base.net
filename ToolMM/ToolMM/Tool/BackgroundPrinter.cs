using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ToolMM.Tool.ControllerTool;

namespace ToolMM.Tool
{
    public class BackgroundPrinter : IHostedService
    {
        private readonly ILogger<BackgroundPrinter> _logger;
        private readonly IWorker _worker;
        private int number = 0;
        private Timer timer;
        public BackgroundPrinter(ILogger<BackgroundPrinter> logger, IWorker worker)
        {
            _logger = logger;
            _worker = worker;
        }

        public void Dispose()
        {
            timer?.Dispose();
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await _worker.DoWork(cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("stop");
            return Task.CompletedTask;
        }
    }
}
