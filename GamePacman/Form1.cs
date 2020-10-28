using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GamePacman
{
    public partial class Form1 : Form
    {

        Pacman pacman;
        string labelText = "Conins: ";
        
        Field field;
        bool VicMessage = false;
        public Form1()
        {

            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);

            BinaryFormatter binaryFormatter = new BinaryFormatter();
            Settings settings = new Settings();
            using (FileStream stream = new FileStream(@"settings2.dat", FileMode.Open))
            {
                settings = binaryFormatter.Deserialize(stream) as Settings;
            }

            field = new Field(settings);
            pacman = new Pacman(field.Width / 2, field.Height / 2, 20, 20, Resource1.pacman);
            field.pacman = pacman;
            UpdateStyles();

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            var graphics = e.Graphics;
            field.Show(e.Graphics);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pacman.Move(field);
            label1.Text = labelText + pacman.Coins.ToString() + " / " + field.MaxCoins.ToString();
            if (pacman.Coins == field.MaxCoins && !VicMessage)
            {
                //MessageBox.Show("Победа!");
                VicMessage = true;
                Close();

            }

            Refresh();

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

            pacman.Read(e.KeyChar);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            Width = field.Width + pacman.Width / 2;
            Height = field.Height + 100;
            this.MinimumSize = new Size(Width, Height);
            this.MaximumSize = new Size(Width, Height);
            this.Location = new Point(ClientSize.Width  / 2, 0);//1920 - мое разрешение экрана по горизонтали 
        }
    }
}
