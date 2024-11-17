using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows;
using System;

namespace AirWar.GameObjects
{
    public class Bullet
    {
        public Rectangle Shape { get; private set; }
        public bool IsDestroyed { get; private set; }

        public Bullet(double x, double y, Canvas canvas)
        {
            Shape = new Rectangle
            {
                Width = 5,
                Height = 20,
                Fill = Brushes.White
            };

            Canvas.SetLeft(Shape, x);
            Canvas.SetTop(Shape, y);
        }

        public void Update()
        {
            Canvas.SetTop(Shape, Canvas.GetTop(Shape) - 10);

            if (Canvas.GetTop(Shape) < 0)
                IsDestroyed = true;
        }

        public void Destroy(Canvas canvas)
        {
            canvas.Children.Remove(Shape);
            IsDestroyed = true;
        }

        public bool Intersects(Aircraft enemyAircraft)
        {
            Rect bulletRect = new Rect(Canvas.GetLeft(Shape), Canvas.GetTop(Shape), Shape.Width, Shape.Height);
            return bulletRect.IntersectsWith(enemyAircraft.GetRect());
        }
    }
}
