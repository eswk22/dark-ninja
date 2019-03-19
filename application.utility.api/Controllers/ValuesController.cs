using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using application.utility.api.manager;
using Infrastructure.Settings;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace application.utility.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        private IHostingEnvironment _hostingEnvironment;
        private readonly BluePrint _settings;
        private readonly IExcelManager _excelManager;

        public ValuesController(IHostingEnvironment hostingEnvironment, IOptions<BluePrint> settings, IExcelManager excelManager)
        {
            this._settings = settings.Value;
            this._excelManager = excelManager;
        }


        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            string path = Path.Combine(_settings.Common.UploadPath,"Upload", "test.xlsx");
            _excelManager.ReadFile(path);
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
