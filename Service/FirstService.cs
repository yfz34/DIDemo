using System;
using DIDemo.IServices;
using Microsoft.Extensions.Logging;

namespace DIDemo.Services
{
    public class FirstService
    {
        private readonly ILogger<FirstService> _logger;
        private readonly IOperationTransient _operationTransient;
        private readonly IOperationScoped _operationScoped;
        private readonly IOperationSingleton _operationSingleton;

        public FirstService(ILogger<FirstService> logger,
            IOperationTransient operationTransient,
            IOperationScoped operationScoped,
            IOperationSingleton operationSingleton)
        {
            _logger = logger;
            _operationTransient = operationTransient;
            _operationScoped = operationScoped;
            _operationSingleton = operationSingleton;
        }

        public void GetResult()
        {
            _logger.LogInformation($"FirstService - Transient: {_operationTransient.OperationId}");
            _logger.LogInformation($"FirstService - Scoped: {_operationScoped.OperationId}");
            _logger.LogInformation($"FirstService - Singleton: {_operationSingleton.OperationId}");
        }
    }
}