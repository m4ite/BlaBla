using Moq;
using Xunit;
using back.Model;
using back.Controllers;
using Microsoft.AspNetCore.Mvc;

public class PostControllerTests
{
    [Fact]
    public async Task GetByCommunity_DeveRetornarPostsDaComunidade()
    {
        // Arrange
        var repoMock = new Mock<IPostRepository>();

        var posts = new List<PostDTO>
        {
            new PostDTO
            {
                Title = "Post Comunidade"
            }
        };

        repoMock
            .Setup(x => x.GetPostsByCommunity("ComunidadeTeste"))
            .ReturnsAsync(posts);

        var controller = new PostController();

        // Act
        var result = await controller.GetByCommunity(
            repoMock.Object,
            "ComunidadeTeste"
        );

        // Assert
        Assert.NotNull(result.Value);
        Assert.Single(result.Value);
        Assert.Equal(
            "Post Comunidade",
            result.Value[0].Title
        );
    }
}