using Microsoft.Extensions.Logging;
using System;
namespace RAPI;
public sealed class AppLogger : IDisposable
    {
        private readonly ILogger<AppLogger> _logger;
        private readonly ILoggerFactory _loggerFactory;

        // Public constructor for DI compatibility
        public AppLogger(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory ?? throw new ArgumentNullException(nameof(loggerFactory));
            _logger = _loggerFactory.CreateLogger<AppLogger>();
        }

        public void LogInformation(string message)
        {
            _logger.LogInformation($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [INFO] {message}");
        }

        public void LogWarning(string message)
        {
            _logger.LogWarning($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [WARNING] {message}");
        }

        public void LogError(Exception ex, string message)
        {
            _logger.LogError(ex, $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [ERROR] {message}");
        }

        public void Dispose()
        {
            _loggerFactory?.Dispose();
        }
    }