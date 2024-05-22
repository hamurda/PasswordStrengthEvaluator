using Microsoft.AspNetCore.Mvc;
using PasswordStrengthApi.Models;
using PasswordStrengthApi.Services;

namespace PasswordStrengthApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PasswordStrengthController : ControllerBase
{
    private readonly PasswordStrengthService passwordStrengthService;
    public PasswordStrengthController(){
        passwordStrengthService = new PasswordStrengthService();
    }

    [HttpPost]
    public async Task<IActionResult> GetStrength(PasswordDTO passwordDTO)
    {
        if(string.IsNullOrEmpty(passwordDTO.Password)) return BadRequest("Password cannot be empty.");
        
        int strength = passwordStrengthService.EvaluateStrength(passwordDTO.Password);
    
        return Ok(new {strength});
    }
}