using System.ComponentModel;

namespace ApiCRUD.Enums;

public enum StatusTarefa
{
    [Description("A fazer")]
    AFazer = 1,
    
    [Description("Em andamento")]
    EmAndamento = 2,
    
    [Description("Concluído")]
    Concluido = 3
}