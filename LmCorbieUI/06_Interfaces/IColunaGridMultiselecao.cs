using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LmCorbieUI.Interfaces
{
    public interface IColunaGridMultiselecao
    {
        bool Select { get; set; }
        int ID { get; set; }
        string Descricao { get; set; }
    }
}
