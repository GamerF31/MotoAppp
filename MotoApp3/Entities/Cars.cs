namespace MotoApp3.Entities
{
    public class Cars : EntityBase
    {
        public string Model { get; set; }
        public int Year { get; set; }
        public string Country {  get; set; }
        public override string ToString() => $"Id: {Id}, Model: {Model}, Year: {Year}, Country: {Country}";
    }
}
