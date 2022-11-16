namespace WireMockDemo.Entities
{
    public class Organization:EntityBase
    {
        public string? Name { get; set; }

        public override string ToString() => $"{Id} - {Name}";
    }
}