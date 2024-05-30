using MediatR;

namespace OnlineStorePET.CQRS.Command.General.Commands
{
    public class DeleteBrandCommand : IRequest
    {
        public long Id { get; }
        public DeleteBrandCommand(long id)
        {
            this.Id = id;
        }
    }
}
