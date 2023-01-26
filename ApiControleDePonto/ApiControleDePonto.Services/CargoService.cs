using ApiControleDePonto.Domain.Models;
using ApiControleDePonto.Repositories.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiControleDePonto.Services
{
    public class CargoService
    {
        private readonly CargoRepositorio _repositorio;
        public CargoService()
        {
            _repositorio = new CargoRepositorio();
        }

        public List<Cargo> Listar(string? descricao)
        {
            try
            {
                _repositorio.AbrirConexao();
                return _repositorio.ListarCargos(descricao);
            }
            finally
            {
                _repositorio.FecharConexao();
            }
        }
        public Cargo Obter(int cargoId)
        {
            try
            {
                _repositorio.AbrirConexao();
                _repositorio.SeExiste(cargoId);
                return _repositorio.Obter(cargoId);
            }
            finally
            {
                _repositorio.FecharConexao();
            }
        }
        public void Atualizar(Cargo model)
        {
            try
            {        
                _repositorio.AbrirConexao();
                _repositorio.Atualizar(model);
            }
            finally
            {
                _repositorio.FecharConexao();
            }
        }
        public void Deletar(int CargoId)
        {
            try
            {
                _repositorio.AbrirConexao();
                _repositorio.Deletar(CargoId);
            }
            finally
            {
                _repositorio.FecharConexao();
            }
        }
        public void Inserir(Cargo model)
        {
            try
            {              
                _repositorio.AbrirConexao();
                _repositorio.Inserir(model);
            }
            finally
            {
                _repositorio.FecharConexao();
            }
        }
    }
}
