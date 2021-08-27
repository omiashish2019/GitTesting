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
    }
}