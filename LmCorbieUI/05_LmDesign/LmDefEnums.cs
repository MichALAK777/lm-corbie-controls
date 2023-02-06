using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LmCorbieUI.Design
{
    public enum LmValueType
    {
        Alfanumerico = 0,
        Num_Inteiro = 1,
        Num_Real = 2,
        Data = 3,
        Fone = 4,
        Monetario = 5,
        Email = 6,
        Cpf_Cnpj = 7,
        Hora = 8,
        ComboBox = 9,
        ComboBox_Enum = 10,
        Senha = 11,
    }

    public enum LmTransactionType 
    {
        Novo = 0,
        Alterar = 1,
        Excluir = 2,
        Login = 3,
        Diversos = 99,
    }

    public enum LmControlStatus 
    { 
        Normal = 0,
        Selected = 1,
        Disabled = 2,
    }

    public enum ButtonStyle
    {
        Default = 0,
        Information = 1,
        Question = 2,
        Warning = 3,
        Error = 4,
        Gray = 5,
    }

}
