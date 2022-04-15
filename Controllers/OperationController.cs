using DIDemo.IServices;
using DIDemo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DIDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OperationController : ControllerBase
    {
        private readonly ILogger<OperationController> _logger;
        private readonly IOperationTransient _operationTransient;
        private readonly IOperationScoped _operationScoped;
        private readonly IOperationSingleton _operationSingleton;
        private readonly FirstService _firstService;
        
        public OperationController(ILogger<OperationController> logger,
            IOperationTransient operationTransient,
            IOperationScoped operationScoped,
            IOperationSingleton operationSingleton,
            FirstService firstService
        )
        {
            _logger = logger;
            _operationTransient = operationTransient;
            _operationScoped = operationScoped;
            _operationSingleton = operationSingleton;
            _firstService = firstService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Start Operation Controller");

            _logger.LogInformation($"Transient: {_operationTransient.OperationId}");
            _logger.LogInformation($"Scoped: {_operationScoped.OperationId}");
            _logger.LogInformation($"Singleton: {_operationSingleton.OperationId}");

            _firstService.GetResult();

            return Ok();
        }
    }
}