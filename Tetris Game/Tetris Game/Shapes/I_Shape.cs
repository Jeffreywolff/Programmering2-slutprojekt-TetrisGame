using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Shapes;
using System.Windows.Media;

namespace Tetris_Game
{
    class I_Shape : ITetromino
    {
        private const string _tetrominoName = "I-Shape";
        private List<Rectangle> _gameBlock = new List<Rectangle>();
        private string _imageAdress = "https://static.wikia.nocookie.net/tetrisconcept/images/4/4a/I_Tetromino-0.png/revision/latest/scale-to-width-down/108?cb=20201205151945";

        private int[,] _shapePosition = new int[4, 4] {
            {0, 0, 0, 0} ,   /*  initializers for row indexed by 0 */
            {1, 1, 1, 1} ,
            {0, 0, 0, 0} ,
            {0, 0, 0, 0} ,   /*  initializers for row indexed by 1 */
        };

        List<Rectangle> ITetromino.GameBlock
        {
            get
            {
                return _gameBlock;
            }
        }

        string ITetromino.TetrominoName
        {
            get
            {
                return _tetrominoName;
            }
        }

        int[,] ITetromino.shapePosition
        {
            get
            {
                return _shapePosition;
            }
        }

        string ITetromino.imageAdress
        {
            get
            {
                return _imageAdress;
            }
        }


        public I_Shape()
        {
            // The I-Block consist of four blue blocks in one column.
            for (int i = 0; i < 4; i++)
            {
                Rectangle rectangle = new Rectangle();
                SolidColorBrush lightBlueBrush = new SolidColorBrush(Color.FromRgb(0, 214, 251));
                rectangle.Fill = lightBlueBrush;
                rectangle.StrokeThickness = 1;
                rectangle.Stroke = new SolidColorBrush(Color.FromRgb(84, 84, 84));
                _gameBlock.Add(rectangle);

            }


        }


    }
}
