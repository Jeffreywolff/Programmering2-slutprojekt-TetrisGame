using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Shapes;
using System.Windows.Media;


namespace Tetris_Game.Shapes
{
    class O_Shape : ShapeCtor, ITetromino
    {

        public List<Shape> GameBlock { get; private set; }

        public string TetrominoName
        {
            get => TetrominoName;
            private set
            {
                TetrominoName = "O-Shape";
            }
        }

        public O_Shape()
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
