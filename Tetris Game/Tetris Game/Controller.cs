using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris_Game
{
    class Controller
    {
        List<ITetrominos> followingShapes = new List<ITetrominos>();


        private void GetRandomShape()
        {
            Random random = new Random();
            var shapeId = random.Next(1, 7);

            switch (shapeId)
            {
                case 1:

                default:
                    break;
            }

        }
    }
}
