using System.ComponentModel.DataAnnotations;

namespace Projekt.Models
{
    public enum Format
    {
        [Display(Name = "JPG")] JPG = 1,
        [Display(Name = "JPEG")] JPEG = 2,
        [Display(Name = "PNG")] PNG = 3,
        [Display(Name = "RAW")] RAW = 4,
        [Display(Name = "TIFF")] TIFF = 5
    }
}
