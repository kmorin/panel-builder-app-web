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

        public async Task<bool> Add(Panel panel)
        {
            try
            {
                await _context.Panels.AddAsync(panel);
                await _context.SaveChangesAsync();
            }
            catch (System.Exception)
            {
                return false;
                throw;
            }
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var p = await _context.Panels.Include(p=>p.Circuits).FirstOrDefaultAsync(p => p.Id == id);
                if (p != null) {
                    List<Circuit> c = p.Circuits;
                    _context.Circuits.RemoveRange(c);
                    _context.Panels.Remove(p);
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            return true;
        }

        public async Task<List<Panel>> GetAllPanelsAsync()
        {
            return await _context.Panels.ToListAsync();
        }

        public async Task<Panel> GetPanelAsync(int id, bool withCircuits)
        {
            Panel p;
            if (withCircuits) p = await _context.Panels.Include(p => p.Circuits).FirstOrDefaultAsync(p => p.Id == id);
            else p = await _context.Panels.FirstOrDefaultAsync(p => p.Id == id);
            return p;
        }
    }
}