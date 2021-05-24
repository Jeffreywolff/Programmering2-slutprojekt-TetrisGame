using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Shapes;
using System.Windows.Media;


namespace Tetris_Game.Shapes
{
    class S_Shape : ITetromino
    {

        private List<Rectangle> _gameBlock = new List<Rectangle>();
        private const string _tetrominoName = "S-Shape";
        private string _imageAdress = "https://static.wikia.nocookie.net/tetrisconcept/images/9/9e/S_Tetromino-0.png/revision/latest/scale-to-width-down/306?cb=20201205151227";

        private int[,] _shapePosition = new int[4, 4] {
            {0, 0, 0, 0} ,   /*  initializers for row indexed by 0 */
            {0, 0, 1, 1} ,
            {0, 1, 1, 0} ,
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

        public S_Shape()
        {
            // The S-Block consist of four green blocks with the shape of an S.
            for (int i = 0; i < 4; i++)
            {
                Rectangle rectangle = new Rectangle();
                SolidColorBrush greenBrush = new SolidColorBrush(Color.FromRgb(102, 238, 17));
                rectangle.Fill = greenBrush;
                rectangle.StrokeThickness = 1;
                rectangle.Stroke = new SolidColorBrush(Color.FromRgb(84, 84, 84));
                _gameBlock.Add(rectangle);
            }
        }
    }
}
