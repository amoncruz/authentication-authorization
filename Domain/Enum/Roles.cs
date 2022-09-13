
using System.ComponentModel;

namespace Domain.Enum
{
    public enum Roles
    {
        [Description("Gerente")]
        Gerente,
        [Description("Cliente")]
        Cliente,
        [Description("Admin")]
        Admin
    }
}
