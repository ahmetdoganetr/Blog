using System.ComponentModel.DataAnnotations;

namespace Blog.WebApi.Model
{
    public class LoginApiModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
