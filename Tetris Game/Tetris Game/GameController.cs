using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Shapes;

namespace Tetris_Game
{
    class GameController
    {
        


        public static ITetromino GetRandomShape()
        {
            Random random = new Random();
            var shapeId = random.Next(1, 7);

            return TetrominoFactory.CreateShapeById(shapeId);

        }
    }
}
