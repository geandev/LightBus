using AspNetCore.Sample.Messages;
using LightBus.Bus;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
        public async Task<string> Get()
        {
            await _lightBus.SendAsync(
                new SampleMessage
                {
                    Value = "Hello LightBus"
                });
            return "Ok";
        }
    }
}
