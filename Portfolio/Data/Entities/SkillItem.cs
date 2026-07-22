namespace Portfolio.Data.Entities
{
    public class SkillItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public int SkillId { get; set; }
        public Skill Skill { get; set; }
    }
}
