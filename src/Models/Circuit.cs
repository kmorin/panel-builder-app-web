namespace panel_builder_app_web.Models
{
    public class Circuit : ICircuit
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Load { get; set; }
        public int NumPoles { get; set; }
        public int Number { get; set; }
        public int Rating { get; set; }
        public string CircuitType { get; set; }
    }
}