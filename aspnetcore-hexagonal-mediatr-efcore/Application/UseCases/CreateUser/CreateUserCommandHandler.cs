using Core.Entities;
using Core.Interfaces;
using MediatR;

namespace Application.UserCases.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IUserRepository _repository;

    public CreateUserCommandHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            Nome = request.Nome
        };

        await _repository.AddAsync(user);
        return user.Id;
    }
}
