using System.Linq;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using panel_builder_app_web.Models;
using System.Collections.Generic;

namespace panel_builder_app_web.Services
{
    public class PanelJsonRepository : IPanelRepository
    {
        public List<Panel> Panels { get; private set; }

        //Populate panels
        public PanelJsonRepository()
        {
            var options = new JsonSerializerOptions{ PropertyNameCaseInsensitive = true};
            string json = System.IO.File.ReadAllText("Api/panels.json");
            try{ 
              Panels = JsonSerializer.Deserialize<List<Panel>>(json, options);            
            }
            catch(Exception ex){ 
              Console.WriteLine(ex);
            }
        }

        public void Add<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public async Task<int> Delete(int id)
        {
            Panel panel = Panels.FirstOrDefault(x=>x.Id == id);
            if (panel != null)
            {
                var didRemove = Panels.Remove(panel);
                if (!didRemove) throw new Exception("Didn't delete");
            }
            return id;
        }

        public async Task<List<Panel>> GetAllPanelsAsync()
        {
            return Panels ?? null;
        }

        public async Task<Panel> GetPanelAsync(int id, bool withCircuits)
        {
            return Panels.FirstOrDefault(x=>x.Id == id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Circuit>> GetPanelCircuitsAsync()
        {
            throw new NotImplementedException();
        }
    }
}