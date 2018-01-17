using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeTP
{
    public partial class Form1 : Form
    {
        private System.Drawing.Graphics graphicsObjet;

        public Form1()
        {
            InitializeComponent();
            this.graphicsObjet = this.CreateGraphics();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
           
                       
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            Maze m = new Maze(75, 75);

            Console.WriteLine("Maze created");
            m.WallGenerator();
            this.DrawMaze(m);
            m.Depart();
            m.Fin();
            this.DrawDepart(m);
            this.DrawFin(m);
            m.pathfinding();
            this.DrawPathfouding(m);
            
        }    


        
        private void DrawDepart (Maze m)
        {
            int sizeCell = 10;
            System.Drawing.Graphics graphicsObjet;
            graphicsObjet = this.CreateGraphics();
            Pen mypen = new Pen(System.Drawing.Color.Green, 1);
            int start = m.getDepart();
            Console.WriteLine(start);
            for (int i = 0; i<m.getX(); i++)
            {
                for(int j=0; j < m.getY(); j++)
                {
                    if(m.cases[i,j].getId2() == start)
                    {
                        for (int z = 1; z < sizeCell; z++)
                        {
                            graphicsObjet.DrawLine(mypen, sizeCell * (j) + 40, i * sizeCell + z + 40, sizeCell * (j + 1) + 40, sizeCell * (i) + z + 40);

                        }
                        
                    }
                }
            }
            
        }
        private void DrawFin(Maze m)
        {
            int sizeCell = 10;
            System.Drawing.Graphics graphicsObjet;
            graphicsObjet = this.CreateGraphics();
            Pen mypen = new Pen(System.Drawing.Color.Red, 1);
            int start = m.getFin();
            Console.WriteLine(start);
            for (int i = 0; i < m.getX(); i++)
            {
                for (int j = 0; j < m.getY(); j++)
                {
                    if (m.cases[i, j].getId2() == start)
                    {
                        for (int z = 1; z < sizeCell; z++)
                        {
                            graphicsObjet.DrawLine(mypen, sizeCell * (j) + 40, i * sizeCell + z + 40, sizeCell * (j + 1) + 40, sizeCell * (i) + z + 40);

                        }
                    }
                }
            }

        }
        private void DrawPathfouding(Maze m)
        {
            int sizeCell = 10;
            System.Drawing.Graphics graphicsObjet;
            graphicsObjet = this.CreateGraphics();
            Pen mypen = new Pen(System.Drawing.Color.Blue, 1);
            int start = m.getFin();
            Console.WriteLine(start);
            for (int i = 1; i < m.PathTake.Length; i++)
            {
                for (int z = 1; z < sizeCell; z++)
                {
                    graphicsObjet.DrawLine(mypen, sizeCell * (m.getPathfindingY(i)) + 40 , m.getPathfindingX(i) * sizeCell + z + 40 , sizeCell * (m.getPathfindingY(i) + 1) + 40 , sizeCell * (m.getPathfindingX(i)) + z + 40 );
                }
            }

        }
        private void DrawMaze (Maze m)
        {
            int sizeCell = 10;
            System.Drawing.Graphics graphicsObjet;
            graphicsObjet = this.CreateGraphics();
            Pen mypen = new Pen(System.Drawing.Color.Black, 1);
            Pen mypen2 = new Pen(System.Drawing.Color.White, 1);
            Rectangle contour = new Rectangle(40, 40, m.getX() * sizeCell, m.getY()* sizeCell);
            graphicsObjet.DrawRectangle(mypen, contour);
            int i = 40;
            int j = 70;

            for (int x=0; x<m.getX(); x++)
            {
                for (int y = 0; y < m.getY(); y++)
                {

                   

                    if (m.cases[x, y].getWallEast() == true) 
                    {
                        graphicsObjet.DrawLine(mypen, sizeCell * (y + 1) + 40, x * sizeCell + 40, sizeCell * (y + 1) + 40, sizeCell * (x + 1) + 40);

                    }
                    if (m.cases[x, y].getWallSouth() == true)
                    {
                        graphicsObjet.DrawLine(mypen, sizeCell * y + 40, (x + 1) * sizeCell + 40, sizeCell * (y + 1) + 40, sizeCell * (x + 1) + 40);

                    }



                    i = i + 30;
                }
                i = 40;
                j = j +30;
            }
            i = 40;
            j = 70;
            
        }
    }
}
