using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using panel_builder_app_web.Models;
using Microsoft.EntityFrameworkCore;

namespace panel_builder_app_web.Services
{

    public class PanelRepository : IPanelRepository
    {
        private PanelContext _context;

        public PanelRepository(PanelContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public async Task<int> Delete(int id)
        {
            var p = _context.Panels.FirstOrDefaultAsync(p=>p.Id == id);
            if (p != null) _context.Panels.Remove(p.Result);
            await _context.SaveChangesAsync();
            return id;
        }

        public async Task<List<Panel>> GetAllPanelsAsync()
        {
            return await _context.Panels.ToListAsync();
        }

        public async Task<Panel> GetPanelAsync(int id)
        {
            var p = await _context.Panels.Include(p=>p.Circuits).FirstOrDefaultAsync(p=>p.Id == id);           
            return p;
        }
    }
}