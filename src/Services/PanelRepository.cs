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

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Panel>> GetAllPanelsAsync()
        {
            return _context.Panels.ToListAsync();
        }

        public Task<Panel> GetPanelAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}