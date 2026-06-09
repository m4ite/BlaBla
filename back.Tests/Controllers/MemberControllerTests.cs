using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using back.Controllers;
using back.Model;
public class MemberControllerTests
{
    [Fact]
    public async Task GetUser_DeveRetornarListaDeUsuarios()
    {
        // Arrange
        var repoMock = new Mock<IMemberRepository>();

        var usuarios = new List<Person>
        {
            new Person { Id = 1, NickName = "Joao" },
            new Person { Id = 2, NickName = "Maria" }
        };

        repoMock
            .Setup(x => x.GetUsers("teste"))
            .ReturnsAsync(usuarios);

        var controller = new MemberController();

        // Act
        var result = await controller.GetUser(
            repoMock.Object,
            "teste"
        );

        // Assert
        Assert.NotNull(result.Value);
        Assert.Equal(2, result.Value.Count);
    }


    [Fact]
    public async Task GetMemberByName_DeveRetornarUsuario()
    {
        var repoMock = new Mock<IMemberRepository>();

        var usuario = new Person
        {
            Id = 1,
            NickName = "Joao"
        };

        repoMock
            .Setup(x => x.GetMember("Joao"))
            .ReturnsAsync(usuario);

        var controller = new MemberController();

        var result = await controller.GetMemberByName(
            repoMock.Object,
            "Joao"
        );

        Assert.NotNull(result.Value);
        Assert.Equal("Joao", result.Value.NickName);
    }

    [Fact]
    public async Task Update_DeveAlterarCargo()
    {
        var memberRepoMock = new Mock<IMemberRepository>();
        var cargoRepoMock = new Mock<ICargoRepository>();

        var pessoa = new Person
        {
            Id = 1,
            NickName = "Joao"
        };

        var membro = new Member
        {
            Person = 1,
            Cargo = 1
        };

        var cargo = new Cargo
        {
            Id = 3,
            Nome = "Administrador"
        };

        memberRepoMock
            .Setup(x => x.GetMember("Joao"))
            .ReturnsAsync(pessoa);

        memberRepoMock
            .Setup(x => x.GetMemberUpdate(1, "Comunidade"))
            .ReturnsAsync(membro);

        cargoRepoMock
            .Setup(x => x.GetCargobyName("Administrador"))
            .ReturnsAsync(cargo);

        var controller = new MemberController();

        await controller.Update(
            pessoa,
            memberRepoMock.Object,
            cargoRepoMock.Object,
            "Administrador",
            "Comunidade"
        );

        Assert.Equal(3, membro.Cargo);

        memberRepoMock.Verify(
            x => x.Update(It.IsAny<Member>()),
            Times.Once
        );
    }
}