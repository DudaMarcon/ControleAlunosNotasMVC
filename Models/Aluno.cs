namespace Sistema_notaAluno.Models
{
    public class Aluno
    {
        public int Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public string Turma { get; set; } = string.Empty;

        public string Matricula { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;
        
        public string Curso { get; set; } = string.Empty;

        public List<Nota> Notas { get; set; } = new List<Nota>();
    }
}