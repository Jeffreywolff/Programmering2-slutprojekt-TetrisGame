using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Shapes;
using System.Windows.Media;

namespace Tetris_Game
{
    class T_Shape : ITetromino
    {

        private List<Rectangle> _gameBlock = new List<Rectangle>();
        private const string _tetrominoName = "T-Shape";
        private string _imageAdress = "https://static.wikia.nocookie.net/tetrisconcept/images/5/51/T_Tetromino0.png/revision/latest/scale-to-width-down/300?cb=20201205152323";

        private int[,] _shapePosition = new int[4, 4] {
            {0, 0, 1, 0} ,   /*  initializers for row indexed by 0 */
            {0, 1, 1, 1} ,
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

        public T_Shape()
        {
            // The T-Block consist of four purple blocks with the shape of a T.
            for (int i = 0; i < 4; i++)
            {
                Rectangle rectangle = new Rectangle();
                SolidColorBrush purpleBrush = new SolidColorBrush(Color.FromRgb(173, 0, 250));
                rectangle.Fill = purpleBrush;
                rectangle.StrokeThickness = 1;
                rectangle.Stroke = new SolidColorBrush(Color.FromRgb(84, 84, 84));
                _gameBlock.Add(rectangle);
            }
        }

        

    }
}
