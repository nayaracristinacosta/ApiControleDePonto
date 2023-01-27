using ApiControleDePonto.Domain.Models;
using ApiControleDePonto.Repositories.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiControleDePonto.Services
{
    public class EquipeService
    {
        private readonly EquipeRepositorio _repositorio;
        public EquipeService()
        {
            _repositorio = new EquipeRepositorio();
        }

        public List<Equipe> Listar(int descricao)
        {
            try
            {
                _repositorio.AbrirConexao();
                return _repositorio.Listar(descricao);
            }
            finally
            {
                _repositorio.FecharConexao();
            }
        }
        public Equipe Obter(int EquipeId)
        {
            try
            {
                _repositorio.AbrirConexao();
                _repositorio.SeExiste(EquipeId);
                return _repositorio.Obter(EquipeId);
            }
            finally
            {
                _repositorio.FecharConexao();
            }
        }
        public void Atualizar(Equipe model)
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
        public void Deletar(int EquipeId)
        {
            try
            {
                _repositorio.AbrirConexao();
                _repositorio.Deletar(EquipeId);
            }
            finally
            {
                _repositorio.FecharConexao();
            }
        }
        public void Inserir(Equipe model)
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

        public void InserirFuncionario(Equipe model)
        {
            try
            {
                _repositorio.AbrirConexao();
                _repositorio.InserirFuncionarioEmUmaEquipe(model);
            }
            finally
            {
                _repositorio.FecharConexao();
            }
        }
    }
}
