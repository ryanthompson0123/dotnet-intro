namespace CodeCamp.NewFeatures.Models
{
    public enum EngineType
    {
        TwoStroke,
        FourStroke,
        Diesel,
        Electric,
        Wankel
    }
    public class GroundVehicle : Vehicle
    {
        public EngineType EngineType { get; set; }
        public int WheelCount { get; set; }
        public int GrossVehicleWeightRating { get; set; }

        public GroundVehicle(string name, string manufacturer) : base(name, manufacturer) { }

        public override void Go()
        {
            StartEngine();
            Accelerate();
        }

        private void StartEngine() { }

        private void Accelerate() { }
    }
}