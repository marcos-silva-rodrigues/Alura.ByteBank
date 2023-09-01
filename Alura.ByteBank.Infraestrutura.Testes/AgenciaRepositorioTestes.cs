using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Microsoft.Extensions.DependencyInjection;
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
    }
}
