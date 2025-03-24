using MediatR;

namespace MyCqrsApi.Commands
{
    public class CreateUserCommand : IRequest<Result<string>>
    {
        public string? Username { get; set; }
        public string? Email { get; set; }
    }
}
// HandCrafted by Rohan Thapa