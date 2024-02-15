using System.ComponentModel.DataAnnotations;

namespace CRM.DTOs.CustomerDTOs
{
    public class SearchQueryCustomerDTO
    {
        [Display(Name ="Nombre")]
        public string? Name_like { get; set; }
        [Display(Name ="Apellido")]
        public string? LastName_like { get; set; }
        [Display(Name ="pagina")]
        public int Skip { get; set; }
        [Display(Name = "CantReg X Pagina")]
        public int Take { get; set; }

        /// <summary>
        /// 1 = No se cuenta los resultados de la busqueda 
        /// 2 = cuenta los resultados de la busqueda
        /// </summary>
        
        public byte SendRowCount { get; set; }
    }
}