using System.Collections.Generic;

namespace panel_builder_app_web.Models
{
    public interface IPanel
    {
        int Id { get; set; }
        string Name { get; set; }
        string DistSystemName { get; set; }
        string AicRating { get; set; }
        double BusRating { get; set; }
        string Mains { get; set; }
        string CircuitLoadClassification { get; set; }
        string FilePath { get; set; }
        List<Circuit> Circuits { get; set; }
        double McbRating { get; set; }
        string Mounting { get; set; }
    }
}