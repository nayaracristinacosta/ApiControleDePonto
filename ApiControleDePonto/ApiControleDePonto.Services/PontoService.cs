using ApiControleDePonto.Domain.Models;
using ApiControleDePonto.Repositories.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiControleDePonto.Services
{
    public class PontoService
    {
        private readonly PontoRepositorio _repositorio;
        public PontoService()
        {
            _repositorio = new PontoRepositorio();
        }

        public List<Ponto> Listar(int funcionarioId)
        {
            try
            {
                _repositorio.AbrirConexao();
                return _repositorio.Listar(funcionarioId);
            }
            finally
            {
                _repositorio.FecharConexao();
            }
        }
        public Ponto Obter(int PontoId)
        {
            try
            {
                _repositorio.AbrirConexao();
                _repositorio.SeExiste(PontoId);
                return _repositorio.Obter(PontoId);
            }
            finally
            {
                _repositorio.FecharConexao();
            }
        }
        public void Atualizar(Ponto model)
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
        public void Deletar(int PontoId)
        {
            try
            {
                _repositorio.AbrirConexao();
                _repositorio.Deletar(PontoId);
            }
            finally
            {
                _repositorio.FecharConexao();
            }
        }
        public void Inserir(Ponto model)
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
