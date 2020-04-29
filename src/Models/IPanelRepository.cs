using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace panel_builder_app_web.Models
{
    public interface IPanelRepository
    {
    void Add<T>(T entity) where T : class;
    public void Delete(int id);
    Task<bool> SaveChangesAsync();

    //Panels
    Task<List<Panel>> GetAllPanelsAsync();
    Task<Panel> GetPanelAsync(int id);

    }
}