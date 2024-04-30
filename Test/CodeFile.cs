using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieCore.Controllers;
using Xunit;

namespace MovieCore.Tests;

public class MovieControllerTests
{
    private readonly MovieController _controller;

    public MovieControllerTests()
    {
        
        var httpClientFactory = new IHttpClientFactory();
        _controller = new MovieController(httpClientFactory);
    }

    [Fact]
    public async Task GetMovie_ReturnsOkResult_WithMovieDetails()
    {
        var movieName = "Dune";
        
        var result = await _controller.GetMovie(movieName) as OkObjectResult;

        Assert.NotNull(result);
        Assert.Equal(200, result.StatusCode);
    }
}

