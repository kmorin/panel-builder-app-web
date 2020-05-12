using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace panel_builder_app_web.Models
{
    public interface IPanelRepository
    {
    Task<bool> Add(Panel panel);
    Task<bool> Delete(int id);

    //Panels
    Task<List<Panel>> GetAllPanelsAsync();
    Task<Panel> GetPanelAsync(int id, bool withCircuits);    
    }
}