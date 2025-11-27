namespace UniFilteringproject.Models
{
    public class MalAbi
    {
        public int Id { get; set; }
        public int MalshabId { get; set; }
        public Malshab? malshab { get; set; }
        public int AbilityId { get; set; }
        public Ability? Ability { get; set; }
        public int AbiLevel { get; set; }
    }
}
