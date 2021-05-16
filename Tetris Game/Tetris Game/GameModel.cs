using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Shapes;

namespace Tetris_Game
{
    class GameModel
    {

        ITetromino nextTetromino;
        public GameModel()
        {
            nextTetromino = Controller.GetRandomShape();
            
        }

        private void OrganizeShape(ITetromino shape)
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
