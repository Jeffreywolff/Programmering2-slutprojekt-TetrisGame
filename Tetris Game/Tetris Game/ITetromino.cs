using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Shapes;
using System.Windows.Media;

namespace Tetris_Game
{
    interface ITetromino
    {
        public List<Shape> GameBlock { get; set; }

        public string TetrominoName { get; set; }


    }
}
