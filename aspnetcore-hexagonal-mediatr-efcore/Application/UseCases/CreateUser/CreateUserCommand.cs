using MediatR;

namespace Application.UserCases.CreateUser;

public record CreateUserCommand(string Nome) : IRequest<Guid>;
