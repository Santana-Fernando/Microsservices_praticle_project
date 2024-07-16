using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Usuario.get.Application.Usuario.ViewModel
{
    public class UsuarioView
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The E-mail is Required")]
        [MinLength(5)]
        [MaxLength(100)]
        [DisplayName("E-mail")]
        public string Email { get; set; }

    }
}
