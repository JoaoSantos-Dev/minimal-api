var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapPost("/login", (MinimalAPI.DTOs.LoginDTO loginDTO) =>
{
    if (loginDTO.Email == "adm@teste.com" && loginDTO.Password == "123456")
    {
        return Results.Ok(new { Message = "Login successful" });
    }
    else
    {
        return Results.Unauthorized();
    }
});


app.Run();

public class LoginDTO
{
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
};