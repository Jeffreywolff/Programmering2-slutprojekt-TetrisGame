using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Shapes;
using System.Windows.Media;

namespace Tetris_Game.Shapes
{
    class J_Shape : ITetromino
    {

        public static string tetrominoName = "J-Shape";
        public static void CreateShape()
        {
            // The J-Block consist of four Darkblue blocks with the shape of a J.
            for (int i = 0; i < 5; i++)
            {
                Rectangle rectangle = new Rectangle();
                SolidColorBrush darkBlueBrush = new SolidColorBrush(Color.FromRgb(45, 0, 250));
                rectangle.Fill = darkBlueBrush;
            }
        }
    }
}
