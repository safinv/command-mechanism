using System;
using CommandMechanism.Base.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CommandMechanism.Example
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExampleController : ControllerBase
    {
        private readonly ICommandProcessorFactory _commandProcessorFactory;

        public ExampleController(ICommandProcessorFactory commandProcessorFactory)
        {
            _commandProcessorFactory = commandProcessorFactory ?? throw new ArgumentNullException(nameof(commandProcessorFactory));
        }

        [HttpGet]
        public void ExampleGetMethod()
        {
            var processor = _commandProcessorFactory.GetCommandProcessor();

            var exampleCommand = new ExampleCommand();

            processor.Process(exampleCommand);
        }
    }
}