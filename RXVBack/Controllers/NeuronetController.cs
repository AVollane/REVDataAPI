using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        public NeuronetController(ILogger<NeuronetController> logger)
        {
            Logger = logger;
        }
        [Route("/api/[controller]/index")]
        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }

        [Route("/api/[controller]/postinfo")]
        [HttpPost]
        public IActionResult PostInfo(NeuronetInformation neuronetInformation)
        {
            if(neuronetInformation != null)
            {
                Logger.LogInformation($"\nId: {neuronetInformation.Mood},\nGender: {neuronetInformation.Gender},\n" +
                    $"Age: {neuronetInformation.Age},\nMood: {neuronetInformation.Mood}\n");
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
