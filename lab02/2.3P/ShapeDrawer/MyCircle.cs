﻿using System;
using SplashKitSDK;

namespace ShapeDrawer
{
	public class MyCircle : Shape
	{
		private int _radius;

		public MyCircle(Color clr, int radius) : base(clr)
        {
            _radius = radius;
		}

        public MyCircle () : this (Color.Blue, 50)
        {

        }

        public override void Draw()
        {
            if (Selected)
                DrawOutline();
            SplashKit.FillCircle(Color, X, Y, _radius);
        }

        public override void DrawOutline()
        {
            SplashKit.FillCircle(Color.Black, X, Y, _radius + 2);
        }

        public override bool IsAt(Point2D pt)
        {
            Point2D _shapePosition = new Point2D();
            _shapePosition.X = X;
            _shapePosition.Y = Y;
            return SplashKit.PointInCircle(pt, SplashKit.CircleAt(_shapePosition, _radius));
        }

        public int Radius
        {
            get
            {
                return _radius;
            }
            set
            {
                _radius = value;
            }
        }

        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Circle");
            base.SaveTo(writer);
            writer.WriteLine(Radius);
        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            Radius = reader.ReadInteger();
        }
    }
}

