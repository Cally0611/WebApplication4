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

        public int ExecutionCount
        {
            get
            {
                return executionCount;
            }
            set
            {
                executionCount = value;
            }
        }
  
        public Task StartAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service running.");

            _timer = new Timer(DoWork, null, TimeSpan.FromSeconds(1),
                TimeSpan.FromSeconds(1));

            return Task.CompletedTask;
        }

        private void DoWork(object? state)
        {
            //var count = Interlocked.Increment(ref executionCount);

            executionCount = Interlocked.Increment(ref executionCount);

            using (IServiceScope scope = _serviceProvider.CreateScope())
            {
                DBOperationService _contextservice = scope.ServiceProvider.GetRequiredService<DBOperationService>();
    
                _contextservice.GetOEEbyShift();
              
            }
            _logger.LogInformation(
                "Timed Hosted Service is working. {currentdate} Count: {Count}", DateTime.Now.ToString(), executionCount);
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
