using MediatR;

namespace OnlineStorePET.CQRS.Command.General.Commands
{
    public class DeleteCountryCommand : IRequest
    {
        public long Id { get; }
        public DeleteCountryCommand(long id)
        {
            this.Id = id;
        }
    }
}
