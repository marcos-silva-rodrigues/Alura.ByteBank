using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Entidades;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.ByteBank.Infraestrutura.Testes
{
    public class ContaCorrenteTestes
    {
        private readonly IContaCorrenteRepositorio _repositorio;
        public ContaCorrenteTestes()
        {
            var service = new ServiceCollection();
            service.AddTransient<IContaCorrenteRepositorio, ContaCorrenteRepositorio
                >();
            var provedor = service.BuildServiceProvider();
            this._repositorio = provedor.GetService<IContaCorrenteRepositorio>();
        }


        [Fact]
        public void TestaAtualizaSaldoDeterminadoConta()
        {
            var conta = this._repositorio.ObterPorId(1);
            double saldoNovo = 15;
            conta.Saldo = saldoNovo;

            var atualizado = _repositorio.Atualizar(1, conta);

            Assert.True(atualizado);

        }

        [Fact]
        public void TestaInsererUmaNovaContaCorrente()
        {
            var conta = new ContaCorrente()
            {
                Saldo = 10,
                Identificador = Guid.NewGuid(),
                Cliente = new Cliente()
                {
                    Nome = "Kent nelson",
                    CPF = "123.123.123-13",
                    Identificador = Guid.NewGuid(),
                    Profissao = "Bancário",
                    Id = 1,
                },
                Agencia = new Agencia()
                {
                    Nome = "Agencia Central Coast City",
                    Identificador = Guid.NewGuid(),
                    Id = 1,
                    Endereco = "Rua das Flores, 23",
                    Numero = 123
                }
            };

            var retorno = _repositorio.Adicionar(conta);
            Assert.True(retorno);
        }
    }
}
