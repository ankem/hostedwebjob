namespace WebAPI
{
    public class MyCronJob4 : CronJobService
    {
        private readonly ILogger<MyCronJob3> _logger;
        private readonly MetricReporter _metricReporter;

        public MyCronJob4(IScheduleConfig<MyCronJob3> config, ILogger<MyCronJob3> logger, MetricReporter metricReporter)
            : base(config.CronExpression, config.TimeZoneInfo)
        {
            _logger = logger;
            _metricReporter = metricReporter;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("CronJob 4 starts.");
            return base.StartAsync(cancellationToken);
        }

        public override Task DoWork(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{DateTime.Now:hh:mm:ss} CronJob 4 is working.");
            _metricReporter.RegisterRequest();
            return Task.CompletedTask;
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("CronJob 4 is stopping.");
            return base.StopAsync(cancellationToken);
        }
    }
}
