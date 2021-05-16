using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Shapes;
using System.Windows.Media;

namespace Tetris_Game
{
    class I_Shape : ShapeCtor, ITetromino
    {

        public List<Shape> GameBlock { get; private set; }

        public string TetrominoName
        {
            get => TetrominoName;
            private set
            {
                TetrominoName = "I-Shape";
            }
        }

        public I_Shape()
        {
            // The I-Block consist of four blue blocks in one column.
            for (int i = 0; i < 5; i++)
            {
                Rectangle rectangle = new Rectangle();
                SolidColorBrush lightBlueBrush = new SolidColorBrush(Color.FromRgb(0, 214, 251));
                rectangle.Fill = lightBlueBrush;
                GameBlock.Add(rectangle);

            }


        }


    }
}
