using System;
using DIDemo.IServices;

namespace DIDemo.Services
{
    public class Operation : IOperationTransient, IOperationScoped, IOperationSingleton
    {
        public string OperationId { get; }

        public Operation()
        {
            OperationId = Guid.NewGuid().ToString()[^4..];
        }
    }
}