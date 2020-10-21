﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePacman
{
    [Serializable]
    public class Coin : GameObject
    {
        public Coin(int x, int y, int height, int width) : base(x, y, width, height)
        {

        }
        public override void Show(Graphics g)
        {
            g.DrawEllipse(new Pen(Color.Gold, 4), new Rectangle(X + Width / 2, Y + Height / 2, Width, Height));
        }
    }
}
