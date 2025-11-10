namespace UniFilteringproject.Models
{
    public class Uni
    {
        public int Id { get; set; }

        public List<Haiils> ListOfHaiils { get; set; } = new();
    }
    public class Haiils
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
