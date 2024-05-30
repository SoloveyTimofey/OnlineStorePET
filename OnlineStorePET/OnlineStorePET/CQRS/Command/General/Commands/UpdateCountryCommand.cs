using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using StoreDataModels;

namespace OnlineStorePET.CQRS.Command.General.Commands
{
    public class UpdateCountryCommand : IRequest<Country>
    {
        public long Id { get; }
        public JsonPatchDocument<Country> PatchDoc { get; set; }
        public UpdateCountryCommand(long id, JsonPatchDocument<Country> patchDoc)
        {
            this.Id = id;
            this.PatchDoc = patchDoc;
        }
    }
}
