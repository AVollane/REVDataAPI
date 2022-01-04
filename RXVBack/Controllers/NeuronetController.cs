using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using RXVBack.Hubs;
using RXVBackDL.Models;
using RXVBackDL.Models.Implementations;
using System.Diagnostics;
using System.Text.Json;

namespace RXVBack.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NeuronetController : Controller
    {
        private ILogger<NeuronetController> Logger { get; set; }
        RemoteLoggingHub RemoteLogger { get; set; }
        private IHubContext<RemoteLoggingHub> RemoteLoggingHubContext { get; set; }
        public NeuronetController(ILogger<NeuronetController> logger, IHubContext<RemoteLoggingHub> hubContext)
        {
            Logger = logger;
            RemoteLogger = new RemoteLoggingHub();
            RemoteLoggingHubContext = hubContext;
        }
        [Route("/api/[controller]/index")]
        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }

        [Route("/api/[controller]/postinfo")]
        [HttpPost]
        public async Task<IActionResult> PostInfo(NeuronetInformation neuronetInformation)
        {
            if(neuronetInformation != null)
            {
                Logger.LogInformation($"\nId: {neuronetInformation.Id},\nGender: {neuronetInformation.Gender},\n" +
                    $"Age: {neuronetInformation.Age},\nMood: {neuronetInformation.Mood}\n");
                string niJson = JsonSerializer.Serialize(neuronetInformation);
                await RemoteLoggingHubContext.Clients.All.SendAsync("TakeLog", niJson);
                return Ok();
            }
            else
            {
                Logger.LogError("JSON unathorized");
                return Unauthorized();
            }
        }
    }
}
