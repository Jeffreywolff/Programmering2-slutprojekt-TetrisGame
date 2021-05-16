using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Shapes;
using System.Windows.Media;


namespace Tetris_Game.Shapes
{
    class O_Shape : ITetromino
    {

        public static string tetrominoName = "O-Shape";
        public static void CreateShape()
        {
            // The O-Block consist of four yellow blocks with the shape of an O.
            for (int i = 0; i < 5; i++)
            {
                Rectangle rectangle = new Rectangle();
                SolidColorBrush yellowBrush = new SolidColorBrush(Color.FromRgb(255, 206, 18));
                rectangle.Fill = yellowBrush;
            }
        }
    }
}
