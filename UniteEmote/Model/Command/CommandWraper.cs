using Intel.Unite.Common.Command.Serialize;
using UniteEmote.Constants;

namespace UniteEmote.Model.Command
{
    public class CommandWraper<T> : BaseCommand<T>
    {
        public CommandWraper(T t) : base( (ICommandSerializer)new JsonCommandSerializer(), t, ModuleConstants.ModuleInfo.Id )
        { }
    }
}
