using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiControleDePonto.Repositories
{
    public class Contexto
    {
        internal readonly SqlConnection _conn;
        public Contexto()
        {
            _conn = new SqlConnection("Server=DESKTOP-IFJENJ4\\NAYARA;Database=CONTROLEDEPONTO;Trusted_Connection=True;");
        }

        public void AbrirConexao()
        {
            _conn.Open();
        }

        public void FecharConexao()
        {
            _conn.Close();
        }
    }
}
