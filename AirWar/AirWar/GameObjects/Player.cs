using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows;
using System;

namespace AirWar.GameObjects
{
    public class Player
    {
        private Rectangle playerShape;
        private Canvas gameCanvas;
        private double speed = 5;
        private bool moveLeft = false; 
        private bool moveRight = true;

        public Player(Canvas canvas, int coordsX, int coordsY)
        {
            gameCanvas = canvas;
            playerShape = new Rectangle
            {
                Width = 50,
                Height = 50,
                Fill = Brushes.Blue
            };

            Canvas.SetLeft(playerShape, coordsX);
            Canvas.SetTop(playerShape, coordsY);

            gameCanvas.Children.Add(playerShape);
        }

        public void HandleKeyDown(Key key)
        {
            return;
        }

        public void HandleKeyUp(Key key)
        {
            return;
        }

        public void Update()
        {
            if (moveLeft && Canvas.GetLeft(playerShape) > 0)
                Canvas.SetLeft(playerShape, Canvas.GetLeft(playerShape) - speed);

            if (moveLeft && Canvas.GetLeft(playerShape) <= 0)
            {
                moveLeft = false;
                moveRight = true;
            }

            if (moveRight && Canvas.GetLeft(playerShape) + playerShape.Width < gameCanvas.ActualWidth)
                Canvas.SetLeft(playerShape, Canvas.GetLeft(playerShape) + speed);

            if (moveRight && Canvas.GetLeft(playerShape) + playerShape.Width >= gameCanvas.ActualWidth)
            {
                moveLeft = true;
                moveRight = false;
            }
        }

        public Bullet Shoot()
        {
            return new Bullet(Canvas.GetLeft(playerShape) + playerShape.Width / 2, Canvas.GetTop(playerShape), gameCanvas);
        }

        public bool Intersects(Aircraft enemyAircraft)
        {
            Rect playerRect = new Rect(Canvas.GetLeft(playerShape), Canvas.GetTop(playerShape), playerShape.Width, playerShape.Height);
            return playerRect.IntersectsWith(enemyAircraft.GetRect());
        }
    }
}
