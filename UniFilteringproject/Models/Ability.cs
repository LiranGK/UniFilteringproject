using System.ComponentModel.DataAnnotations;

namespace UniFilteringproject.Models
{
    public class Ability
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
