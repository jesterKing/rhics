using Rhino;
using Rhino.Commands;

namespace jesterLiveCode
{
    public class jesterLiveCodeCommandOne : Command
    {
        public override string EnglishName => "jesterLiveCodeCommandOne";
        
        protected override Result RunCommand(RhinoDoc doc, RunMode mode)
        {
            RhinoApp.WriteLine("jesterLiveCodeCommandOne`. says hello");
            return Result.Success;
        }
    }
}
