using MediatR;
using StoreDataModels;

namespace OnlineStorePET.CQRS.Command.General.Commands
{
    public class DeleteColorCommand : IRequest
    {
        public long Id { get; }
        public DeleteColorCommand(long id)
        {
            this.Id = id;
        }
    }
}
