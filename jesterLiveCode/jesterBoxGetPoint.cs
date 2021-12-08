using Rhino.Input.Custom;
using Rhino.Geometry;

namespace jesterLiveCode {
    public class jesterBoxGetPoint : GetPoint
    {
        jesterBoxConduit _conduit;

        public jesterBoxGetPoint(jesterBoxConduit conduit) {
            _conduit = conduit;
        }

        protected override void OnMouseMove(GetPointMouseEventArgs e)
        {
            _conduit.PotentialLocation = e.Point;
        }
    }
}
