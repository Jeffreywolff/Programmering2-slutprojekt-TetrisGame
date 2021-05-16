using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Shapes;
using System.Windows.Media;

namespace Tetris_Game.Shapes
{
    class J_Shape : ShapeCtor, ITetromino
    {
        public List<Shape> GameBlock { get; private set; }




        public string TetrominoName
        {
            get => TetrominoName;
            private set
            {
                TetrominoName = "J-Shape";
            }
        }

        public J_Shape()
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
