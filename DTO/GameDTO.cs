using System.ComponentModel.DataAnnotations;

namespace GameLauncher.DTO
{
    public class GameDTO{
        [Required]public int Id {get; set;}
        [Required]public string Title {get; set;}
    }
}