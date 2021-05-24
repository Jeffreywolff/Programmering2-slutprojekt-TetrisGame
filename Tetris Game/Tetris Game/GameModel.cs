﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Shapes;

namespace Tetris_Game
{
    class GameModel
    {

        public ITetromino nextTetromino;
        public ITetromino activeTetromino;
        public bool shapeStillMovable = true;
        public int[,] currentMatrix;
        
        public GameModel()
        {
            
            
        }

        public void getNextTetromino()
        {
            nextTetromino = GameController.GetRandomShape();
        }


        
    }
}
