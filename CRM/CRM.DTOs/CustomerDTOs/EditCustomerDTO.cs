using System.ComponentModel.DataAnnotations;
namespace CRM.DTOs.CustomerDTOs
{
    public class EditCustomerDTO
    {
        public EditCustomerDTO(GetIdResultCustomerDTO getIdResultCustomerDTO)
        {
            Id = getIdResultCustomerDTO.Id;
            Name = getIdResultCustomerDTO.Name;
            LastName = getIdResultCustomerDTO.LastName;
            Address = getIdResultCustomerDTO.Address;
        }
        public EditCustomerDTO()
        {
            Name = string.Empty;
            LastName = string.Empty;
        }
        [Required(ErrorMessage = "El campo Id es obligatorio")]

        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        [MaxLength(50, ErrorMessage = "El campo Nombre no puede tener mas de 50 caracteres")]
        public String Name { get; set; }

        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "El campo Apellido es obligatorio")]
        [MaxLength(50, ErrorMessage = "El campo Apellido no puede tener mas de 50 caracteres")]
        public String LastName { get; set; }

        [Display(Name = "Dirreccion")]
        [MaxLength(255, ErrorMessage = "El campo Dirreccion no puede tener mas de 255 caracteres")]
        public String? Address { get; set; }


    }
}
