using Microsoft.AspNetCore.Mvc;
using RPokemonG.Models;
using System.Security.Cryptography;
using RPokemonG.Services;
using System.Text;

namespace RPokemonG.Controllers
{
    [ApiController]
    [Route("api/Users")]
    public class UserController : ControllerBase
    {
        // Serviço que lida com a lógica de usuários
        private readonly UserServices _userService;

        // Construtor que inicializa o controlador com uma instância do UserService
        public UserController(UserServices userService)
        {
            _userService = userService;
        }

        [HttpPost()]
        public IActionResult Post([FromBody] Users user)
        {
            // Verifica se o nome de usuário já existe
            if (_userService.GetByName(user.Nome) != null)
            {
                return BadRequest("Username already exists.");
            }

            // Converte a senha para um hash antes de armazenar
            user.PasswordHash = HashPassword(user.PasswordHash);
            _userService.Post(user); // Adiciona o novo usuário ao banco

            return Ok("User registered successfully.");
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] Users user)
        {
            // Recupera o usuário com o nome de usuário fornecido
            var existingUser = _userService.GetByName(user.Nome);


            // Verifica se o usuário existe e se a senha fornecida corresponde ao hash armazenado
            if (existingUser == null || !VerifyPassword(user.PasswordHash, existingUser.PasswordHash))
            {
                return Unauthorized("Invalid credentials."); // Retorna erro se as credenciais forem inválidas
            }

            return Ok("Login successful."); 

        }

        // Método que gera um hash SHA-256 para a senha fornecida
        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();// Cria uma instância do algoritmo SHA-256
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));// Computa o hash da senha
            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();// Converte o hash para uma string hexadecimal minúscula
        }

        private bool VerifyPassword(string inputPassword, string storedHash)
        {
            return HashPassword(inputPassword) == storedHash;// Compara o hash da senha fornecida com o hash armazenado
        }
    }

    
}
