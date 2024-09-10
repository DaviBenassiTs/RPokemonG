using Xunit;
using Moq;
using RPokemonG.Controllers;
using RPokemonG.Models;
using RPokemonG.Services;
using System.Threading.Tasks;

namespace RTestG.fichaTest
{
    public class FichaTest
    {
        private readonly Mock<FichaServices> _fichaServiceMock;
        private readonly FichaController _fichaController;

        public FichaTest()
        {
            // Cria um mock do FichaServices
            _fichaServiceMock = new Mock<FichaServices>();

            // Cria uma instância do FichaController utilizando o mock do FichaServices
            _fichaController = new FichaController(_fichaServiceMock.Object);
        }

        [Fact]
        public async Task CreateFicha()
        {
            // Arrange - Configura o mock para adicionar uma nova ficha
            var newFicha = new Ficha {Nome = "New Ficha", Elemento = "Elétrico", Especie = "Roedor", Nivel = 1 };
            _fichaServiceMock.Setup(service => service.CreateFicha(newFicha)).Returns(Task.CompletedTask);

            // Act - Chama o método PostFicha
            var result = await _fichaController.PostFicha(newFicha);

            // Assert -  Verifica se o resultado é a ficha criada
            Assert.Equal(newFicha, result);

        }
    }
}