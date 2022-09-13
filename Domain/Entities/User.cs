using Domain.Enum;
using Extensions.Utils;

namespace InfoSolutionTeste.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Nome { get; set; }
        public string DataNascimento { get; set; }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public string? Role { get; private set; }

        public void DefinirRole(Roles role)
        {
            switch (role)
            {
                case Roles.Gerente:
                    Role = Roles.Gerente.DisplayName();
                    return;
                case Roles.Cliente:
                    Role = Roles.Cliente.DisplayName();
                    return;
                case Roles.Admin:
                    Role = Roles.Admin.DisplayName();
                    return;
            }
        }
    }
}