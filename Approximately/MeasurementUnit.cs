namespace Approximately
{
    public class MeasurementUnit
    {

        public MeasurementType Type { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }

        public MeasurementUnit(){}

        public MeasurementUnit(MeasurementType type, string name, double value)
        {
            this.Type = type;
            this.Name = name;
            this.Value = value;
        }
    }
}
