using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Shapes;
using Tetris_Game.Shapes;

namespace Tetris_Game
{
    class TetrominoFactory
    {
        
        public static ITetromino CreateShapeById(int shapeId)
        {
            

            switch (shapeId)
            {
                case 1:
                    return new I_Shape();
                //case 2:
                // return T_Shape.CreateShape();
                // break;
                case 3:
                    return new J_Shape();
                //break;
                //case 4:
                // return L_Shape.CreateShape();
                // break;
                //case 5:
                //return O_Shape.CreateShape();
                //break;
                //case 6:
                //return Z_Shape.CreateShape();
                //break;
                //case 7:
                // return S_Shape.CreateShape();
                // break;

                default:
                    return new I_Shape();

            }
            

        }
    }
}
