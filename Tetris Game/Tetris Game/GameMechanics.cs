using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Shapes;

namespace Tetris_Game
{
    class GameMechanics
    {

        List<Array> followingShapes = new List<Array>();
        public GameMechanics()
        {

            var shape = Controller.GetRandomShape();
            followingShapes.Add(shape);
            
            GameBoard.boardGrid.Children.Add(followingShapes);
        }

        private static void OrganizeShape(ITetrominos shape)
        {


        }

        private static void ArrowKeyUp()
        {

        }

        private static void ArrowKeyDown()
        {

        }

        private static void ArrowKeyLeft()
        {

        }

        private static void ArrowKeyRight()
        {

        }
    }
}
