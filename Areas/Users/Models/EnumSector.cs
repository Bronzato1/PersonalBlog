using System.ComponentModel.DataAnnotations;

namespace PersonalBlog.Models
{
    public enum EnumSector
    {
        [Display(Name = "Agriculture", Order = 1)]
        Agriculture = 1,
        [Display(Name = "Art & sport", Order = 2)]
        ArtSport = 2,
        [Display(Name = "Banking", Order = 3)]
        Banking = 3,
        [Display(Name = "Chemical", Order = 4)]
        Chemical = 4,
        [Display(Name = "Commerce", Order = 5)]
        Commerce = 5,
        [Display(Name = "Construction", Order = 6)]
        Construction = 6,
        [Display(Name = "Consultancy", Order = 7)]
        Consultancy = 7,
        [Display(Name = "Education", Order = 8)]
        Education = 8,
        [Display(Name = "Engineering", Order = 9)]
        Engineering = 9,
        [Display(Name = "Finance", Order = 10)]
        Finance = 10,
        [Display(Name = "Food & beverage", Order = 11)]
        FoodBeverage = 11,
        [Display(Name = "Health", Order = 12)]
        Health = 12,
        [Display(Name = "Industry", Order = 13)]
        Industry = 13,
        [Display(Name = "Pharmaceutical", Order = 14)]
        Pharmaceutical = 14,
        [Display(Name = "Public", Order = 15)] 
        Public = 15,
        [Display(Name = "Telecom", Order = 16)]
        Telecom = 16,
        [Display(Name = "Tourism", Order = 17)]
        Tourism = 17,
        [Display(Name = "Transport", Order = 18)]
        Transport = 18
    }
}