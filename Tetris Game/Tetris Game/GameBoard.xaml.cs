using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
using System.Windows.Threading;
using Key = System.Windows.Input.Key;

namespace Tetris_Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class GameBoard : Window
    {
        GameModel gameModel = new GameModel();
        private Grid gameGrid = new Grid();
        private int[,] validGridPositions = new int[10, 20];
        public GameBoard()
        {
            InitializeComponent();
            InitiateValidGridPositions();

        }

        private void root_Loaded(object sender, RoutedEventArgs e)
        {

            CreateTetrisGrid(10, 20);
            CreateSideBar();
            InitGameControlls();
            StartGame();
        }



        private void InitGameControlls()
        {
            this.KeyDown += new KeyEventHandler(ArrowKeyRightPressed);
            this.KeyDown += new KeyEventHandler(ArrowKeyLeftPressed);
            this.KeyDown += new KeyEventHandler(ArrowKeyDownPressed);
        }


        private void CreateTetrisGrid(int columns, int rows)
        {
            for (int i = 0; i < columns; i++)
            {
                gameGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }
            for (int j = 0; j < rows; j++)
            {
                gameGrid.RowDefinitions.Add(new RowDefinition());
            }

            //SolidColorBrush DarkgreyBrush = new SolidColorBrush(Color.FromRgb(48, 48, 48));
            SolidColorBrush blackBrush = new SolidColorBrush(Color.FromRgb(0, 0, 0));

            //boardGrid.Background = DarkgreyBrush;
            Grid.SetRow(gameGrid, 0);
            Grid.SetColumn(gameGrid, 0);
            root.Children.Add(gameGrid);

            // Creates a rectangle for every x and y in boardGrid
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Rectangle rectangle = new Rectangle();
                    rectangle.Tag = "boardBg";
                    rectangle.Fill = blackBrush;
                    rectangle.StrokeThickness = 1;
                    rectangle.Stroke = new SolidColorBrush(Color.FromRgb(84, 84, 84));
                    Grid.SetRow(rectangle, i);
                    Grid.SetColumn(rectangle, j);
                    gameGrid.Children.Add(rectangle);


                }
            }

        }

        private void InitiateValidGridPositions()
        {
            for (int i = 0; i < validGridPositions.GetUpperBound(0); i++)
            {
                for (int j = 0; j < validGridPositions.GetLowerBound(1); j++)
                {
                    validGridPositions[i, j] = 0;
                }
            }
        }

        private void StartGame()
        {
            DispatcherTimer gameTimer = new DispatcherTimer();

            gameTimer.Interval = TimeSpan.FromMilliseconds(1000);
            gameTimer.Tick += gameTick;
            gameModel.getNextTetromino();
            gameTimer.Start();

        }

        private void ArrowKeyRightPressed(object sender, KeyEventArgs e)
        {
            if (gameModel.activeTetromino == null)
                return;

            if (e.Key == Key.Right && gameModel.shapeStillMovable && gameModel.activeTetromino.GameBlock != null)
            {
                foreach (var rect in gameModel.activeTetromino.GameBlock)
                {
                    
                    int getRectCol = Grid.GetColumn(rect);

                    if (getRectCol >= 9)
                    {
                        return;
                    }
                    else if (NextColumnValid(1, rect))
                    {
                        continue;
                    }
                    else
                    {

                        Console.WriteLine("Out of Bounds");
                        return;
                    }
                }

                foreach (var rect in gameModel.activeTetromino.GameBlock)
                {
                    Grid.SetColumn(rect, Grid.GetColumn(rect) + 1);
                }
            }

        }


        private void ArrowKeyLeftPressed(object sender, KeyEventArgs e)
        {
            if (gameModel.activeTetromino == null)
                return;

            if (e.Key == Key.Left && gameModel.shapeStillMovable && gameModel.activeTetromino.GameBlock != null)
            {
                foreach (var rect in gameModel.activeTetromino.GameBlock)
                {
                    int getRectCol = Grid.GetColumn(rect);
                    
                    if (getRectCol <= 0)
                    {
                        return;
                    }
                    else if (NextColumnValid(-1, rect))
                    {
                        continue;
                    }
                    else
                    {
                        
                        Console.WriteLine("Out of Bounds");
                        return;
                    }
                }

                foreach (var rect in gameModel.activeTetromino.GameBlock)
                {
                    Grid.SetColumn(rect, Grid.GetColumn(rect) - 1);
                }
            }
        }

        private void ArrowKeyDownPressed(object sender, KeyEventArgs e)
        {
            if (gameModel.activeTetromino == null)
                return;

            else if (e.Key == Key.Down && gameModel.shapeStillMovable && gameModel.activeTetromino.GameBlock != null)
            {
                moveItemDown();
            }
        }

        private void ArrowKeyUpPressed(object sender, KeyEventArgs e)
        {
            if (gameModel.activeTetromino == null)
                return;

            else if (e.Key == Key.Up && gameModel.shapeStillMovable && gameModel.activeTetromino.GameBlock != null)
            {
                gameModel.currentPosition = RotateShapeMatrix(gameModel.currentPosition, 4);
                UpdateShapeMatrix();
            }
        }

        private void UpdateShapeMatrix()
        {
            var apa = gameModel.currentPosition.GetUpperBound(0);
            var bepa = gameModel.currentPosition.GetUpperBound(1);
            int iteration = 0;
            for (int i = 0; i <= apa; i++)
            {
                for (int j = 0; j <= bepa; j++)
                {
                    if (gameModel.activeTetromino.shapePosition[i, j] == 1)
                    {
                        var rect = gameModel.activeTetromino.GameBlock[iteration];
                        Grid.SetRow(rect, Grid.GetRow(rect) + i);
                        Grid.SetColumn(rect, Grid.GetColumn(rect) + j);
                        
                        iteration++;
                    }

                }

            }
        }

        private bool NextColumnValid(int direction, Rectangle rect)
        {
            
                int getRectCol = Grid.GetColumn(rect);
                int getRectRow = Grid.GetRow(rect);
                if (validGridPositions[getRectCol + direction, getRectRow] == 1)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            
            
        }

        private bool NextRowValid(Rectangle rect)
        {
            int getRectCol = Grid.GetColumn(rect);
            int getRectRow = Grid.GetRow(rect);

            if (getRectRow >= 19 || validGridPositions[getRectCol, getRectRow + 1] == 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void SetShapePosition(String shapeName)
        {
            int iteration = 0;
            switch (shapeName)
            {
                case "I-Shape":
                    var apa = gameModel.activeTetromino.shapePosition.GetUpperBound(0);
                    var bepa = gameModel.activeTetromino.shapePosition.GetUpperBound(1);
                    for (int i = 0; i <= apa; i++)
                    {
                        for (int j = 0; j <= bepa; j++)
                        {
                            if (gameModel.activeTetromino.shapePosition[i, j] == 1)
                            {
                                var rect = gameModel.activeTetromino.GameBlock[iteration];
                                Grid.SetRow(rect, i);
                                Grid.SetColumn(rect, j);
                                gameGrid.Children.Add(rect);
                                iteration++;
                            }

                        }

                    }

                    break;

                case "J-Shape":

                    foreach (var rect in gameModel.activeTetromino.GameBlock)
                    {
                        if (rect == gameModel.activeTetromino.GameBlock[3])
                        {
                            gameGrid.Children.Add(rect);
                            Grid.SetColumn(rect, iteration - 1);
                            Grid.SetRow(rect, Grid.GetRow(rect) + 1);
                        }
                        else
                        {
                            gameGrid.Children.Add(rect);
                            Grid.SetColumn(rect, iteration);
                            iteration++;
                        }

                    }
                    break;

                case "L-Shape":

                    break;
                default:
                    break;
            }
        }

        private int[,] RotateShapeMatrix(int[,] matrix, int n)
        {
           
            int[,] ret = new int[n, n];

            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    ret[i, j] = matrix[n - j - 1, i];
                }
            }

            return ret;



        }

        private void gameTick(object sender, EventArgs e)
        {

            // Check if no active block, if so add next
            if (gameModel.activeTetromino == null)
            {
                updateAllValidPlacements();
                gameModel.activeTetromino = gameModel.nextTetromino;
                SetShapePosition(gameModel.activeTetromino.TetrominoName);
                gameModel.getNextTetromino();
                gameModel.shapeStillMovable = true;
                gameModel.currentPosition = gameModel.activeTetromino.shapePosition;
            }
            else
            {
                // Check if shape have reached bottom, If bottom true activeTetromino = null. Enables Sliding motion
                moveItemDown();

            }

        }

        private void updateAllValidPlacements()
        {
            foreach (var child in gameGrid.Children.OfType<Rectangle>())
            {

                if ((string)child.Tag != "boardBg")
                {
                    if (gameModel.activeTetromino != null)
                    {
                        foreach (var rect in gameModel.activeTetromino.GameBlock)
                        {
                            validGridPositions[Grid.GetColumn(rect), Grid.GetRow(rect)] = 2;
                        }
                    }
                    else if (gameModel.activeTetromino == null)
                    {
                        validGridPositions[Grid.GetColumn(child), Grid.GetRow(child)] = 1;
                    }

                }
                else
                {
                    validGridPositions[Grid.GetColumn(child), Grid.GetRow(child)] = 0;
                }
            }


        }

        private void moveItemDown()
        {
            foreach (var rect in gameModel.activeTetromino.GameBlock)
            {
                // bool bottomReached = true;
                if (NextRowValid(rect))
                {
                    continue;
                }

                if (!NextRowValid(rect))
                {
                    gameModel.activeTetromino = null;
                    gameModel.shapeStillMovable = false;
                }
            }

            if (gameModel.activeTetromino != null)
            {
                foreach (var rect in gameModel.activeTetromino.GameBlock)
                {
                    Grid.SetRow(rect, Grid.GetRow(rect) + 1);
                }
            }
            
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
