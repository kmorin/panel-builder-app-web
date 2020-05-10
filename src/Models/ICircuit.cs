namespace panel_builder_app_web.Models
{
    public interface ICircuit
    {
        int Id { get; set; }
        string Description { get; set; }
        int Load { get; set; }
        int NumPoles { get; set; }
        int Number { get; set; }
        int Rating { get; set; }
        string CircuitType { get; set; }
    }
}