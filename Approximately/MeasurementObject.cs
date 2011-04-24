namespace Approximately
{
    public class MeasurementObject
    {

        public MeasurementType Type { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }

        public MeasurementObject(){}

        public MeasurementObject(MeasurementType type, string name, double value)
        {
            this.Type = type;
            this.Name = name;
            this.Value = value;
        }
    }
}
