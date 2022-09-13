using Domain.Enum;

namespace Domain.Entities
{
    public class Ativo
    {
        public Ativo(string nome)
        {
            Nome = nome;
        }

        public int Id { get; set; } 
        public string Nome { get; set; }
        public GrupoAtivo Grupo { get; set; }
    }
}
