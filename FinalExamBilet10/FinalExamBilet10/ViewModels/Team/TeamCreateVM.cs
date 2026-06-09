using System.ComponentModel.DataAnnotations;

namespace FinalExamBilet10.ViewModels.Team
{
    public class TeamCreateVM
    {
        [Required]
        public IFormFile Image { get; set; }
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
