using System.ComponentModel.DataAnnotations;

namespace CemeterySystem.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}