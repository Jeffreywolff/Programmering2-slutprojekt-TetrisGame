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
        private Grid sideBarGrid = new Grid();
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
            this.KeyDown += new KeyEventHandler(ArrowKeyUpPressed);
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

        private void CreateSideBar()
        {
            //Creates amount of rows in sidebar grid
            for (int i = 0; i < 5; i++)
            {
                sideBarGrid.RowDefinitions.Add(new RowDefinition());
            }
            Grid.SetColumn(sideBarGrid, 1);
            root.Children.Add(sideBarGrid);

            // Rectangle created for Background Color
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
            Grid.SetRow(scoreText, 2);
            sideBarGrid.Children.Add(scoreText);

        }
        private void StartGame()
        {
            DispatcherTimer gameTimer = new DispatcherTimer();
            gameTimer.Interval = TimeSpan.FromMilliseconds(800);
            gameTimer.Tick += gameTick;
            gameModel.getNextTetromino();
            gameTimer.Start();

        }

        



        private void gameTick(object sender, EventArgs e)
        {
            if (GameOver())
            {

            }

            // Check if no active block, if so add next
            if (gameModel.activeTetromino == null)
            {
                updateAllValidPlacements();
                gameModel.activeTetromino = gameModel.nextTetromino;
                InitializePositionAfterMatrix();
                gameModel.getNextTetromino();
                gameModel.shapeStillMovable = true;
                gameModel.currentMatrix = gameModel.activeTetromino.shapePosition;
            }
            else
            {
                // Check if shape have reached bottom, If bottom true activeTetromino = null. Enables Sliding motion
                moveItemDown();

            }

        }

        private void UpdatePosition()
        {

            if (gameModel.activeTetromino.TetrominoName == "O-Shape")
            {
                return;
            }
            int iteration = 0;
            var upperBoundFirstDim = gameModel.currentMatrix.GetUpperBound(0);
            var upperBoundSecondDim = gameModel.currentMatrix.GetUpperBound(1);

            var optimalRow = Grid.GetRow(gameModel.activeTetromino.GameBlock[1]);
            var optimalColumn = Grid.GetColumn(gameModel.activeTetromino.GameBlock[2]);

            for (int i = 0; i <= upperBoundFirstDim; i++)
            {
                for (int j = 0; j <= upperBoundSecondDim; j++)
                {
                    if (gameModel.currentMatrix[i, j] == 1)
                    {
                        var rect = gameModel.activeTetromino.GameBlock[iteration];
                        var rectRow = Grid.GetRow(rect);
                        var rectCol = Grid.GetColumn(rect);

                        if ((i + optimalRow - 1) < 0)
                        {
                            return;
                        }
                        else
                        {
                            Grid.SetRow(rect, (i + optimalRow - 1));
                        }

                        if ((j + optimalColumn - 2) < 0)
                        {
                            return;
                        }
                        else
                        {
                            Grid.SetColumn(rect, (j + optimalColumn - 2));
                        }
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

        private void InitializePositionAfterMatrix()
        {
            int iteration = 0;
            var upperBoundFirstDim = gameModel.activeTetromino.shapePosition.GetUpperBound(0);
            var upperBoundSecondDim = gameModel.activeTetromino.shapePosition.GetUpperBound(1);
            for (int i = 0; i <= upperBoundFirstDim; i++)
            {
                for (int j = 0; j <= upperBoundSecondDim; j++)
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


        }

        private int[,] RotateShapeMatrixClockwise(int[,] matrix, int N)
        {
            int[,] ret = new int[N, N];
            int outerDimIndex = matrix.GetUpperBound(0);
            int innerDimIndex = matrix.GetUpperBound(1);

            for (int i = 0; i < outerDimIndex + 1; i++)
            {
                for (int j = 0; j < innerDimIndex + 1; j++)
                {
                    ret[i, j] = matrix[outerDimIndex - j, i];
                }
            }
            return ret;
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
                gameModel.currentMatrix = RotateShapeMatrixClockwise(gameModel.currentMatrix, 4);
                UpdatePosition();
            }
        }

    }
}
