namespace Portfolio.Models.ProjectStack
{
    public class ProjectStackDetailsViewModel
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public string GithubUrl { get; set; }
        public List<string> TechStackNames { get; set; }
    }
}
