using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Domain.Model;
using DTOs;
using Microsoft.IdentityModel.Tokens;

namespace WebAPI
{
    public interface IJwtService
    {
        string GenerateToken(UsuarioDTO usuario);
    }

    public class JwtService : IJwtService
    {
        private readonly IConfiguration _config;

        public JwtService(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateToken(UsuarioDTO usuario)
        {
            var jwtSettings = _config.GetSection("JwtSettings");
            var secretKey = jwtSettings["SecretKey"]!;
            var issuer = jwtSettings["Issuer"];
            var audience = jwtSettings["Audience"];
            var expirationMinutes = int.Parse(jwtSettings["ExpirationMinutes"] ?? "60");

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, usuario.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
                new Claim(ClaimTypes.Role, usuario.Rol.ToString())
            };

            // Permisos según el Rol
            if (usuario.Rol == RolUsuario.Admin)
            {
                // Admin tiene todos los permisos
                claims.Add(new Claim("permission", "usuarios.leer"));
                claims.Add(new Claim("permission", "usuarios.agregar"));
                claims.Add(new Claim("permission", "usuarios.actualizar"));
                claims.Add(new Claim("permission", "usuarios.eliminar"));

                claims.Add(new Claim("permission", "productos.leer"));
                claims.Add(new Claim("permission", "productos.agregar"));
                claims.Add(new Claim("permission", "productos.actualizar"));
                claims.Add(new Claim("permission", "productos.eliminar"));

                claims.Add(new Claim("permission", "categorias.leer"));
                claims.Add(new Claim("permission", "categorias.agregar"));
                claims.Add(new Claim("permission", "categorias.actualizar"));
                claims.Add(new Claim("permission", "categorias.eliminar"));
            }
            else
            {
                // Usuario regular: por ejemplo solo lectura
                claims.Add(new Claim("permission", "productos.leer"));
                claims.Add(new Claim("permission", "categorias.leer"));
                claims.Add(new Claim("permission", "usuarios.leer"));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expirationMinutes),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}