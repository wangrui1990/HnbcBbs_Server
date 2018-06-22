using System.ComponentModel.DataAnnotations;

namespace HnbcInfo.Bbs.Configuration.Dto
{
    public class ChangeUiThemeInput
    {
        [Required]
        [StringLength(32)]
        public string Theme { get; set; }
    }
}
