namespace panel_builder_app_web.Models
{
    public interface IPanel
    {
        int Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
    }
}