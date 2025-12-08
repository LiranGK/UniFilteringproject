namespace UniFilteringproject.Models
{
    public class MalAss
    {
        public int Id { get; set; }
        public int MalshabId { get; set; }
        public Malshab? malshab { get; set; }
        public int AssignmentId { get; set; }
        public Assignment? assignment { get; set; }
    }
}
