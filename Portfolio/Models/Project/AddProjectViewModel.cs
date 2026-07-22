using Microsoft.AspNetCore.Mvc.Rendering;
using Portfolio.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models.Project
{
    public class AddProjectViewModel
    {
        public int Id { get; set; }

     
        public string Name { get; set; }

      
        public string ImageUrl { get; set; }

       
        public string Description { get; set; }

      
        public string GithubUrl { get; set; }

         

    }
}
