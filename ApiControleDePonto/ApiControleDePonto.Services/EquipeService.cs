using ApiControleDePonto.Domain.Exceptions;
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
        public EquipeService(EquipeRepositorio repositorio)
        {
            _repositorio = repositorio;
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
                ValidarModelEquipe(model);
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
                ValidarModelEquipe(model);
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
        private static void ValidarModelEquipe(Equipe model, bool isUpdate = false)
        {
            if (model is null)
                throw new ValidacaoException("O json está mal formatado, ou foi enviado vazio.");

            if (model.LiderancaId <= 0)
                throw new ValidacaoException("É necessário informar o ID do Líder, gentileza informar para inclusão.");

            if (model.FuncionarioId <= 0)
                throw new ValidacaoException("É necessário informar o ID do Funcionário, gentileza informar para inclusão.");

        }
    }
    
}
