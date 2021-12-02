using Rhino.Display;

using Rhino.Geometry;

namespace jesterLiveCode {
    public class jesterBoxConduit : DisplayConduit
    {
        public Point3d Location { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Length { get; set; }
        protected override void CalculateBoundingBox(CalculateBoundingBoxEventArgs bbe)
        {
            base.CalculateBoundingBox(bbe);
            Brep box = jesterBoxCommand.CreateJesterBox(Location, Width, Height, Length);
            BoundingBox bb = box.GetBoundingBox(false);
        
            bbe.IncludeBoundingBox(bb);
        }
        protected override void DrawOverlay(DrawEventArgs drawe)
        {
            base.DrawOverlay(drawe);
            Brep box = jesterBoxCommand.CreateJesterBox(Location, Width, Height, Length);
            drawe.Display.DrawBrepWires(box, System.Drawing.Color.Blue);
        }
    }
}
