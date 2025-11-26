using System.ComponentModel.DataAnnotations;

namespace UniFilteringproject.Models
{
    public class Corp
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsFull { get; set; }
        public bool DoesBlock { get; set; }
        public int MinMalshabs { get; set; }
        public List<AppointedMalshab> Malshabim { get; set; } = new();
    }
    public class AppointedMalshab 
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
