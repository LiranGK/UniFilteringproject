using System.ComponentModel.DataAnnotations;

namespace UniFilteringproject.Models
{
    public class MalBlock
    {
        public int Id { get; set; }

        [Required]
        public int MalshabId { get; set; }
        public Malshab Malshab { get; set; }

        [Required]
        public int AssignmentId { get; set; }
        public Assignment Assignment { get; set; }
    }
}
