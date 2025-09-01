namespace Academico.Models
{
    public class Departamento
    {
        public int DepartamentoID { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int Telefone { get; set; }
        public List<Aluno> Alunos { get; set; } = new List<Aluno>();
    }
}
