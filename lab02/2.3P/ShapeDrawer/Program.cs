using System;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class Program
    {
        private enum ShapeKind
        {
            Rectangle,
            Circle,
            Line
        }

        public static void Main()
        {
            Window window = new Window("Shape Drawer", 800, 600);

            //2.3
            //Shape myShape = new Shape();

            //3.3
            Drawing myDrawing = new Drawing();

            ShapeKind kindToAdd = new ShapeKind();
            kindToAdd = ShapeKind.Circle;

            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();

                if (SplashKit.KeyTyped(KeyCode.RKey))
                {
                    kindToAdd = ShapeKind.Rectangle;
                }
                else if (SplashKit.KeyTyped(KeyCode.CKey))
                {
                    kindToAdd = ShapeKind.Circle;
                }
                else if (SplashKit.KeyTyped(KeyCode.LKey))
                {
                    kindToAdd = ShapeKind.Line;
                }

                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    Shape newShape;

                    if (kindToAdd == ShapeKind.Circle)
                    {
                        MyCircle newCircle = new MyCircle();

                        newShape = newCircle;
                    }
                    else if (kindToAdd == ShapeKind.Line)
                    {
                        MyLine newLine = new MyLine();

                        newShape = newLine;
                    }
                    else
                    {
                        MyRectangle newRect = new MyRectangle();

                        newShape = newRect;
                    }

                    myDrawing.AddShape(newShape);
                    newShape.X = SplashKit.MouseX();
                    newShape.Y = SplashKit.MouseY();


                }

                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    myDrawing.Background = SplashKit.RandomRGBColor(255);
                }

                if (SplashKit.MouseClicked(MouseButton.RightButton))
                {
                    myDrawing.SelectShapesAt(SplashKit.MousePosition());
                }

                if (SplashKit.KeyTyped(KeyCode.DeleteKey) | SplashKit.KeyTyped(KeyCode.BackspaceKey))
                {
                    foreach (Shape s in myDrawing.SelectedShapes)
                    {
                        myDrawing.RemoveShape(s);
                    }
                }

                myDrawing.Draw();

                if (SplashKit.KeyTyped(KeyCode.SKey))
                {
                    myDrawing.Save("TestDrawing.txt");
                }

                if (SplashKit.KeyTyped(KeyCode.OKey))
                {
                    myDrawing.Load("TestDrawing.txt");
                }

                SplashKit.RefreshScreen();
            } while (!window.CloseRequested);
        }
    }
}
