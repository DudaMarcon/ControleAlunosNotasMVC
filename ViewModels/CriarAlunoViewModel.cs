using System.ComponentModel.DataAnnotations;

namespace Sistema_notaAluno.ViewModels
{
    public class CriarAlunoViewModel
    {
        [Required(ErrorMessage = "Digite o nome do aluno")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "Digite a turma")]
        public string Turma { get; set; } = string.Empty;

        [Required(ErrorMessage = "Digite a matrícula")]
        public string Matricula { get; set; } = string.Empty;

        [Required(ErrorMessage = "Digite o status")]
        public string Status { get; set; } = string.Empty;

        [Required(ErrorMessage = "Digite o curso")]
        public string Curso { get; set; } = string.Empty;
    }
}