using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows;
using System.Numerics;
using System.Windows.Input;
using System.Windows.Threading;

using AirWar.GameObjects;

namespace AirWar.GameLogic
{
    public class GameManager
    {
        private Canvas gameCanvas;
        private Player player;
        private List<Bullet> bullets = new List<Bullet>();
        private List<AirBase> airBases = new List<AirBase>();
        //private List<Enemy> enemies = new List<Enemy>();
        private Random rand = new Random();

        private int enemyCounter = 100;
        private int limit = 50;
        private int score = 0;
        private int damage = 0;

        private Aircraft aircraft;
        private DispatcherTimer gameLoopTimer;

        public GameManager(Canvas canvas)
        {
            gameCanvas = canvas;
            player = new Player(canvas, 0, 650);

            AirBaseGraph graph = new AirBaseGraph();

            // Crear nodos (bases aéreas)
            AirBaseNode base1 = graph.AddNode(new AirBase(gameCanvas, 100, 100));
            AirBaseNode base2 = graph.AddNode(new AirBase(gameCanvas, 300, 200));
            AirBaseNode base3 = graph.AddNode(new AirBase(gameCanvas, 500, 100));

            // Crear conexiones
            graph.AddEdge(base1, base2);
            graph.AddEdge(base2, base3);
            graph.AddEdge(base3, base1);

            aircraft = new Aircraft(base1, gameCanvas); 
            
            aircraft.MoveTo(base2);

            gameLoopTimer = new DispatcherTimer();
            gameLoopTimer.Interval = TimeSpan.FromMilliseconds(16);
            gameLoopTimer.Tick += GameLoop;
            gameLoopTimer.Start();
        }

        public void GameLoop(object sender, EventArgs e)
        {
            player.Update();

            foreach (var bullet in bullets)
            {
                bullet.Update();
            }
            bullets.RemoveAll(b => b.IsDestroyed);

            aircraft.Update();

            if (damage >= 100)
            {
                EndGame();
            }
        }

        public void HandleKeyDown(Key key)
        {
            player.HandleKeyDown(key);

            if (key == Key.Space)
            {
                Bullet newBullet = player.Shoot();
                bullets.Add(newBullet);
                gameCanvas.Children.Add(newBullet.Shape);
            }
        }

        private void PlaceAirBases()
        {
            // Ensure the canvas has valid dimensions
            double canvasWidth = gameCanvas.ActualWidth > 0 ? gameCanvas.ActualWidth : 500; // Fallback to 500
            double canvasHeight = gameCanvas.ActualHeight > 0 ? gameCanvas.ActualHeight : 800; // Fallback to 700

            for (int i = 0; i < 5; i++)
            {
                // Generate random coordinates within valid bounds
                double x = rand.Next(0, (int)Math.Max(canvasWidth - 50, 1)); // Ensure max > min
                double y = rand.Next(0, (int)Math.Max(canvasHeight - 150, 1)); // Avoid player area

                // Create and add the airbase
                AirBase newAirBase = new AirBase(gameCanvas, x, y);
                airBases.Add(newAirBase);
            }
        }


        public void HandleKeyUp(Key key)
        {
            player.HandleKeyUp(key);
        }

        private void SpawnEnemy()
        {
            /*
            Enemy newEnemy = new Enemy(gameCanvas, rand.Next(30, 430));
            enemies.Add(newEnemy);
            gameCanvas.Children.Add(newEnemy.Shape);
            */
        }

        private void EndGame()
        {
            MessageBox.Show($"Game Over! Score: {score}");
            Application.Current.Shutdown();
        }
    }
}