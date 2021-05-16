using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Shapes;
using Tetris_Game.Shapes;

namespace Tetris_Game
{
    class TetrominoFactory
    {
        public static List<Rectangle> shape;
        public List<Rectangle> CreateShapeById(int shapeId)
        {
            

            switch (shapeId)
            {
                case 1:
                    var iShape = new I_Shape();
                    shape = iShape.GameBlock;
                    break;
                //case 2:
                // return T_Shape.CreateShape();
                // break;
                //case 3:
                //return J_Shape.CreateShape();
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
                    break;
            }
            return shape;

        }
    }
}
