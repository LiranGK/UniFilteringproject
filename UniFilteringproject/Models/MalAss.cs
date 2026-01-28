namespace UniFilteringproject.Models
{
    public class MalAss
    {
        public int Id { get; set; }

        public int MalshabId { get; set; }
        public virtual Malshab? Malshab { get; set; }
        public int AssignmentId { get; set; }
        public virtual Assignment? Assignment { get; set; }
        public string AssignedBy { get; set; }
    }
}