using System.ComponentModel.DataAnnotations;

namespace Manager.API.ViewModels
{
    public class UpdateUserViewModel
    {
        [Required(ErrorMessage = "Esse campo é obrigatório.")]
        [Range(1, long.MaxValue, ErrorMessage = "O campo deve ser maior que zero.")]
        public long Id { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório.")]
        [MinLength(3, ErrorMessage = "O campo deve possuir no mínimo 3 caracteres.")]
        [MaxLength(80, ErrorMessage = "O campo deve possuir no máximo 80 caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório.")]
        [MinLength(10, ErrorMessage = "O campo deve possuir no mínimo 10 caracteres.")]
        [MaxLength(180, ErrorMessage = "O campo deve possuir no máximo 180 caracteres.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório.")]
        [MinLength(6, ErrorMessage = "O campo deve possuir no mínimo 6 caracteres.")]
        [MaxLength(30, ErrorMessage = "O campo deve possuir no máximo 30 caracteres.")]
        public string Password { get; set; }
    }
}