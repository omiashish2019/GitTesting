using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GitTesting.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class Feature1Controller : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "Feature1", "Feature1" };
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetFeature()
        {
            return new string[] { "Feature10", "Feature10" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // Sbi Feature
        [HttpGet]
        public ActionResult<IEnumerable<string>> SBIGet()
        {
            return new string[] { "Sbi Feature", "Sbi Feature" };
        }

        // Sbi Feature
        [HttpGet]
        public ActionResult<IEnumerable<string>> MaxBupaGet()
        {
            return new string[] { "Max Feature", "Bupa Feature" };
        }
        // EGI Feature
        [HttpGet]
        public ActionResult<IEnumerable<string>> EGIGet()
        {
            return new string[] { "EGI Feature", "EGI Feature" };
        }
    }
}
