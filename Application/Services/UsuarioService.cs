using BCrypt.Net;
using Sistema_tickets_api.Core.Entities;
using Sistema_tickets_api.Core.Interfaces;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;


public class UsuarioService
{
    private readonly IUsuarioRepository _repo;
    private readonly IConfiguration _config;

    public UsuarioService(IUsuarioRepository repo, IConfiguration config)
    {
        _repo = repo;
        _config = config;
    }

    // REGISTRO
    public Usuario Registrar(string nombre, string email, string password, int rolId = 2) 
    {
        var existente = _repo.ObtenerPorEmail(email);
        if (existente != null)
            throw new Exception("El usuario ya existe");

        var hash = BCrypt.Net.BCrypt.HashPassword(password);

        var usuario = new Usuario
        {
            Nombre = nombre,
            Email = email,
            PasswordHash = hash,
            RolId = rolId  
        };

        return _repo.Crear(usuario);
    }

    // LOGIN
    public string? Login(string email, string password)
    {
        var usuario = _repo.ObtenerPorEmail(email);

        if (usuario == null)
            return null;

        bool valido = BCrypt.Net.BCrypt.Verify(password, usuario.PasswordHash);

        if (!valido)
            return null;

        return GenerarToken(usuario);
    }

    // TOKEN
    private string GenerarToken(Usuario usuario)
    {
        var jwt = _config.GetSection("Jwt");

        var claims = new[]
        {
        new Claim(ClaimTypes.Name, usuario.Email),
        new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
        new Claim(ClaimTypes.Role, usuario.Rol?.Nombre ?? "Usuario") 
    };

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(jwt["Key"])
        );

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: jwt["Issuer"],
            audience: jwt["Audience"],
            claims: claims,
            expires: DateTime.Now.AddHours(2),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public IEnumerable<Usuario> ListarTodos()
    {
        return _repo.Listar(); 
    }

    public Usuario? ObtenerPorId(int id)
    {
        return _repo.ObtenerPorId(id);
    }

    public Usuario? ObtenerPorEmail(string email)
    {
        return _repo.ObtenerPorEmail(email);
    }
}