using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

using AirWar.GameLogic;

namespace AirWar
{
    public partial class Game : Window
    {
        private GameManager gameManager;

        public Game()
        {
            InitializeComponent();
            gameManager = new GameManager(MyCanvas);

            DispatcherTimer gameTimer = new DispatcherTimer();
            gameTimer.Interval = TimeSpan.FromMilliseconds(20);
            gameTimer.Tick += gameManager.GameLoop;
            gameTimer.Start();

            MyCanvas.Focus();
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            gameManager.HandleKeyDown(e.Key);
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            gameManager.HandleKeyUp(e.Key);
        }
    }
}
