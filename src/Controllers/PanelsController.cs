using System.Collections;
using System.IO;
using System.Linq;
using System;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using panel_builder_app_web.Models;
using System.Threading.Tasks;

namespace panel_builder_app_web.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PanelsController : ControllerBase
    {
        private readonly ILogger<PanelsController> _logger;
        private readonly IPanelRepository _panelRepository;

        public PanelsController(ILogger<PanelsController> logger, IPanelRepository panelRepository)
        {
            _logger = logger;
            _panelRepository = panelRepository;
        }

        [HttpGet]
        public async Task<List<Panel>> Get()
        {
            return await _panelRepository.GetAllPanelsAsync();
        }

        [HttpGet("{id}", Name = "Get")]
        public async Task<IPanel> Get(int id, bool withCircuits = true)
        {
            return await _panelRepository.GetPanelAsync(id, withCircuits);
        }
        
        [HttpDelete("{id}")]
        public async Task<int> Delete(int id)
        {
            await _panelRepository.Delete(id);
            return id;
        }

        [HttpPost]
        public async Task<Panel> Create(Panel panel) {
            if (ModelState.IsValid) {
                _panelRepository.Add<Panel>(panel);
            }
            return panel;
        }
    }
}