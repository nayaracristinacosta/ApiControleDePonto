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
    public class PontoRepositorio : Contexto
    {
        public PontoRepositorio(IConfiguration configuration) : base(configuration)
        {
        }
        public void Inserir(Ponto model)
            {
                string comandoSql = @"INSERT INTO Ponto
                                    (DataHorarioPonto,Justificativa,FuncionarioId) 
                                        VALUES
                                    (@DataHorarioPonto,@Justificativa,@FuncionarioId);";

                using (var cmd = new SqlCommand(comandoSql, _conn))
                {
                    cmd.Parameters.AddWithValue("@DataHorarioPonto", model.DataHorarioPonto);
                    cmd.Parameters.AddWithValue("@Justificativa", model.Justificativa);
                    cmd.Parameters.AddWithValue("@FuncionarioId", model.FuncionarioId);
                    cmd.ExecuteNonQuery();
                }
            }

            public void Atualizar(Ponto model)
            {
                string comandoSql = @"UPDATE Ponto
                                SET 
                                    DataHorarioPonto = @DataHorarioPonto,
                                    Justificativa = @Justificativa                                    
                                WHERE PontoId = @PontoId;";

                using (var cmd = new SqlCommand(comandoSql, _conn))
                {
                    cmd.Parameters.AddWithValue("@PontoId", model.PontoId);
                    cmd.Parameters.AddWithValue("@DataHorarioPonto", model.DataHorarioPonto);
                    cmd.Parameters.AddWithValue("@Justificativa", model.Justificativa);                   
                if (cmd.ExecuteNonQuery() == 0)
                        throw new InvalidOperationException($"Nenhum registro afetado para o Ponto de ID {model.PontoId}");
                }
            }
            public bool SeExiste(int PontoId)
            {
                string comandoSql = @"SELECT COUNT(PontoId) as total FROM Ponto WHERE PontoId = @PontoId";

                using (var cmd = new SqlCommand(comandoSql, _conn))
                {
                    cmd.Parameters.AddWithValue("@PontoId", PontoId);
                    return Convert.ToBoolean(cmd.ExecuteScalar());
                }
            }
            public Ponto? Obter(int PontoId)
            {
                string comandoSql = @"SELECT DataHorarioPonto,Justificativa,FuncionarioId FROM Ponto WHERE PontoId = @PontoId";

                using (var cmd = new SqlCommand(comandoSql, _conn))
                {
                    cmd.Parameters.AddWithValue("@PontoId", PontoId);

                    using (var rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            var Ponto = new Ponto();
                            Ponto.PontoId = PontoId;
                            Ponto.DataHorarioPonto = Convert.ToDateTime(rdr["DataHorarioPonto"]);
                            Ponto.Justificativa = Convert.ToString(rdr["Justificativa"]);
                            Ponto.FuncionarioId = Convert.ToInt32(rdr["FuncionarioId"]);
                        return Ponto;
                        }
                        else
                            return null;
                    }
                }
            }
        public List<Ponto> Listar(int FuncionarioId)
        {
            string comandoSql = @"SELECT DataHorarioPonto,Justificativa,FuncionarioId FROM Ponto WHERE FuncionarioId = @FuncionarioId";

            using (var cmd = new SqlCommand(comandoSql, _conn))
            {
                cmd.Parameters.AddWithValue("@FuncionarioId", FuncionarioId);

                using (var rdr = cmd.ExecuteReader())
                {
                    var Pontos = new List<Ponto>();
                    while (rdr.Read())
                    {
                        var Ponto = new Ponto();
                        Ponto.DataHorarioPonto = Convert.ToDateTime(rdr["DataHorarioPonto"]);
                        Ponto.Justificativa = Convert.ToString(rdr["Justificativa"]);
                        Ponto.FuncionarioId = Convert.ToInt32(rdr["FuncionarioId"]);
                        Pontos.Add(Ponto);
                    }
                    return Pontos;
                }
            }
        }
        public void Deletar(int PontoId)
            {
                string comandoSql = @"DELETE FROM Ponto
                                WHERE PontoId = @PontoId;";

                using (var cmd = new SqlCommand(comandoSql, _conn))
                {
                    cmd.Parameters.AddWithValue("@PontoId", PontoId);
                    if (cmd.ExecuteNonQuery() == 0)
                        throw new InvalidOperationException($"Nenhum registro afetado para o Ponto ID informado {PontoId}");
                }
            }
        }
}
