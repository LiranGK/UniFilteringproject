using System.Collections.Generic;
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

        // Navigation property to the junction table for assigned Malshabs
        public virtual ICollection<MalAss> MalAssignedList { get; set; } = new List<MalAss>();

        // Navigation property for required Abilities
        // This allows the Details view to see what abilities this unit needs
        public virtual ICollection<AssAbi> AssAbis { get; set; } = new List<AssAbi>();

        // CALCULATED PROPERTIES
        [NotMapped]
        public int CurrMalAssinged => MalAssignedList?.Count ?? 0;

        [NotMapped]
        public bool IsAboveMin => CurrMalAssinged >= MinMalshabs;
    }
}