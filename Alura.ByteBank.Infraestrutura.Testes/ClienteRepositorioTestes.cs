using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Entidades;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.ByteBank.Infraestrutura.Testes
{
    public class ClienteRepositorioTestes
    {
        private readonly IClienteRepositorio _repositorio;
        public ClienteRepositorioTestes()
        {
            var service = new ServiceCollection();
            service.AddTransient<IClienteRepositorio, ClienteRepositorio>();
            var provedor = service.BuildServiceProvider();
            this._repositorio = provedor.GetService<IClienteRepositorio>();
        }

        [Fact]
        public void TestObterTodosClientes()
        {

            List<Cliente> lista = this._repositorio.ObterTodos();

            Assert.NotNull(lista);
            Assert.Equal(3, lista.Count);
        }

        [Fact]
        public void TestaObterClientePorId()
        {
            var cliente = this._repositorio.ObterPorId(1);
            Assert.NotNull(cliente);
        }

    }
}
