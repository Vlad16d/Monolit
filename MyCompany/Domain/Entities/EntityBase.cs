using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyCompany.Domain.Entities
{
    public abstract class EntityBase
    {
        public int Id { get; set; }

        [Required(ErrorMessage="Wprowadz prosze Nazwę")]
        [Display(Name="Nazwa")]
        [MaxLength(200)]
        public string? Title { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.UtcNow; // -1 gdzina od czasu PL
    }
}
