namespace CodeCamp.NewFeatures.Models
{
    public enum AircraftEngineType
    {
        Reciprocating,
        Turboprop,
        Turboshaft,
        Turbojet,
        Turbofan,
        PulseJet,
        Rocket
    }
    public class Aircraft : Vehicle
    {
        public AircraftEngineType EngineType { get; set; }
        public int EngineCount { get; set; }
        public int MaximumGrossTakeoffWeight { get; set; }

        public Aircraft(string name, string manufacturer) : base(name, manufacturer) { }
        public override void Go()
        {
            PreflightChecks();
            StartEngines();
            TaxiToRunway();
            Takeoff();
        }

        private void PreflightChecks() { }
        private void StartEngines() { }
        private void TaxiToRunway() { }
        private void Takeoff() { }
    }
}