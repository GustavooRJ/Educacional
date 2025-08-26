using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Academico.Models
{
    public class Aluno
    {
        public int AlunoID { get; set; }
        public string Nome { get; set; }
        [DisplayName(
            "E-mail")]
        public string Email { get; set; }

        [DisplayName("CEP")]
        public int Cep { get; set; }


    }
}
