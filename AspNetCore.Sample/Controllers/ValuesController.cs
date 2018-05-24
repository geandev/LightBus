using AspNetCore.Sample.Messages;
using LightBus.Bus;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.Sample.Controllers
{
    [Route("")]
    public class ValuesController : Controller
    {
        private readonly ILightBus _lightBus;

        public ValuesController(ILightBus lightBus)
        {
            _lightBus = lightBus;
        }

        [HttpGet]
        public string Get()
        {
            _lightBus.SendAsync(new SampleMessage()).Wait();
            return "Ok";
        }
    }
}
