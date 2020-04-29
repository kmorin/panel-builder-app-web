namespace panel_builder_app_web.Models
{
    public class Panel : IPanel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
    }
}