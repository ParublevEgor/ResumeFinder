﻿using Microsoft.IdentityModel.Tokens;
using ResumeFinder.Domain.Contracts;
using ResumeFinder.Domain.Models;
using ResumeFinder.Domain.Models.Enums;
using ResumeFinder.Services.Params;
using ResumeFinder.Utils;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ResumeFinder.Services
{
    /// <summary>
    /// Сервис для аутентификации пользователя
    /// </summary>
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserService _userService;
        private readonly IWorkerService _workerService;
        private readonly ICustomerService _customerService;

        public AuthenticationService(IUserService userService, IWorkerService workerService, ICustomerService customerService)
        {
            _userService = userService;
            _workerService = workerService;
            _customerService = customerService;
        }

        /// <summary>
        /// Метод для получения токена при регистрации
        /// </summary>
        /// <param name="login">Логин</param>
        /// <param name="password">Пароль</param>
        /// <param name="token">Токен отмены</param>
        /// <returns>Токен пользователя</returns>
        public async Task<string?> GetByLoginAndPasswordAsync(string login, string password, CancellationToken token)
        {
            string passwordHash = ComputeHash(password);
            var user =  await _userService.GetByLoginAndPasswordAsync(login, passwordHash, token);
            if (user == null)
                return null;

            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.ToString())
            };
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            var jwt = new JwtSecurityToken(
                AuthOptions.ISSUER,
                AuthOptions.AUDIENCE,
                claimsIdentity.Claims,
                DateTime.UtcNow,
                DateTime.UtcNow.AddDays(1),
                new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256)
                );

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        /// <summary>
        /// Метод для регистрации заказчика
        /// </summary>
        /// <param name="registerParams">Логин, пароль</param>
        /// <param name="token">Токен отмены</param>
        /// <returns>Добавление зарегистрированного заказчика</returns>
        public async Task<Customer> RegisterCustomerAsync(RegisterCustomerParams registerParams, CancellationToken token)
        {
            User createdUser = await AddUserAsync(registerParams.Login, registerParams.Password, Role.Customer, token);

            Customer customer = new Customer()
            {
                Name = registerParams.Name,
                Surname = registerParams.Surname,
                PhoneNumber = registerParams.PhoneNumber,
                Email = registerParams.Email,
                CompanyName = registerParams.CompanyName,
                UserId = createdUser.Id
            };
            return await _customerService.AddAsync(customer, token);
        }

        /// <summary>
        /// Метод для регистрации работника
        /// </summary>
        /// <param name="registerParams">Логин, пароль</param>
        /// <param name="token">Токен отмены</param>
        /// <returns>Добавление зарегистрированного работника</returns>
        public async Task<Worker> RegisterWorkerAsync(RegisterWorkerParams registerParams, CancellationToken token)
        {
            User createdUser = await AddUserAsync(registerParams.Login, registerParams.Password, Role.Worker, token);

            Worker worker = new Worker()
            {
                Name = registerParams.Name,
                Surname = registerParams.Surname,
                Birthday = registerParams.Birthday,
                PhoneNumber = registerParams.PhoneNumber,
                Email = registerParams.Email,
                Gender = registerParams.Gender,
                Information = registerParams.Information,
                UserId = createdUser.Id
            };
            return await _workerService.AddAsync(worker, token);
        }

        /// <summary>
        /// Метод для добавление нового пользователя
        /// </summary>
        /// <param name="login">Логин</param>
        /// <param name="password">Пароль</param>
        /// <param name="role">Роль</param>
        /// <param name="token">Токен отмены</param>
        /// <returns>Добавление нового пользователя</returns>
        private async Task<User> AddUserAsync(string login, string password, Role role, CancellationToken token)
        {
            string hash = ComputeHash(password);
            User user = new User()
            {
                Login = login,
                PasswordHash = hash,
                Role = role
            };
            return await _userService.AddAsync(user, token);
        }

        /// <summary>
        /// Метод для хэширования пароля
        /// </summary>
        /// <param name="input">Введенный пароль</param>
        /// <returns>хэш пароля</returns>
        private string ComputeHash(string input)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = sha256.ComputeHash(bytes);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
    }
}
