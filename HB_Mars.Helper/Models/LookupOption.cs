namespace HB_Mars.Helper.Models
{
    public class LookupOption
    {
        public LookupOption(int id, string label, string value)
        {
            Id = id;
            Label = label;
            Value = value;
        }

        public int Id { get; set; }
        public string Label { get; set; }
        public string Value { get; set; }
    }
}
