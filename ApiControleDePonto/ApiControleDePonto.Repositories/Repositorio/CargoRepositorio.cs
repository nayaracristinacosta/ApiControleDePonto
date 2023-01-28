using ApiControleDePonto.Domain.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ApiControleDePonto.Repositories.Repositorio
{
    
    public class CargoRepositorio : Contexto
    {
        public CargoRepositorio(IConfiguration configuration) : base(configuration)
        {
        }
        public void Inserir(Cargo model)
        {
            string comandoSql = @"INSERT INTO Cargos
                                    (Descricao) 
                                        VALUES
                                    (@Descricao);";

            using (var cmd = new SqlCommand(comandoSql, _conn))
            {
                cmd.Parameters.AddWithValue("@Descricao", model.Descricao);         
                cmd.ExecuteNonQuery();
            }
        }

        public void Atualizar(Cargo model)
        {
            string comandoSql = @"UPDATE Cargos 
                                SET 
                                    Descricao = @Descricao                                
                                WHERE CargoId = @CargoId;";

            using (var cmd = new SqlCommand(comandoSql, _conn))
            {
                cmd.Parameters.AddWithValue("@CargoId", model.CargoId);
                cmd.Parameters.AddWithValue("@Descricao", model.Descricao);
                if (cmd.ExecuteNonQuery() == 0)
                    throw new InvalidOperationException($"Nenhum registro afetado para o Cargo de ID {model.CargoId}");
            }
        }
        public bool SeExiste(int cargoId)
        {
            string comandoSql = @"SELECT COUNT(CargoId) as total FROM Cargos WHERE CargoId = @CargoId";

            using (var cmd = new SqlCommand(comandoSql, _conn))
            {
                cmd.Parameters.AddWithValue("@CargoId", cargoId);
                return Convert.ToBoolean(cmd.ExecuteScalar());
            }
        }
        public Cargo? Obter(int CargoId)
        {
            string comandoSql = @"SELECT Descricao FROM Cargos WHERE CargoId = @CargoId";

            using (var cmd = new SqlCommand(comandoSql, _conn))
            {
                cmd.Parameters.AddWithValue("@CargoId", CargoId);

                using (var rdr = cmd.ExecuteReader())
                {
                    if (rdr.Read())
                    {
                        var Cargo = new Cargo();
                        Cargo.CargoId = CargoId;
                        Cargo.Descricao = Convert.ToString(rdr["Descricao"]);                   
                        return Cargo;
                    }
                    else
                        return null;
                }
            }
        }
        public List<Cargo> ListarCargos(string? descricao)
        {
            string comandoSql = @"SELECT Descricao FROM Cargos";

            if (!string.IsNullOrWhiteSpace(descricao))
                comandoSql += " WHERE descricao LIKE @descricao";

            using (var cmd = new SqlCommand(comandoSql, _conn))
            {
                if (!string.IsNullOrWhiteSpace(descricao))
                    cmd.Parameters.AddWithValue("@descricao", "%" + descricao + "%");

                using (var rdr = cmd.ExecuteReader())
                {
                    var Cargos = new List<Cargo>();
                    while (rdr.Read())
                    {
                        var Cargo = new Cargo();                        
                        Cargo.Descricao = Convert.ToString(rdr["Descricao"]);
                        Cargos.Add(Cargo);
                    }
                    return Cargos;
                }
            }
        }
        public void Deletar(int CargoId)
        {
            string comandoSql = @"DELETE FROM Cargos 
                                WHERE CargoId = @CargoId;";

            using (var cmd = new SqlCommand(comandoSql, _conn))
            {
                cmd.Parameters.AddWithValue("@CargoId", CargoId);
                if (cmd.ExecuteNonQuery() == 0)
                    throw new InvalidOperationException($"Nenhum registro afetado para o Cargo ID informado {CargoId}");
            }
        }
    }
}
