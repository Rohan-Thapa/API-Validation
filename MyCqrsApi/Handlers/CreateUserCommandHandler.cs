using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MyCqrsApi.Commands;

namespace MyCqrsApi.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            // Simulating user creation (normally you'd insert into a database here)
            return await Task.FromResult(Result<string>.Ok($"User '{request.Username}' created successfully."));
        }
    }
}
// HandCrafted by Rohan Thapa