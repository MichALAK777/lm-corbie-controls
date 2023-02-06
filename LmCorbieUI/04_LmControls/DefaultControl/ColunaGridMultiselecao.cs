using LmCorbieUI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LmCorbieUI.Controls
{
    public class ColunaGridMultiselecao : IColunaGridMultiselecao
    {
        public bool Select { get; set; }
        public int ID { get; set; }
        public string Descricao { get; set; } = string.Empty;
    }
}
