﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Shapes;
using System.Windows.Media;


namespace Tetris_Game.Shapes
{
    class L_Shape : ShapeCtor, ITetromino
    {

        public List<Shape> GameBlock { get; private set; }

        public string TetrominoName
        {
            get => TetrominoName;
            private set
            {
                TetrominoName = "L-Shape";
            }
        }
        

        public L_Shape()
        {
            // The L-Block consist of four orange blocks with the shape of a L.
            for (int i = 0; i < 5; i++)
            {
                Rectangle rectangle = new Rectangle();
                SolidColorBrush orangeBrush = new SolidColorBrush(Color.FromRgb(255, 108, 19));
                rectangle.Fill = orangeBrush;
            }
        }



    }
}
