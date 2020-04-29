using System.Linq;
using System.Xml.Linq;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using panel_builder_app_web.Models;

namespace panel_builder_app_web.Services
{
    public class PanelRepository : IPanelRepository
    {
        public Panel[] Panels { get; private set; }

        //Populate panels
        public PanelRepository()
        {
            string json = System.IO.File.ReadAllText("Api/panels.json");
            try{ 
              Panels = JsonSerializer.Deserialize<Panel[]>(json);            
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
            var pList = Panels.ToList();
            pList.RemoveAt(id);
            Panels = pList.ToArray();
        }

        public async Task<Panel[]> GetAllPanelsAsync()
        {
            return Panels ?? null;
        }

        public async Task<bool> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}