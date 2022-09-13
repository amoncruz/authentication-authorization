using InfoSolutionTeste.Domain.Entities;

namespace Domain.Enum
{
    public class Carteira
    {
        public int Id { get; set; }
        public double Saldo { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
