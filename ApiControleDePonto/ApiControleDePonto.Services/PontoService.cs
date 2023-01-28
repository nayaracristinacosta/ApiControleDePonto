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
    public class PontoService
    {
        private readonly PontoRepositorio _repositorio;
        public PontoService(PontoRepositorio repositorio)
        {
            _repositorio = repositorio;
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
                ValidarModelPonto(model);
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
                ValidarModelPonto(model);
                _repositorio.AbrirConexao();
                _repositorio.Inserir(model);
            }
            finally
            {
                _repositorio.FecharConexao();
            }
        }

        private static void ValidarModelPonto(Ponto model, bool isUpdate = false)
        {
            if (model is null)
                throw new ValidacaoException("O json está mal formatado, ou foi enviado vazio.");

            if (model.DataHorarioPonto > DateTime.Now.AddSeconds(-1))           
            throw new ValidacaoException("Hora invalida");

            if (model.Justificativa.Trim().Length < 3 || model.Justificativa.Trim().Length > 255)
                throw new ValidacaoException("A Justificativa do Ponto precisa ter entre 3 a 255 caracteres.");


        }
    }
}
