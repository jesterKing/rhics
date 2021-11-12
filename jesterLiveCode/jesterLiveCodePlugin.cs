using Rhino;
using Rhino.PlugIns;

namespace jesterLiveCode {

    public class jesterLiveCodePlugin : PlugIn
    {
        public jesterLiveCodePlugin()
        {
            if(Instance == null)
            {
                Instance = this;
            }
        }
        
        public static jesterLiveCodePlugin Instance { get; private set; }
    }
}
