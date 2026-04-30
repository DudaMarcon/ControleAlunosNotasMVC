namespace Sistema_notaAluno.Models
{
    public class Notas
    {
        public int Id { get; set; }

        public string Disciplina { get; set; }

        public double Valor { get; set; }

        public int AlunoId { get; set; }
    }
}
