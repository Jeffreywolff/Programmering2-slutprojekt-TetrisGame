using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Shapes;
using System.Windows.Media;

namespace Tetris_Game
{
    interface ITetromino
    {
        List<Rectangle> GameBlock { get; }

        string TetrominoName { get; }


    }
}
