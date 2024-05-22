using Microsoft.AspNetCore.Mvc;
using PasswordStrengthApi.Controllers;
using PasswordStrengthApi.Models;

namespace PasswordStrengthApi.Tests;

public class PasswordStrengthControllerTests
{
    private PasswordStrengthController controller;

    public PasswordStrengthControllerTests(){
        controller = new PasswordStrengthController();
    }

    [Fact]
    public async Task GetStrength_ReturnsBadRequest_WhenPasswordNull()
    {
        PasswordDTO passwordDTO = new PasswordDTO
        {
            Password = null
        };

        var result = await controller.GetStrength(passwordDTO);

        Assert.IsType<BadRequestObjectResult>(result);
    }

    [Fact]
    public async Task GetStrength_ReturnsBadRequest_WhenPasswordEmpty()
    {
        PasswordDTO passwordDTO = new PasswordDTO
        {
            Password = ""
        };

        var result = await controller.GetStrength(passwordDTO);

        Assert.IsType<BadRequestObjectResult>(result);
    }

    [Fact]
    public async Task GetStrength_ReturnsOk()
    {
        PasswordDTO passwordDTO = new PasswordDTO
        {
            Password = "a"
        };

        var result = await controller.GetStrength(passwordDTO);

        Assert.NotNull(result);
        Assert.IsType<OkObjectResult>(result);
    }

}