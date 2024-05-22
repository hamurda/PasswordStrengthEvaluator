using PasswordStrengthApi.Services;

namespace PasswordStrengthApi.Tests;

public class PasswordStrengthServiceTests
{
    private PasswordStrengthService service;
    public PasswordStrengthServiceTests(){
        service = new PasswordStrengthService();
    }

    [Theory]
    [InlineData("",0)]
    [InlineData("abcdefg",1)]
    [InlineData("ABCDEFG",1)]
    [InlineData("1234567",1)]
    [InlineData("!@#$%^&",1)]
    [InlineData("aB!456789",5)]
    public void EvaluateStrength_ExpectedValue(string password, int expectedScore){
        int score = service.EvaluateStrength(password);
        Assert.Equal(score, expectedScore);
    }
}