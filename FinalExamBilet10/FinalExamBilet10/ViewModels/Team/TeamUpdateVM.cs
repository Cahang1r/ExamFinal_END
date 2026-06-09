using System.ComponentModel.DataAnnotations;

namespace FinalExamBilet10.ViewModels.Team
{
    public class TeamUpdateVM
    {
        public string? Image { get; set; }
        
        public IFormFile? NewImage { get; set; }
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
        [Required]
        [MaxLength(25)]
        public string Job { get; set; }
        [Required]
        [MaxLength(255)]
        public string Description { get; set; }
    }
}
