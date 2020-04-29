using System;
using System.Text.Json;
using System.Threading.Tasks;
using panel_builder_app_web.Models;

namespace panel_builder_app_web.Services
{
    public class PanelRepository : IPanelRepository
    {
        public void Add<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public async Task<Panel[]> GetAllPanelsAsync()
        {
            string json = System.IO.File.ReadAllText("Api/panels.json");
            Panel[] panels = null;
            try{
            panels = JsonSerializer.Deserialize<Panel[]>(json);
            }
            catch(Exception ex){
                Console.WriteLine(ex);
            }
            return panels ?? null;
        }

        public async Task<bool> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}