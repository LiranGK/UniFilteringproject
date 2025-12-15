using System.ComponentModel.DataAnnotations;

namespace UniFilteringproject.Models
{
    public class Assignment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DaparNeeded { get; set; }
        public int ProfileNeeded { get; set; }
        public bool IsAboveMin { get; set; } = false;
        public int CurrMalAssinged { get; set; } = 0;
        public int MinMalshabs { get; set; }
    }
}
