
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ToolMM.Tool.ControllerTool;

namespace ToolMM.Tool
{
    public class DerivedBackgroundPrinter : BackgroundService
    {
        private readonly IWorker _worker;
        public DerivedBackgroundPrinter(IWorker worker)
        {
            _worker = worker;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _worker.DoWork(stoppingToken);
        }
    }
}
