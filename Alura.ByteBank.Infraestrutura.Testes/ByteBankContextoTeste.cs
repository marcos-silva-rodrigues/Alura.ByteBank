using Alura.ByteBank.Dados.Contexto;

namespace Alura.ByteBank.Infraestrutura.Testes
{
    public class ByteBankContextoTeste
    {
        [Fact]
        public void TestaConexaoContextoComBDMySQL()
        {
            var contexto = new ByteBankContexto();
            bool conectado;

            try
            {
                conectado = contexto.Database.CanConnect();
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possivel conectar a base de dados");
            }

            Assert.True(conectado);
        }
    }
}