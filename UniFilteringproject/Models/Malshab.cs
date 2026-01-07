using System.ComponentModel.DataAnnotations;

namespace UniFilteringproject.Models
{
    public class Malshab
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Dapar { get; set; }
        public int Profile { get; set; }
        public bool IsAssigned { get; set; }
        public ICollection<MalAbi>? MalAbis { get; set; }
    }
}