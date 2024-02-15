//Importacion del espacio de nombres para los DTO relacionados con los clientes
using CRM.DTOs.CustomerDTOs;

namespace CRM.AppWebBlazor.Data
{
    public class CustomerService
    {
        readonly HttpClient _httpClientCRMAPI;

        //Constructor que recibe una instacia de IHttpClientFactory para crear el cliente Http

        public CustomerService(IHttpClientFactory httpClientFactory)
        {
            _httpClientCRMAPI = httpClientFactory.CreateClient("CRMAPI");
        }

        //Metodo para buscar cliente utilizando una solicitud HTTP POST
        public async Task<SearchResultCustomerDTO> Search(SearchQueryCustomerDTO searchQueryCustomerDTO)
        {
            var response = await _httpClientCRMAPI.PostAsJsonAsync("/customer/search", searchQueryCustomerDTO);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<SearchResultCustomerDTO>();
                return result ?? new SearchResultCustomerDTO();
            }
            return new SearchResultCustomerDTO(); // Devolver un objeto vacio en caso de error o respuesta no exitosa
        }
        //Metodo para obtener un cliente por su ID utilizando una solicitud HTTP GET 

        public async Task<GetIdResultCustomerDTO> GetById(int id)
        {
            var response = await _httpClientCRMAPI.GetAsync("/customer/" + id);
            if(response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<GetIdResultCustomerDTO>();
                return result ?? new GetIdResultCustomerDTO();
            }
            return new GetIdResultCustomerDTO(); // Devolver un objecto vacio en caso de error o respuesta no exitosa
        }

        //Metodo para crear un nuevo cliente utilizando una solicitud HTTP POST
        public async Task<int> Create(CreateCustomerDTO createCustomerDTO)
        {
            int result = 0;
            var response = await _httpClientCRMAPI.PostAsJsonAsync("/customer", createCustomerDTO);
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                if (int.TryParse(responseBody, out result) == false)
                    result = 0;
            }
            return result;
        }
        //Metodo para editar un cliente existente utilizando una solicitud HTTP PUT

        public async Task<int> Edit(EditCustomerDTO editCustomerDTO)
        {
            int result = 0;
            var response = await _httpClientCRMAPI.PutAsJsonAsync("/customer", editCustomerDTO);
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                if (int.TryParse(responseBody, out result) == false)
                    result = 0;
            }
            return result;
        }

        //Metodo para eliminar un cliente por su ID utilizando una solicitud HTTP DELETE

        public async Task<int> Delete(int id)
        {
            int result = 0;
            var response = await _httpClientCRMAPI.DeleteAsync("/customer/" + id);
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                if(int.TryParse(responseBody, out result) == false)
                    result = 0;
            }
            return result;
        }
    }
}