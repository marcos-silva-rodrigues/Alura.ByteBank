using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Entidades;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Alura.ByteBank.Infraestrutura.Testes.Servicos;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.ByteBank.Infraestrutura.Testes
{
    public class AgenciaRepositorioTestes
    {

        private readonly IAgenciaRepositorio _repositorio;
        public AgenciaRepositorioTestes()
        {
            var service = new ServiceCollection();
            service.AddTransient<IAgenciaRepositorio, AgenciaRepositorio>();
            var provedor = service.BuildServiceProvider();
            this._repositorio = provedor.GetService<IAgenciaRepositorio>();
       
        }

        [Fact]
        public void TestaExcecaoConsultaPorAgenciaPorId()
        {
            Assert.Throws<Exception>(
                () => _repositorio.ObterPorId(33)
            );
        }

        [Fact]
        public void TestaAdiconarAgenciaMock()
        {
            // Arrange
            var agencia = new Agencia()
            {
                Nome = "Agência Amaral",
                Identificador = Guid.NewGuid(),
                Id = 4,
                Endereco = "Rua Arthur Costa",
                Numero = 6497
            };

            var repositorioMock = new ByteBankRepositorio();
            //Act
            var adicionado = repositorioMock.AdicionarAgencia(agencia);

            Assert.True(adicionado);
        }

        [Fact]
        public void TestaObterAgenciaMock()
        {
            var bytebankRespoistorio = new Mock<IByteBankRepositorio>();
            var mock = bytebankRespoistorio.Object;

            var lista = mock.BuscarAgencias();

            bytebankRespoistorio.Verify(b => b.BuscarAgencias());
        }
    }
}
