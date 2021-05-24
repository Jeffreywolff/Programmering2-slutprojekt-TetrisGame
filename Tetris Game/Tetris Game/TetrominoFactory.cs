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
                    
                case 2:
                    return new T_Shape();
                   
                case 3:
                    return new J_Shape();
                    
                case 4:
                    return new L_Shape();
                    
                case 5:
                    return new O_Shape();
                    
                case 6:
                    return new Z_Shape();
                    
                case 7:
                    return new S_Shape();

                default:
                    return new I_Shape();

            }
            

        }
    }
}
