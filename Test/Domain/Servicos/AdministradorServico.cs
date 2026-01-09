using Microsoft.EntityFrameworkCore;
using MinimalAPI.dominio.Entidades;
using MinimalAPI.dominio.Interfaces;
using MinimalAPI.dominio.Servicos;
using MinimalAPI.dominio.DTOs;
using MinimalAPI.Infraestrutura.Db;

namespace Test.Domain.Servicos;

[TestClass]
public class AdministradorServicoTest
{
    private DbContexto CriarContextoDeTeste()
    {
        var options = new DbContextOptionsBuilder<DbContexto>()
            .UseInMemoryDatabase(databaseName: $"TestDatabase_{Guid.NewGuid()}")
            .Options;

        return new DbContexto(options);
    }

    [TestMethod]
    public void TestarIncluirAdministrador()
    {
        // Arrange
        var context = CriarContextoDeTeste();
        var servico = new AdministradorServico(context);
        var adm = new Administrador
        {
            Email = "teste@teste.com",
            Senha = "senha123",
            Perfil = "Adm"
        };

        // Act
        var resultado = servico.Incluir(adm);

        // Assert
        Assert.IsNotNull(resultado);
        Assert.AreEqual("teste@teste.com", resultado.Email);
        Assert.AreEqual("senha123", resultado.Senha);
        Assert.AreEqual("Adm", resultado.Perfil);
    }

    [TestMethod]
    public void TestarBuscaPorId()
    {
        // Arrange
        var context = CriarContextoDeTeste();
        var servico = new AdministradorServico(context);
        var adm = new Administrador
        {
            Email = "teste@teste.com",
            Senha = "senha123",
            Perfil = "Adm"
        };
        servico.Incluir(adm);

        // Act
        var resultado = servico.BuscaPorId(adm.Id);

        // Assert
        Assert.IsNotNull(resultado);
        Assert.AreEqual(adm.Email, resultado.Email);
    }

    [TestMethod]
    public void TestarLogin()
    {
        // Arrange
        var context = CriarContextoDeTeste();
        var servico = new AdministradorServico(context);
        var adm = new Administrador
        {
            Email = "teste@teste.com",
            Senha = "senha123",
            Perfil = "Adm"
        };
        servico.Incluir(adm);

        var loginDTO = new LoginDTO
        {
            Email = "teste@teste.com",
            Password = "senha123"
        };

        // Act
        var resultado = servico.Login(loginDTO);

        // Assert
        Assert.IsNotNull(resultado);
        Assert.AreEqual("teste@teste.com", resultado.Email);
    }

    [TestMethod]
    public void TestarTodos()
    {
        // Arrange
        var context = CriarContextoDeTeste();
        var servico = new AdministradorServico(context);
        var adm1 = new Administrador { Email = "adm1@teste.com", Senha = "senha", Perfil = "Adm" };
        var adm2 = new Administrador { Email = "adm2@teste.com", Senha = "senha", Perfil = "Editor" };

        servico.Incluir(adm1);
        servico.Incluir(adm2);

        // Act
        var resultado = servico.Todos(1);

        // Assert
        Assert.IsNotNull(resultado);
        Assert.IsGreaterThanOrEqualTo(resultado.Count, 2);
    }
}
