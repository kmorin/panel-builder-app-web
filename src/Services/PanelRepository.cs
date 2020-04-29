using System.Linq;
using System.Xml.Linq;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using panel_builder_app_web.Models;
using System.Collections.Generic;

namespace panel_builder_app_web.Services
{
    public class PanelRepository : IPanelRepository
    {
        public List<Panel> Panels { get; private set; }

        //Populate panels
        public PanelRepository()
        {
            string json = System.IO.File.ReadAllText("Api/panels.json");
            try{ 
              Panels = JsonSerializer.Deserialize<List<Panel>>(json);            
            }
            catch(Exception ex){ 
              Console.WriteLine(ex);
            }
        }

        public void Add<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            Panel panel = Panels.FirstOrDefault(x=>x.Id == id);
            if (panel != null)
            {
                var didRemove = Panels.Remove(panel);
                if (!didRemove) throw new Exception("Didn't delete");
            }
        }

        public async Task<List<Panel>> GetAllPanelsAsync()
        {
            return Panels ?? null;
        }

        public async Task<Panel> GetPanelAsync(int id)
        {
            return Panels.FirstOrDefault(x=>x.Id == id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}