using System;
using SplashKitSDK;

namespace ShapeDrawer
{
	public class MyLine : Shape
	{
        private int _length;

        public MyLine(Color clr, int length) : base(clr)
		{
            _length = length;
		}

        public MyLine() : this(Color.Red, 100)
        {

        }

        public override bool IsAt(Point2D pt)
        {
            Point2D _shapePosition = new Point2D();
            _shapePosition.X = X;
            _shapePosition.Y = Y;
            Point2D _endPosition = new Point2D();
            _endPosition.X = X + _length;
            _endPosition.Y = Y + _length;
            return SplashKit.PointOnLine(pt, SplashKit.LineFrom(_shapePosition, _endPosition));
        }

        public override void Draw()
        {
            if (Selected)
                DrawOutline();
            SplashKit.DrawLine(Color, X, Y, EndPoint.X, EndPoint.Y, SplashKit.OptionLineWidth(5));
        }

        public override void DrawOutline()
        {
            SplashKit.DrawLine(Color.Black, X, Y, EndPoint.X, EndPoint.Y, SplashKit.OptionLineWidth(7));
        }

        public int Length
        {
            get
            {
                return _length;
            }
            set
            {
                _length = value;
            }
        }

        public Point2D EndPoint
        {
            get
            {
                Point2D _endPoint = new Point2D();
                _endPoint.X = X + _length;
                _endPoint.Y = Y + _length;
                return _endPoint;
            }
        }

        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Line");
            base.SaveTo(writer);
            writer.WriteLine(Length);
        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            Length = reader.ReadInteger();
        }
    }
}

