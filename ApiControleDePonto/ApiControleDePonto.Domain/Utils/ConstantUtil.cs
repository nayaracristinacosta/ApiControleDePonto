using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiControleDePonto.Domain.Utils
{
    public static class ConstantUtil
    {
        public const string Administrador = "1";
        public const string RecursosHumanos = "2";
        public const string Diretoria = "3";
        public const string Colaborador = "4";
        
      
        public const string Geral = $"{Administrador},{RecursosHumanos},{Diretoria},{Colaborador}";
    }
}
