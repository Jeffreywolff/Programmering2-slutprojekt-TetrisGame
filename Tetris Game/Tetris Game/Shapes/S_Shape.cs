using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Shapes;
using System.Windows.Media;


namespace Tetris_Game.Shapes
{
    class S_Shape : ITetromino
    {

        public static string tetrominoName = "S-Shape";
        public static void CreateShape()
        {
            // The S-Block consist of four green blocks with the shape of an S.
            for (int i = 0; i < 5; i++)
            {
                Rectangle rectangle = new Rectangle();
                SolidColorBrush greenBrush = new SolidColorBrush(Color.FromRgb(102, 238, 17));
                rectangle.Fill = greenBrush;
            }
        }
    }
}
