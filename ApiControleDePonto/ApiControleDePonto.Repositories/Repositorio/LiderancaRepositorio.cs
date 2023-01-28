using ApiControleDePonto.Domain.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiControleDePonto.Repositories.Repositorio
{
    public class LiderancaRepositorio : Contexto
    {
        public LiderancaRepositorio(IConfiguration configuration) : base(configuration)
        {
        }
        public void Inserir(Lideranca model)
        {
            string comandoSql = @"INSERT INTO Liderancas
                                    (FuncionarioId,DescricaoEquipe) 
                                        VALUES
                                    (@FuncionarioId,@DescricaoEquipe);";

            using (var cmd = new SqlCommand(comandoSql, _conn))
            {
                cmd.Parameters.AddWithValue("@FuncionarioId", model.FuncionarioId);
                cmd.Parameters.AddWithValue("@DescricaoEquipe", model.DescricaoEquipe);
                cmd.ExecuteNonQuery();
            }
        }

        public void Atualizar(Lideranca model)
        {
            string comandoSql = @"UPDATE Liderancas 
                                SET 
                                    FuncionarioId = @FuncionarioId,
                                    DescricaoEquipe = @DescricaoEquipe
                                WHERE LiderancaId = @LiderancaId;";

            using (var cmd = new SqlCommand(comandoSql, _conn))
            {
                cmd.Parameters.AddWithValue("@LiderancaId", model.LiderancaId);
                cmd.Parameters.AddWithValue("@FuncionarioId", model.FuncionarioId);
                cmd.Parameters.AddWithValue("@DescricaoEquipe", model.DescricaoEquipe);
                if (cmd.ExecuteNonQuery() == 0)
                    throw new InvalidOperationException($"Nenhum registro afetado para o Lideranca de ID {model.LiderancaId}");
            }
        }
        public bool SeExiste(int LiderancaId)
        {
            string comandoSql = @"SELECT COUNT(LiderancaId) as total FROM Liderancas WHERE LiderancaId = @LiderancaId";

            using (var cmd = new SqlCommand(comandoSql, _conn))
            {
                cmd.Parameters.AddWithValue("@LiderancaId", LiderancaId);
                return Convert.ToBoolean(cmd.ExecuteScalar());
            }
        }
        public Lideranca? Obter(int LiderancaId)
        {
            string comandoSql = @"SELECT LiderancaId,FuncionarioId,DescricaoEquipe FROM Liderancas WHERE LiderancaId = @LiderancaId";

            using (var cmd = new SqlCommand(comandoSql, _conn))
            {
                cmd.Parameters.AddWithValue("@LiderancaId", LiderancaId);

                using (var rdr = cmd.ExecuteReader())
                {
                    if (rdr.Read())
                    {
                        var Lideranca = new Lideranca();
                        Lideranca.LiderancaId = LiderancaId;
                        Lideranca.FuncionarioId = Convert.ToInt32(rdr["FuncionarioId"]);
                        Lideranca.DescricaoEquipe = Convert.ToString(rdr["DescricaoEquipe"]);
                        return Lideranca;
                    }
                    else
                        return null;
                }
            }
        }
        public List<Lideranca> ListarLiderancas(string? descricaoEquipe)
        {
            string comandoSql = @"SELECT LiderancaId,FuncionarioId,DescricaoEquipe FROM Liderancas";

            if (!string.IsNullOrWhiteSpace(descricaoEquipe))
                comandoSql += " WHERE DescricaoEquipe LIKE @DescricaoEquipe";

            using (var cmd = new SqlCommand(comandoSql, _conn))
            {
                if (!string.IsNullOrWhiteSpace(descricaoEquipe))
                    cmd.Parameters.AddWithValue("@DescricaoEquipe", "%" + descricaoEquipe + "%");

                using (var rdr = cmd.ExecuteReader())
                {
                    var Liderancas = new List<Lideranca>();
                    while (rdr.Read())
                    {
                        var Lideranca = new Lideranca();
                        Lideranca.LiderancaId = Convert.ToInt32(rdr["LiderancaId"]);
                        Lideranca.FuncionarioId = Convert.ToInt32(rdr["FuncionarioId"]);                      
                        Lideranca.DescricaoEquipe = Convert.ToString(rdr["DescricaoEquipe"]);
                        Liderancas.Add(Lideranca);
                    }
                    return Liderancas;
                }
            }
        }
        public void Deletar(int LiderancaId)
        {
            string comandoSql = @"DELETE FROM Liderancas 
                                WHERE LiderancaId = @LiderancaId;";

            using (var cmd = new SqlCommand(comandoSql, _conn))
            {
                cmd.Parameters.AddWithValue("@LiderancaId", LiderancaId);
                if (cmd.ExecuteNonQuery() == 0)
                    throw new InvalidOperationException($"Nenhum registro afetado para o Lideranca ID informado {LiderancaId}");
            }
        }
    }
}
