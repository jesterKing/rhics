using Rhino;
using Rhino.Commands;

using Rhino.Input;
using Rhino.Input.Custom;

using Rhino.Geometry;
using System.Collections.Generic;

namespace jesterLiveCode
{
    public class jesterLiveCodeCommandOne : Command
    {
        public override string EnglishName => "jesterLiveCodeCommandOne";
        
        protected override Result RunCommand(RhinoDoc doc, RunMode mode)
        {
            int width = 10;
            int length = 10;
            int height = 10;
            
            OptionInteger widthOption = new OptionInteger(width, 1, 50);
            OptionInteger lengthOption = new OptionInteger(length, 1, 50);
            OptionInteger heightOption = new OptionInteger(height, 1, 50);
            Point3d point = Point3d.Unset;
            GetPoint getPoint = new GetPoint();
            getPoint.AcceptNothing(true);
            getPoint.SetCommandPrompt("Pick a location, and enter when done");
            getPoint.AddOptionInteger("Width", ref widthOption);
            getPoint.AddOptionInteger("Length", ref lengthOption);
            getPoint.AddOptionInteger("Height", ref heightOption);
            for(;;)
            {
                GetResult result = getPoint.Get();
            
                if(result == GetResult.Point)
                {
                    point = getPoint.Point();
                    RhinoApp.WriteLine($"User clicked point {point}");
                    continue;
                }
            
                if(result == GetResult.Option)
                {
                    width = widthOption.CurrentValue;
                    length = lengthOption.CurrentValue;
                    height = heightOption.CurrentValue;
            
                    RhinoApp.WriteLine($"Current given dimensions {width}x{length}x{height}");
                    continue;
                }
            
                if(result == GetResult.Nothing)
                {
                    break;
                }
            
                if(result == GetResult.Cancel)
                {
                    RhinoApp.WriteLine("Command cancelled");
                    return Result.Cancel;
                }
            }
            Plane p = new Plane(point, Vector3d.ZAxis);
            Interval widthInterval = new Interval(0, width);
            Interval lengthInterval = new Interval(0, length);
            Interval heightInterval = new Interval(0, height);
            Box box = new Box(p, widthInterval, lengthInterval, heightInterval);
            Brep boxBrep = box.ToBrep();
            doc.Objects.AddBrep(boxBrep);
            doc.Views.Redraw();
            return Result.Success;
        }
    }
}
