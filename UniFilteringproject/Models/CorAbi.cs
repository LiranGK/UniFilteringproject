namespace UniFilteringproject.Models
{
    public class CorAbi
    {
        public int Id { get; set; }
        public int CorpId { get; set; }
        public Corp? corp { get; set; }
        public int AbilityId { get; set; }
        public Ability? ability { get; set; }
        public int AbiLevel { get; set; }
    }
}
