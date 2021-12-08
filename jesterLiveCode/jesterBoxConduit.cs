using Rhino.Display;

using Rhino.Geometry;

namespace jesterLiveCode {
    public class jesterBoxConduit : DisplayConduit
    {
        public Point3d Location { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Length { get; set; }
        
        public Point3d PotentialLocation { get; set; }
        protected override void CalculateBoundingBox(CalculateBoundingBoxEventArgs bbe)
        {
            base.CalculateBoundingBox(bbe);
            Brep box = jesterBoxCommand.CreateJesterBox(Location, Width, Height, Length);
            Brep previewBox = jesterBoxCommand.CreateJesterBox(PotentialLocation, Width, Height, Length);
            BoundingBox bb = box.GetBoundingBox(false);
            BoundingBox previewBb = previewBox.GetBoundingBox(false);
        
            bbe.IncludeBoundingBox(bb);
            bbe.IncludeBoundingBox(previewBb);
        }
        protected override void DrawOverlay(DrawEventArgs drawe)
        {
            base.DrawOverlay(drawe);
            if(Location.IsValid)
            {
                Brep box = jesterBoxCommand.CreateJesterBox(Location, Width, Height, Length);
                drawe.Display.DrawBrepWires(box, System.Drawing.Color.Blue);
            }
            Brep previewBox = jesterBoxCommand.CreateJesterBox(PotentialLocation, Width, Height, Length);
            drawe.Display.DrawBrepWires(previewBox, System.Drawing.Color.Gray);
        }
    }
}
