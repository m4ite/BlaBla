using Xunit;
using Moq;
using back.Controllers;
using back.Model;

public class CommunityControllerTests
{
    [Fact]
    public async Task GetCommunity_DeveRetornarComunidade()
    {
        var communityRepo = new Mock<ICommunityRepository>();

        var community = new Community
        {
            Id = 1,
            Title = "Comunidade A"
        };

        communityRepo
            .Setup(x => x.GetCommunity("Comunidade A"))
            .ReturnsAsync(community);

        var controller = new CommunityController();

        var result = await controller.GetCommunity(
            communityRepo.Object,
            "Comunidade A"
        );

        Assert.NotNull(result.Value);
        Assert.Equal("Comunidade A", result.Value.Title);
    }

}

