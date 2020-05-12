using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace panel_builder_app_web.Models
{
    public class Panel : BaseDbObject, IPanel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        [Key]
        public int Id { get; set; }
        public string DistSystemName { get; set; }
        public string AicRating { get; set; }
        public double BusRating { get; set; }
        public string Mains { get; set; }
        public string CircuitLoadClassification { get; set; }
        public string FilePath { get; set; }
        public List<Circuit> Circuits { get; set; }
        public double McbRating { get; set; }
        public string Mounting { get; set; }
    }
}