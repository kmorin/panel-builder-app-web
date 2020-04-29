using System;
using System.Threading.Tasks;

namespace panel_builder_app_web.Models
{
    public interface IPanelRepository
    {
    void Add<T>(T entity) where T : class;
    void Delete<T>(T entity) where T : class;
    Task<bool> SaveChangesAsync();

    //Camps
    Task<Panel[]> GetAllPanelsAsync();
    }
}