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
    public class EquipeRepositorio : Contexto
    {
        public EquipeRepositorio(IConfiguration configuration) : base(configuration)
        {
        }
        public void Inserir(Equipe model)
        {
            string comandoSql = @"INSERT INTO Equipes
                                    (LiderancaId,FuncionarioId) 
                                        VALUES
                                    (@LiderancaId,@FuncionarioId);";

            using (var cmd = new SqlCommand(comandoSql, _conn))
            {
                cmd.Parameters.AddWithValue("@LiderancaId", model.LiderancaId);
                cmd.Parameters.AddWithValue("@FuncionarioId", model.FuncionarioId);              
                cmd.ExecuteNonQuery();
            }
        }

        public void InserirFuncionarioEmUmaEquipe(Equipe model)
        {
            string comandoSql = @"INSERT INTO Equipes
                                    (FuncionarioId) 
                                        VALUES
                                    (@LiderancaId,@LiderancaId);";

            using (var cmd = new SqlCommand(comandoSql, _conn))
            {
                cmd.Parameters.AddWithValue("@LiderancaId", model.LiderancaId);
                cmd.Parameters.AddWithValue("@FuncionarioId", model.FuncionarioId);
                cmd.ExecuteNonQuery();
            }
        }

        public void Atualizar(Equipe model)
        {
            string comandoSql = @"UPDATE Equipes
                                SET 
                                    LiderancaId = @LiderancaId,
                                    FuncionarioId = @FuncionarioId                                    
                                WHERE EquipeId = @EquipeId;";

            using (var cmd = new SqlCommand(comandoSql, _conn))
            {
                cmd.Parameters.AddWithValue("@EquipeId", model.EquipeId);
                cmd.Parameters.AddWithValue("@DataHorarioEquipe", model.LiderancaId);
                cmd.Parameters.AddWithValue("@Justificativa", model.FuncionarioId);
                if (cmd.ExecuteNonQuery() == 0)
                    throw new InvalidOperationException($"Nenhum registro afetado para o Equipe de ID {model.EquipeId}");
            }
        }
        public bool SeExiste(int EquipeId)
        {
            string comandoSql = @"SELECT COUNT(EquipeId) as total FROM Equipes WHERE EquipeId = @EquipeId";

            using (var cmd = new SqlCommand(comandoSql, _conn))
            {
                cmd.Parameters.AddWithValue("@EquipeId", EquipeId);
                return Convert.ToBoolean(cmd.ExecuteScalar());
            }
        }
        public Equipe? Obter(int EquipeId)
        {
            string comandoSql = @"SELECT EquipeId ,LiderancaId,FuncionarioId FROM Equipes WHERE EquipeId = @EquipeId";

            using (var cmd = new SqlCommand(comandoSql, _conn))
            {
                cmd.Parameters.AddWithValue("@EquipeId", EquipeId);

                using (var rdr = cmd.ExecuteReader())
                {
                    if (rdr.Read())
                    {
                        var Equipe = new Equipe();
                        Equipe.EquipeId = EquipeId;
                        Equipe.LiderancaId = Convert.ToInt32(rdr["DataHorarioEquipe"]);
                        Equipe.FuncionarioId = Convert.ToInt32(rdr["Justificativa"]);
                        return Equipe;
                    }
                    else
                        return null;
                }
            }
        }
        public List<Equipe> Listar(int liderancaId)
        {
            string comandoSql = @"SELECT EquipeId ,LiderancaId,FuncionarioId FROM Equipes WHERE LiderancaId = @LiderancaId";

            using (var cmd = new SqlCommand(comandoSql, _conn))
            {
                cmd.Parameters.AddWithValue("@LiderancaId", liderancaId);

                using (var rdr = cmd.ExecuteReader())
                {
                    var Equipes = new List<Equipe>();
                    while (rdr.Read())
                    {
                        var Equipe = new Equipe();
                        Equipe.EquipeId = Convert.ToInt32(rdr["DataHorarioEquipe"]);
                        Equipe.LiderancaId = Convert.ToInt32(rdr["Justificativa"]);
                        Equipe.FuncionarioId = Convert.ToInt32(rdr["FuncionarioId"]);
                        Equipes.Add(Equipe);
                    }
                    return Equipes;
                }
            }
        }
        public void Deletar(int EquipeId)
        {
            string comandoSql = @"DELETE FROM Equipe
                                WHERE EquipeId = @EquipeId;";

            using (var cmd = new SqlCommand(comandoSql, _conn))
            {
                cmd.Parameters.AddWithValue("@EquipeId", EquipeId);
                if (cmd.ExecuteNonQuery() == 0)
                    throw new InvalidOperationException($"Nenhum registro afetado para o Equipe ID informado {EquipeId}");
            }
        }
    }
}  