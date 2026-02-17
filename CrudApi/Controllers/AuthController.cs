using CrudApi.Dtos;
using CrudApi.Dtos.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CrudApi.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IConfiguration _config;

    public AuthController(
        UserManager<ApplicationUser> userManager,
        IConfiguration config
    )
    {
        _userManager = userManager;
        _config = config;
    }

    [HttpPost("register")]
    [SwaggerOperation(Summary = "Register")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register([FromBody] RegisterRequestDto request)
    {
        var user = new ApplicationUser
        {
            UserName = request.Email,
            Email = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName
        };

        var result = await _userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
        {
            var errors = result.Errors.Select(e => e.Description).ToList();
            var errorResponse = ApiResponseDto<ApplicationUser>.ErrorResponse("Failed to create user.", errors);
            return BadRequest(errorResponse);
        }

        var successResponse = ApiResponseDto<bool>.SuccessResponse(true, "User created.");
        return Ok(successResponse);
    }

    [HttpPost("login")]
    [SwaggerOperation(Summary = "Login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);

        if (user == null || !await _userManager.CheckPasswordAsync(user, request.Password))
        {
            var errorResponse = ApiResponseDto<string>.ErrorResponse("Invalid credentials.");
            return Unauthorized(errorResponse);
        }

        if (user.IsDeleted)
        {
            var errorResponse = ApiResponseDto<string>.ErrorResponse("User deleted.");
            return Unauthorized(errorResponse);
        }

        var roles = await _userManager.GetRolesAsync(user);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Name, user.UserName!),
            new Claim(ClaimTypes.Email, user.Email!),
            new Claim("firstName", user.FirstName ?? ""),
            new Claim("lastName", user.LastName ?? "")
        };

        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        var jwt = _config.GetSection("Jwt");

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(jwt["Key"]!));

        var token = new JwtSecurityToken(
            issuer: jwt["Issuer"],
            audience: jwt["Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
        );

        var response = new LoginResponseDto
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            User = new UserDto
            {
                Id = user.Id,
                Email = user.Email!,
                Username = user.UserName!,
                Roles = roles.ToList()
            }
        };

        var successResponse = ApiResponseDto<LoginResponseDto>.SuccessResponse(response, "Login successful.");
        return Ok(successResponse);
    }
}
