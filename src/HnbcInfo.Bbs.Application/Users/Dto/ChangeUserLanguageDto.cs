using System.ComponentModel.DataAnnotations;

namespace HnbcInfo.Bbs.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}