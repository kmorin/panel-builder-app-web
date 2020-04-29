using System.Collections;
using System.IO;
using System.Linq;
using System;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using panel_builder_app_web.Models;

namespace panel_builder_app_web.Controllers{

    [ApiController]
    [Route("[controller]")]
    public class PanelsController : ControllerBase
    {
        private readonly ILogger<PanelsController> _logger;

        public PanelsController(ILogger<PanelsController> logger){
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<IPanel> Get(){
            string json = System.IO.File.ReadAllText("Api/panels.json");
            var p = JsonSerializer.Deserialize<IEnumerable<Panel>>(json);
            return p;
            // var p = new Random();
            // return Enumerable.Range(1,5).Select(x=>new Panel{
            //     Name = $"Name {p.Next(-10,55)}",
            //     Description = "Desc"
            // }).ToArray();
        }

    }
}