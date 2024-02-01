using Newtonsoft.Json.Linq;

namespace coreFormsAndValidations.Models
{
    public class LoginViewModel
    {
        // null values to make it warning free, or question mark optional property to be created. 
        public string? Username { get; set; }   
        public string? Password { get; set; }   
    }
}
