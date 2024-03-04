using DevLarTech.Core.Entities;
using DevLarTech.Core.Repositories;
using DevLarTech.Core.Services;
using DevLarTech.Infrastructure.Persistence.Repositories;
using MediatR;
using Microsoft.VisualStudio.Services.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User = DevLarTech.Core.Entities.User;

namespace DevLarTech.Application.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {

        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;
        public CreateUserCommandHandler(IUserRepository userRepository, IAuthService authService)
        {
            _userRepository = userRepository;
            _authService = authService;
        }
        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var normalizedEmail = request.Email.ToLowerInvariant();
            var normalizedFullName = request.FullName.ToLowerInvariant();

            if (await _userRepository.ExistsByEmailOrFullNameAsync(normalizedEmail, normalizedFullName))
            {
                // Pode lançar uma exceção personalizada, se desejar
                throw new UserAlreadyExistsException("Este e-mail ou nome de usuário já está em uso.");
            }

            var passwordHash = _authService.ComputeSha256Hash(request.Password);

            var user = new User(request.FullName, request.Email, request.BirthDate, passwordHash, request.Role);

            await _userRepository.AddUserAsync(user);

            return user.Id;
        }
    }
}
