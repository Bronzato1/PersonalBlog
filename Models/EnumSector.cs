using System.ComponentModel.DataAnnotations;

namespace PersonalBlog.Models
{
    public enum EnumSector
    {
        [Display(Name = "Banking")]
        Banking,
        [Display(Name = "Industry")]
        Industry,
        [Display(Name = "Food & beverage")]
        FoodBeverage,
        [Display(Name = "Pharmaceutical")]
        Pharmaceutical,
        [Display(Name = "Art & sport")]
        ArtSport,
        [Display(Name = "Consultancy")]
        Consultancy
    }
}