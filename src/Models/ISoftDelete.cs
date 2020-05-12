using System;

namespace panel_builder_app_web.Models
{
    public interface ISoftDelete
    {
        DateTime? DeletedAt { get; set; }
    }
}