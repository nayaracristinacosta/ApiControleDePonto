using ApiControleDePonto.Domain.Models;
using ApiControleDePonto.Repositories.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiControleDePonto.Services
{
    public class LiderancaService
    {
        private readonly LiderancaRepositorio _repositorio;
        public LiderancaService()
        {
            _repositorio = new LiderancaRepositorio();
        }

        public List<Lideranca> Listar(string? descricaoEquipe)
        {
            try
            {
                _repositorio.AbrirConexao();
                return _repositorio.ListarLiderancas(descricaoEquipe);
            }
            finally
            {
                _repositorio.FecharConexao();
            }
        }
        public Lideranca Obter(int LiderancaId)
        {
            try
            {
                _repositorio.AbrirConexao();
                _repositorio.SeExiste(LiderancaId);
                return _repositorio.Obter(LiderancaId);
            }
            finally
            {
                _repositorio.FecharConexao();
            }
        }
        public void Atualizar(Lideranca model)
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
        public void Deletar(int LiderancaId)
        {
            try
            {
                _repositorio.AbrirConexao();
                _repositorio.Deletar(LiderancaId);
            }
            finally
            {
                _repositorio.FecharConexao();
            }
        }
        public void Inserir(Lideranca model)
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
