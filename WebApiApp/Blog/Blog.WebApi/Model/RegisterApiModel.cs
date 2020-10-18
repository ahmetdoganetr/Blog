using System.ComponentModel.DataAnnotations;

namespace Blog.WebApi.Model
{
    public class RegisterApiModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
