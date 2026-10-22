using System.ComponentModel.DataAnnotations;

namespace Sistema_notaAluno.ViewModels
{
    public class CriarNotaViewModel
    {
        [Required(ErrorMessage = "Selecione o aluno")]
        public int AlunoId { get; set; }

        [Required(ErrorMessage = "Digite a disciplina")]
        public string Disciplina { get; set; } = string.Empty;

        [Range(0, 10, ErrorMessage = "A nota deve estar entre 0 e 10")]
        public double Nota1 { get; set; }

        [Range(0, 10, ErrorMessage = "A nota deve estar entre 0 e 10")]
        public double Nota2 { get; set; }
    }
}