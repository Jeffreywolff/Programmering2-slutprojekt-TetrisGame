using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Shapes;

namespace Tetris_Game
{
    class Controller
    {
        


        public static List<Rectangle> GetRandomShape()
        {
            Random random = new Random();
            var shapeId = random.Next(1, 7);

            TetrominoFactory tetrominoFactory = new TetrominoFactory();
            return tetrominoFactory.CreateShapeById(shapeId);

        }
    }
}
