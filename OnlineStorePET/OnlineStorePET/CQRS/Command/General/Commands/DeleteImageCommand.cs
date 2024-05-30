using MediatR;

namespace OnlineStorePET.CQRS.Command.General.Commands
{
    public class DeleteImageCommand : IRequest
    {
        public long Id { get; }
        public DeleteImageCommand(long id)
        {

            Id = id;
        }
    }
}
