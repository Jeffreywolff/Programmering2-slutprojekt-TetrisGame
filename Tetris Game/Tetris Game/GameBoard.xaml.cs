﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tetris_Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class GameBoard : Window
    {
        public GameBoard()
        {
            InitializeComponent();
        }   

        private static void CreateTetrisGrid(int columns, int rows)
        {
            var grid = new Grid();

            for (int i = 0; i < 10; i++)
            {
                grid.RowDefinitions;
            }
            
        }
    }
}