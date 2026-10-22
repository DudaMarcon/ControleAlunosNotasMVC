namespace Sistema_notaAluno.Models
{
    public class Nota
    {
        public int Id { get; set; }

        public int AlunoId { get; set; }
        
        public string Disciplina { get; set; } = string.Empty;

        public double Nota1 { get; set; }

        public double Nota2 { get; set; }

        public double Media
        {
            get { return (Nota1 + Nota2) / 2; }
        }

        public string Situacao
        {
            get
            {
                return Media >= 6 ? "Aprovado" : "Reprovado";
            }
        }
    }
}