using System.ComponentModel.DataAnnotations;
namespace CRM.DTOs.CustomerDTOs
{
    public class CreateCustomerDTO
    {
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo Nombre no puede tener mas de 50 caracteres.")]

        public string Name { get; set; }

        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "El campo Apellido es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo Apellido no puede tener mas de 50 caracteres.")]

        public string LastName { get; set; }

        [Display(Name = "Dirrecion")]
        [MaxLength(255, ErrorMessage = "El campo Dirrecion no puede tener mas de 255 caracteres.")]

        public string? Address { get; set; }

    }
}
