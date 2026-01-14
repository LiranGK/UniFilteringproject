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

        // Navigation property to the junction table
        // This MUST match the name in your ApplicationDbContext
        public virtual ICollection<MalAss> MalAssignedList { get; set; } = new List<MalAss>();

        // CALCULATED PROPERTIES
        // [NotMapped] tells Entity Framework not to create a column in the DB for these

        [NotMapped]
        public bool IsAssigned => MalAssignedList != null && MalAssignedList.Any();
        public ICollection<MalAbi>? MalAbis { get; set; }
    }
}