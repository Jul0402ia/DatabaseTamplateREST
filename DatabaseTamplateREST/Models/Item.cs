namespace DatabaseTemplateREST.Models
{
    public class Item
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Category { get; set; }

        public int NumberValue { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Category: {Category}, NumberValue: {NumberValue}";
        }
    }
}