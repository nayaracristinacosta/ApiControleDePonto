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
    public class LiderancaService
    {
        private readonly LiderancaRepositorio _repositorio;
        public LiderancaService(LiderancaRepositorio repositorio)
        {
            _repositorio = repositorio;
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
                ValidarModelLideranca(model);
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
                ValidarModelLideranca(model);
                _repositorio.AbrirConexao();
                _repositorio.Inserir(model);
            }
            finally
            {
                _repositorio.FecharConexao();
            }
        }
        private static void ValidarModelLideranca(Lideranca model, bool isUpdate = false)
        {
            if (model is null)
                throw new ValidacaoException("O json está mal formatado, ou foi enviado vazio.");

            if (model.DescricaoEquipe.Trim().Length < 3 || model.DescricaoEquipe.Trim().Length > 255)
                throw new ValidacaoException("O Descrição da Equipe precisa ter entre 3 a 255 caracteres.");

            if (model.FuncionarioId <= 0)
                throw new ValidacaoException("É necessário informar o ID do Funcionário, gentileza informar para inclusão.");
        }
    }
}
