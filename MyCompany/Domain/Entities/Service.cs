using System.ComponentModel.DataAnnotations;
using MyCompany.Domain.Enums;

namespace MyCompany.Domain.Entities
{
    public class Service : EntityBase
    {
        [Display(Name= "Wybierz kategorię, do której należy usługa")]
        public int? ServiceCategoryId { get; set; }
        public ServiceCategory? ServiceCategory { get; set; }

        [Display(Name = "Krótki opis")]
        [MaxLength(3_000)]
        public string? DescriptionShort { get; set; }

        [Display(Name = "Opis")]
        [MaxLength(100_000)]
        public string? Description { get; set; }

        [Display(Name = "Zdęcie tytułowe")]
        [MaxLength(300)]
        public string? Photo { get; set; }

        [Display(Name = "Rodzaj usługi")]
        public ServiceTypeEnum Type { get; set; }
    }
}
