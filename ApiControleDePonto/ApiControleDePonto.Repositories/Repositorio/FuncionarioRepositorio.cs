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
    public class FuncionarioRepositorio : Contexto
    {
        public FuncionarioRepositorio(IConfiguration configuration) : base(configuration)
        {
        }
        public Funcionario? ObterFuncionarioPorCredenciais(string email, string senha)
        {
            string comandoSql = @"SELECT u.EmailFuncionario, u.NomeDoFuncionario, u.CargoId FROM Funcionarios u
                                    JOIN Cargos c ON u.CargoId = c.CargoId
                                    WHERE u.EmailFuncionario = @EmailFuncionario AND u.SenhaFuncionario = @SenhaFuncionario";

            using (var cmd = new SqlCommand(comandoSql, _conn))
            {
                cmd.Parameters.AddWithValue("@EmailFuncionario", email);
                cmd.Parameters.AddWithValue("@SenhaFuncionario", senha);

                using (var rdr = cmd.ExecuteReader())
                {
                    if (rdr.Read())
                    {
                        return new Funcionario()
                        {   
                            NomeDoFuncionario = rdr["NomeDoFuncionario"].ToString(),
                            EmailFuncionario = rdr["EmailFuncionario"].ToString(),
                            CargoId = Convert.ToInt32(rdr["CargoId"])
                        };
                    }
                    else
                        return null;
                }
            }
        }
        public void Inserir(Funcionario model)
        {
            string comandoSql = @"INSERT INTO Funcionarios
                                    (NomeDoFuncionario,Cpf,NascimentoFuncionario,DataDeAdmissao,CelularFuncionario,EmailFuncionario,SenhaFuncionario,CargoId) 
                                        VALUES
                                    (@NomeDoFuncionario,@Cpf,@NascimentoFuncionario,@DataDeAdmissao,@CelularFuncionario,@EmailFuncionario,@SenhaFuncionario,@CargoId);";

            using (var cmd = new SqlCommand(comandoSql, _conn))
            {
                cmd.Parameters.AddWithValue("@NomeDoFuncionario", model.NomeDoFuncionario);
                cmd.Parameters.AddWithValue("@Cpf", model.Cpf);
                cmd.Parameters.AddWithValue("@NascimentoFuncionario", model.NascimentoFuncionario); 
                cmd.Parameters.AddWithValue("@DataDeAdmissao", model.DataDeAdmissao); 
                cmd.Parameters.AddWithValue("@CelularFuncionario", model.CelularFuncionario);
                cmd.Parameters.AddWithValue("@EmailFuncionario", model.EmailFuncionario);
                cmd.Parameters.AddWithValue("@SenhaFuncionario", model.SenhaFuncionario);
                cmd.Parameters.AddWithValue("@CargoId", model.CargoId);
                cmd.ExecuteNonQuery();
            }
        }

        public void Atualizar(Funcionario model)
        {
            string comandoSql = @"UPDATE Funcionarios 
                                SET 
                                    NomeDoFuncionario = @NomeDoFuncionario,
                                    Cpf = @Cpf,
                                    NascimentoFuncionario = @NascimentoFuncionario,
                                    DataDeAdmissao = @DataDeAdmissao,
                                    CelularFuncionario = @CelularFuncionario,
                                    EmailFuncionario = @EmailFuncionario,
                                    SenhaFuncionario = @SenhaFuncionario,
                                    CargoId = @CargoId
                                WHERE FuncionarioId = @FuncionarioId;";

            using (var cmd = new SqlCommand(comandoSql, _conn))
            {
                cmd.Parameters.AddWithValue("@FuncionarioId", model.FuncionarioId);
                cmd.Parameters.AddWithValue("@NomeDoFuncionario", model.NomeDoFuncionario);
                cmd.Parameters.AddWithValue("@Cpf", model.Cpf);
                cmd.Parameters.AddWithValue("@NascimentoFuncionario", model.NascimentoFuncionario);
                cmd.Parameters.AddWithValue("@DataDeAdmissao", model.DataDeAdmissao);
                cmd.Parameters.AddWithValue("@CelularFuncionario", model.CelularFuncionario);
                cmd.Parameters.AddWithValue("@EmailFuncionario", model.EmailFuncionario);
                cmd.Parameters.AddWithValue("@SenhaFuncionario", model.SenhaFuncionario);
                cmd.Parameters.AddWithValue("@CargoId", model.CargoId);
                if (cmd.ExecuteNonQuery() == 0)
                    throw new InvalidOperationException($"Nenhum registro afetado para o Funcionario de ID {model.FuncionarioId}");
            }
        }
        public bool SeExiste(int FuncionarioId)
        {
            string comandoSql = @"SELECT COUNT(FuncionarioId) as total FROM Funcionarios WHERE FuncionarioId = @FuncionarioId";

            using (var cmd = new SqlCommand(comandoSql, _conn))
            {
                cmd.Parameters.AddWithValue("@FuncionarioId", FuncionarioId);
                return Convert.ToBoolean(cmd.ExecuteScalar());
            }
        }
        public Funcionario? Obter(int FuncionarioId)
        {
            string comandoSql = @"SELECT NomeDoFuncionario,
                                         Cpf,
                                         NascimentoFuncionario,         
                                         DataDeAdmissao,    
                                         CelularFuncionario,
                                         EmailFuncionario,
                                         SenhaFuncionario, 
                                         CargoId FROM Funcionarios WHERE FuncionarioId = @FuncionarioId";

            using (var cmd = new SqlCommand(comandoSql, _conn))
            {
                cmd.Parameters.AddWithValue("@FuncionarioId", FuncionarioId);

                using (var rdr = cmd.ExecuteReader())
                {
                    if (rdr.Read())
                    {
                        var Funcionario = new Funcionario();
                        Funcionario.FuncionarioId = FuncionarioId;
                        Funcionario.NomeDoFuncionario = Convert.ToString(rdr["NomeDoFuncionario"]);
                        Funcionario.Cpf = Convert.ToString(rdr["Cpf"]);
                        Funcionario.NascimentoFuncionario = Convert.ToDateTime(rdr["NascimentoFuncionario"]);
                        Funcionario.DataDeAdmissao = Convert.ToDateTime(rdr["DataDeAdmissao"]);
                        Funcionario.CelularFuncionario = Convert.ToString(rdr["CelularFuncionario"]);
                        Funcionario.EmailFuncionario = Convert.ToString(rdr["EmailFuncionario"]);
                        Funcionario.CargoId = Convert.ToInt32(rdr["CargoId"]);
                        return Funcionario;
                    }
                    else
                        return null;
                }
            }
        }
        public List<Funcionario> ListarFuncionarios(string? nomeDoFuncionario)
        {
            string comandoSql = @"SELECT NomeDoFuncionario,
                                         Cpf,
                                         NascimentoFuncionario,         
                                         DataDeAdmissao,    
                                         CelularFuncionario,
                                         EmailFuncionario,
                                         SenhaFuncionario, 
                                         CargoId FROM Funcionarios";

            if (!string.IsNullOrWhiteSpace(nomeDoFuncionario))
                comandoSql += " WHERE NomeDoFuncionario LIKE @NomeDoFuncionario";

            using (var cmd = new SqlCommand(comandoSql, _conn))
            {
                if (!string.IsNullOrWhiteSpace(nomeDoFuncionario))
                    cmd.Parameters.AddWithValue("@nomeDoFuncionario", "%" + nomeDoFuncionario + "%");

                using (var rdr = cmd.ExecuteReader())
                {
                    var Funcionarios = new List<Funcionario>();
                    while (rdr.Read())
                    {
                        var Funcionario = new Funcionario();                        
                        Funcionario.NomeDoFuncionario = Convert.ToString(rdr["NomeDoFuncionario"]);
                        Funcionario.Cpf = Convert.ToString(rdr["Cpf"]);
                        Funcionario.NascimentoFuncionario = Convert.ToDateTime(rdr["NascimentoFuncionario"]);
                        Funcionario.DataDeAdmissao = Convert.ToDateTime(rdr["DataDeAdmissao"]);
                        Funcionario.CelularFuncionario = Convert.ToString(rdr["CelularFuncionario"]);
                        Funcionario.EmailFuncionario = Convert.ToString(rdr["EmailFuncionario"]);
                        Funcionario.CargoId = Convert.ToInt32(rdr["CargoId"]);
                        Funcionarios.Add(Funcionario);
                    }
                    return Funcionarios;
                }
            }
        }
        public void Deletar(int FuncionarioId)
        {
            string comandoSql = @"DELETE FROM Funcionarios 
                                WHERE FuncionarioId = @FuncionarioId;";

            using (var cmd = new SqlCommand(comandoSql, _conn))
            {
                cmd.Parameters.AddWithValue("@FuncionarioId", FuncionarioId);
                if (cmd.ExecuteNonQuery() == 0)
                    throw new InvalidOperationException($"Nenhum registro afetado para o Funcionario ID informado {FuncionarioId}");
            }
        }
    }
}
