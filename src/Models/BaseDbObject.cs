using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace panel_builder_app_web.Models
{
    public class BaseDbObject : ISoftDelete
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? UpdatedAt { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? DeletedAt { get; set; }
    }
}