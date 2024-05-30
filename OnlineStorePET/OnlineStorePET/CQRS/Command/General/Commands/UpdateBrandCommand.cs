using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using StoreDataModels;

namespace OnlineStorePET.CQRS.Command.General.Commands
{
    public class UpdateBrandCommand : IRequest<Brand>
    {
        public long Id { get; }
        public JsonPatchDocument<Brand> PatchDoc { get; }
        public UpdateBrandCommand(long id, JsonPatchDocument<Brand> patchDoc)
        {
            Id = id;
            PatchDoc = patchDoc;
        }

    }
}
