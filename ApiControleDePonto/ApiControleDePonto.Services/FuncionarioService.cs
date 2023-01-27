using ApiControleDePonto.Domain.Models;
using ApiControleDePonto.Repositories.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiControleDePonto.Services
{
    public class FuncionarioService
    {
        private readonly FuncionarioRepositorio _repositorio;
        public FuncionarioService()
        {
            _repositorio = new FuncionarioRepositorio();
        }

        public List<Funcionario> Listar(string? nomeDoFuncionario)
        {
            try
            {
                _repositorio.AbrirConexao();
                return _repositorio.ListarFuncionarios(nomeDoFuncionario);
            }
            finally
            {
                _repositorio.FecharConexao();
            }
        }
        public Funcionario Obter(int funcionarioId)
        {
            try
            {
                _repositorio.AbrirConexao();
                _repositorio.SeExiste(funcionarioId);
                return _repositorio.Obter(funcionarioId);
            }
            finally
            {
                _repositorio.FecharConexao();
            }
        }
        public void Atualizar(Funcionario model)
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
        public void Deletar(int FuncionarioId)
        {
            try
            {
                _repositorio.AbrirConexao();
                _repositorio.Deletar(FuncionarioId);
            }
            finally
            {
                _repositorio.FecharConexao();
            }
        }
        public void Inserir(Funcionario model)
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
