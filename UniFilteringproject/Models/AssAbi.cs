namespace UniFilteringproject.Models
{
    public class AssAbi
    {
        public int Id { get; set; }
        public int AssignmentId { get; set; }
        public Assignment? assignment { get; set; }
        public int AbilityId { get; set; }
        public Ability? ability { get; set; }
        public int AbiLevel { get; set; }
    }
}
