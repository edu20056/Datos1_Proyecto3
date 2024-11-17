using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace AirWar.GameObjects
{
    public class AirBase
    {
        public Rectangle Shape { get; private set; }
        public double X { get; private set; }
        public double Y { get; private set; }

        public AirBase(Canvas canvas, double coordsX, double coordsY)
        {
            X = coordsX;
            Y = coordsY;

            Shape = new Rectangle
            {
                Width = 50,
                Height = 50,
                Fill = Brushes.Yellow
            };

            Canvas.SetLeft(Shape, X);
            Canvas.SetTop(Shape, Y);

            canvas.Children.Add(Shape);
        }

        public void MoveTo(double newX, double newY)
        {
            X = newX;
            Y = newY;

            Canvas.SetLeft(Shape, X);
            Canvas.SetTop(Shape, Y);
        }

        public Rect GetRect()
        {
            return new Rect(X, Y, Shape.Width, Shape.Height);
        }
    }
}
