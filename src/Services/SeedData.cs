using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using panel_builder_app_web.Models;

namespace panel_builder_app_web.Services
{

    public static class SeedData
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PanelContext(serviceProvider.GetRequiredService<DbContextOptions<PanelContext>>()))
            {
                if (context.Panels.Any())
                {
                    return;
                }

                context.Panels.AddRange(
                    new Panel
                    {
                        Name = "Panel1",
                        Description = "Panel Desc",
                        DistSystemName = "120/208v",
                        AicRating = "10000",
                        BusRating = 400,
                        Mains = "400",
                        CircuitLoadClassification = "Lighting",
                        FilePath = "c",
                        McbRating = 400,
                        Mounting = "Surface",
                        Circuits = new System.Collections.Generic.List<Circuit>{
                            new Circuit{
                                Number = 1,
                                NumPoles = 1,
                                Description = "Lits",
                                Load = 15000,
                                Rating = 15,
                                CircuitType = "Single"
                            }
                        }
                    },
                    new Panel
                    {
                        Name = "Panel2",
                        Description = "Panel Desc",
                        DistSystemName = "120/208v",
                        AicRating = "10000",
                        BusRating = 400,
                        Mains = "400",
                        CircuitLoadClassification = "Lighting",
                        FilePath = "c",
                        McbRating = 400,
                        Mounting = "Surface"                        
                    }
                );

                context.SaveChanges();
            }
        }
    }
}