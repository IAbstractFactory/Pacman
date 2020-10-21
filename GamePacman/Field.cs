using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace GamePacman
{
    public class Field
    {
        public Pacman pacman { get; set; }
        public int MaxCoins { get; private set; }
        
        public List<GameObject> coins { get; private set; }
        public List<GameObject> walls { get; private set; }
        public int Width { get; private set; } = 500;
        public int Height { get; private set; } = 400;
        
        public Field(Settings settings)
        {
            
            coins = settings.coins;
            MaxCoins = coins.Count;
            walls = settings.walls;           
            Width = settings.fildWidt;
            Height = settings.fildHeight;
        }

        public void Show(Graphics g)
        {
            pacman.Show(g);
            foreach (var wall in walls)
            {
                wall.Show(g);
            }
            foreach (var coin in coins)
            {
                coin.Show(g);
            }
            g.DrawLine(new Pen(Color.Red, 2), 0, 0, Width, 0);
            g.DrawLine(new Pen(Color.Red, 2), 0, 0, 0, Height);
            g.DrawLine(new Pen(Color.Red, 2), 0, Height, Width, Height);
            g.DrawLine(new Pen(Color.Red, 2), Width, 0, Width, Height);
        }
        public void PacmanMove()
        {
            pacman.Move(this);
        }

    }
}
