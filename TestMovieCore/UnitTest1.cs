using Microsoft.AspNetCore.Mvc;
using MovieCore.Controllers;

namespace Tests;
public class UnitTest
{
    private readonly MovieController _controller;
    private readonly IHttpClientFactory _httpClientFactory;

    public UnitTest()
    {
        _controller = new MovieController(_httpClientFactory);
    }

    [Fact]
    public void Get_WhenCalled_ReturnsOkResult()
    {
        var okResult = _controller.GetMovie("");

        Assert.NotNull(okResult);
    }
}