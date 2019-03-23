namespace CodeCamp.NewFeatures.Models
{
    public enum WatercraftEngineType
    {
        Steam,
        Diesel,
        GasTurbine,
        Nuclear

    }
    public class Watercraft : Vehicle
    {
        public WatercraftEngineType EngineType { get; set; }
        public int ScrewCount { get; set; }
        public int Tonnage { get; set; }

        public Watercraft(string name, string manufacturer) : base(name, manufacturer) { }

        public override void Go()
        {
            RetractGangway();
            StartEngines();
            MakeWay();
        }

        private void RetractGangway() { }
        private void StartEngines() { }
        private void MakeWay() { }
    }
}