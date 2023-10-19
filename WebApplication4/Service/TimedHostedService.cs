using Microsoft.AspNetCore.Identity;
using WebApplication4.Data;

namespace WebApplication4.Service
{
    public class TimedHostedService : IHostedService, IDisposable
    {
        private int executionCount = 0;
        private readonly ILogger<TimedHostedService> _logger;
        private Timer _timer = null!;
        
        private readonly IServiceProvider _serviceProvider;
        public TimedHostedService(ILogger<TimedHostedService> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
            
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service running.");

            _timer = new Timer(DoWork, null, TimeSpan.FromSeconds(10),
                TimeSpan.FromSeconds(10));

            return Task.CompletedTask;
        }

        private void DoWork(object? state)
        {
            var count = Interlocked.Increment(ref executionCount);

            using (IServiceScope scope = _serviceProvider.CreateScope())
            {
                DBOperationService _contextservice = scope.ServiceProvider.GetRequiredService<DBOperationService>();
    
                _contextservice.GetOEEStopReasons();
              
            }
            _logger.LogInformation(
                "Timed Hosted Service is working. {currentdate} Count: {Count}", DateTime.Now.ToString(), count);
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
