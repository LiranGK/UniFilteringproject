using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniFilteringproject.Models
{
    public class Assignment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DaparNeeded { get; set; }
        public int ProfileNeeded { get; set; }
        public int MinMalshabs { get; set; }


        // Navigation property to the junction table
        // This MUST match the name in your ApplicationDbContext
        public virtual ICollection<MalAss> MalAssignedList { get; set; } = new List<MalAss>();

        // CALCULATED PROPERTIES
        // [NotMapped] tells Entity Framework not to create a column in the DB for these

        [NotMapped]
        public int CurrMalAssinged => MalAssignedList?.Count ?? 0;

        [NotMapped]
        public bool IsAboveMin => CurrMalAssinged >= MinMalshabs;
    }
}
