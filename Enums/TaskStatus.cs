using System.ComponentModel;

namespace SistemaDeTarefas.Enums
{
    public enum taskStatus
    {
        [Description("A fazer")]
        aFazer = 1,
        [Description("Em Andamento")]
        emAndamento = 2,
        [Description("Concluido")]
        Concluido = 3
    }
}
