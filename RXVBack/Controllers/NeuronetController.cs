using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RXVBackDL.Models;
using RXVBackDL.Models.Implementations;
using RXVBackDL.Repository;
using RXVBackDL.Repository.DbContexts;
using RXVBackDL.Repository.Repositories;
using System.Diagnostics;
using System.Text.Json;

namespace RXVBack.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NeuronetController : Controller
    {
        private ILogger<NeuronetController> Logger { get; set; }
        private IRepository<NeuronetInformation> NIDbContext { get; set; }
        public NeuronetController(ILogger<NeuronetController> logger, IRepository<NeuronetInformation> dbContext)
        {
            Logger = logger;
            NIDbContext = dbContext;
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
                Logger.LogInformation($"\nId: {neuronetInformation.Id},\nGender: {neuronetInformation.Gender},\n" +
                    $"Age: {neuronetInformation.Age},\nMood: {neuronetInformation.Mood}\n");

                using (NeuronetInformationRepository niRepository = new NeuronetInformationRepository())
                {
                    niRepository.Create(neuronetInformation);
                    niRepository.Save();
                }
                return Ok();
            }
            else
            {
                Logger.LogError("JSON unathorized");
                return Unauthorized();
            }
        }
        
        [Route("/api/[controller]/getlastinfo")]
        [HttpGet]
        public NeuronetInformation GetLastInfo()
        {
            return NIDbContext.GetAll().Last();
        }

        [Route("/api/[controller]/deletebyid")]
        [HttpDelete]
        public IActionResult DeleteById(int id)
        {
            try
            {
                NIDbContext.Delete(id);
                NIDbContext.Save();
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
