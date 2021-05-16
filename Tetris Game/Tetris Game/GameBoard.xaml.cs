using System;
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
        public static Grid boardGrid = new Grid();
        public GameBoard()
        {
            InitializeComponent();
        }   

        private void CreateTetrisGrid(int columns, int rows)
        {
            

            for (int i = 0; i < columns; i++)
            {
                boardGrid.ColumnDefinitions.Add(new ColumnDefinition());
                
            }
            for (int j = 0; j < rows; j++)
            {

                boardGrid.RowDefinitions.Add(new RowDefinition());

            }



            //SolidColorBrush DarkgreyBrush = new SolidColorBrush(Color.FromRgb(48, 48, 48));
            SolidColorBrush blackBrush = new SolidColorBrush(Color.FromRgb(0, 0, 0));

            //boardGrid.Background = DarkgreyBrush;



            Grid.SetRow(boardGrid, 0);
            Grid.SetColumn(boardGrid, 0);

            root.Children.Add(boardGrid);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Rectangle rectangle = new Rectangle();
                    rectangle.Fill = blackBrush;
                    
                    Grid.SetRow(rectangle, i);
                    Grid.SetColumn(rectangle, j);
                    boardGrid.Children.Add(rectangle);


                }
            }


        }

        private void root_Loaded(object sender, RoutedEventArgs e)
        {
            CreateTetrisGrid(10, 20);
            CreateSideBar();

            var gameMech = new GameMechanics();
            
        }

        private void CreateSideBar()
        {
            var sideRectangle = new Rectangle();
            SolidColorBrush blueBrush = new SolidColorBrush(Color.FromRgb(66, 135, 245));
            sideRectangle.Fill = blueBrush;
            Grid.SetColumn(sideRectangle, 1);
            root.Children.Add(sideRectangle);

            var scoreText = new TextBlock();
            SolidColorBrush blackBrush = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            SolidColorBrush whiteBrush = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            scoreText.Text = "000";
            scoreText.FontSize = 30;
            scoreText.Width = 70;
            scoreText.Height = 30;
            scoreText.Background = blackBrush;
            scoreText.Foreground = whiteBrush;
            Grid.SetColumn(scoreText, 1);
            root.Children.Add(scoreText);

        }
    }
}
