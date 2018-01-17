using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeTP
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            String[,] Maze = new string[,]
        {
        {"_|", "_|", "_|", "_|", "_|", "_|"},
        {"_|", "_|", "_|", "_|", "_|", "_|"},
        {"_|", "_|", "_|", "_|", "_|", "_|"},
        {"_|", "_|", "_|", "_|", "_|", "_|"},
        {"_|", "_|", "_|", "_|", "_|", "_|"}
        };
            int[,] val = new int[,]
            {
        {1, 2, 3,4,5,6},
        {7,8,9,10,11,12},
        {13,14,15,16,17,18},
        {19,20,21,22,23,24},
        {25,26,27,28,29,30}
            };
            Console.WriteLine(val[1, 1]);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            

        }
    }
}
