using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Shapes;
using System.Windows.Media;

namespace Tetris_Game
{
    interface ITetromino
    {
        public List<Shape> gameBlock { get; set; }

        string tetrominoName
        { get; set; }


        public static void CreateShape()
        {

            //All shapes consists of four blocks
            for (int i = 0; i < 5; i++)
            {
               
            }
        }

    }
}
