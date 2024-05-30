using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using StoreDataModels;

namespace OnlineStorePET.CQRS.Command.General.Commands
{
    public class UpdateColorCommand : IRequest<Color>
    {
        public long Id { get; }
        public JsonPatchDocument<Color> patchDoc { get; }
        public UpdateColorCommand(long id, JsonPatchDocument<Color> patchDoc)
        {
            this.patchDoc = patchDoc;
            this.Id = id;
        }
    }
}
