using System.ComponentModel;

namespace Domain.Enum
{
    public enum GrupoAtivo
    {
        [Description("Renda Fixa")]
        RendaFixa,
        [Description("Renda Variável")]
        RendaVariavel,
        [Description("Fundos")]
        Fundos,
        [Description("Ações")]
        Acoes,
        [Description("Tesouro Direto")]
        TesouroDireto,
        [Description("Poupança")]
        Poupanca,
        [Description("Criptomoeda")]
        Criptomoeda,
    }
}
