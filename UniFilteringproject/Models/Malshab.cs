using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniFilteringproject.Models
{
    public class Malshab
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Dapar { get; set; }
        public int Profile { get; set; }
        public virtual ICollection<MalAss> MalAssignedList { get; set; } = new List<MalAss>();
        [NotMapped]
        public bool IsAssigned => MalAssignedList != null && MalAssignedList.Any();
        public ICollection<MalAbi>? MalAbis { get; set; }
    }
}