using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using StoreDataModels;

namespace OnlineStorePET.CQRS.Command.General.Commands
{
    public class UpdateImageCommand : IRequest<Image>
    {
        public long Id { get; }
        public JsonPatchDocument<Image> PatchDoc { get; }
        public UpdateImageCommand(long id, JsonPatchDocument<Image> patchDoc)
        {
            this.Id = id;
            this.PatchDoc = patchDoc;
        }
    }
}
