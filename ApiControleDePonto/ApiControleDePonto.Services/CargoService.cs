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
    public class CargoService
    {
        private readonly CargoRepositorio _repositorio;
        public CargoService(CargoRepositorio repositorio)
        {
            _repositorio = repositorio;
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
                ValidarModelCargo(model);
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
                ValidarModelCargo(model);
                _repositorio.AbrirConexao();
                _repositorio.Inserir(model);
            }
            finally
            {
                _repositorio.FecharConexao();
            }
        }
        private static void ValidarModelCargo(Cargo model, bool isUpdate = false)
        {
            if (model is null)
                throw new ValidacaoException("O json está mal formatado, ou foi enviado vazio.");

            if (model.Descricao.Trim().Length < 3 || model.Descricao.Trim().Length > 255)
                throw new ValidacaoException("A Descrição do Cargo precisa ter entre 3 a 255 caracteres.");

        }
    }
}
