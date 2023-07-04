using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MiniGames.Model
{
    internal class SnakeViewModel
    {
        private Canvas _GameField;

        public Canvas GameField
        {
            get { return _GameField; }
            set { _GameField = value; }
        }

        public int Score;

        public List<SnakeModel> objectsInGame;

        public Random randomNumber;

        public event EventHandler WinComplete;

        public bool IncorrectFoodPosition;

        public bool GameOver;

        Thread thread1;
        /// <summary>
        /// Метод, обновляющий игровое поле
        /// </summary>
        void UpdateGameField()
        {
            GameField.Children.Clear();

            foreach (SnakeModel obj in objectsInGame)
            {
                if (obj.Type == "SnakeBody")
                {
                    Canvas.SetLeft(obj.rectangle, obj.x);
                    Canvas.SetTop(obj.rectangle, obj.y);
                    GameField.Children.Add(obj.rectangle);
                }

                if (obj.Type == "Food")
                {
                    Canvas.SetLeft(obj.ellipse, obj.x);
                    Canvas.SetTop(obj.ellipse, obj.y);
                    GameField.Children.Add(obj.ellipse);
                }
            }
        }
        /// <summary>
        /// метод, необходимый для движения змейки
        /// </summary>
        void MoveSnake()
        {
            for (int i = objectsInGame.Count - 1; i > 1; i--)
            {
                objectsInGame[i].x = objectsInGame[i - 1].x;
                objectsInGame[i].y = objectsInGame[i - 1].y;
                objectsInGame[i].Direction = objectsInGame[i - 1].Direction;
            }

            switch (objectsInGame[1].Direction)
            {
                case "Right":
                    objectsInGame[1].x += 10;
                    break;

                case "Left":
                    objectsInGame[1].x -= 10;
                    break;

                case "Up":
                    objectsInGame[1].y -= 10;
                    break;

                case "Down":
                    objectsInGame[1].y += 10;
                    ;
                    break;

            }
        }
        /// <summary>
        /// Метод, изменяющий направление змейки
        /// </summary>
        /// <param name="obj"></param>
        void ChangeSnakeDirection(KeyPressedMessage obj)
        {
            if (obj.keyEventArgs.Key == Key.Up && objectsInGame[1].Direction != "Down")
                objectsInGame[1].Direction = "Up";

            if (obj.keyEventArgs.Key == Key.Down && objectsInGame[1].Direction != "Up")
                objectsInGame[1].Direction = "Down";

            if (obj.keyEventArgs.Key == Key.Right && objectsInGame[1].Direction != "Left")
                objectsInGame[1].Direction = "Right";

            if (obj.keyEventArgs.Key == Key.Left && objectsInGame[1].Direction != "Right")
                objectsInGame[1].Direction = "Left";

        }
        /// <summary>
        /// Метод, увеличивающий длину змейки
        /// </summary>
        void IncreaseSnakeLength()
        {
            string direction = objectsInGame[1].Direction;
            
            if (objectsInGame[1].x == objectsInGame[0].x && objectsInGame[1].y == objectsInGame[0].y)
            {
                Score++;
                objectsInGame.Insert(1, new SnakeModel("SnakeBody", direction, objectsInGame[0].x, objectsInGame[0].y));
                


                GenerateNewFoodPosition();
            }
        }
        /// <summary>
        /// Метод, генерирующий новую позицию для шарика(еда змейки)
        /// </summary>
        void GenerateNewFoodPosition()
        {
            int x = 1;
            int y = 1;

            while (IncorrectFoodPosition)
            {
                x = randomNumber.Next(1, 27) * 10;
                y = randomNumber.Next(1, 27) * 10;
                IncorrectFoodPosition = false;

                for (int i = 1; i < objectsInGame.Count; i++)
                {
                    if (objectsInGame[i].x == x && objectsInGame[i].y == y)
                    {
                        IncorrectFoodPosition = true;
                    }
                }
            }

            objectsInGame[0].x = x;
            objectsInGame[0].y = y;

            IncorrectFoodPosition = true;
            WinComplete?.Invoke(this, EventArgs.Empty);
        }
        /// <summary>
        /// Метод, проверяющий змейку на столкновения
        /// </summary>
        void CheckSnakeCollition()
        {
            for (int i = 2; i < objectsInGame.Count; i++)
            {
                if (objectsInGame[1].x == objectsInGame[i].x && objectsInGame[1].y == objectsInGame[i].y)
                    GameOver = true;
            }

            if (objectsInGame[1].x > 270 || objectsInGame[1].x < 1 || objectsInGame[1].y > 280 || objectsInGame[1].y < 1)
                GameOver = true;
            WinComplete?.Invoke(this, EventArgs.Empty);
        }
        /// <summary>
        /// Метод, запускающий игру "Змейка"
        /// </summary>
        void RunTheGame()
        {
            while (!GameOver)
            {
                try
                {
                    GameField.Dispatcher.Invoke(() =>
                    {
                        CheckSnakeCollition();
                        IncreaseSnakeLength();
                        MoveSnake();
                        UpdateGameField();
                    });
                    Thread.Sleep(100);
                }
                catch (Exception)
                {
                    Console.WriteLine("");
                }
                
            }

        }
 
        public SnakeViewModel()
        {
            Messenger.Default.Register<KeyPressedMessage>(this, ChangeSnakeDirection);

            GameField = new Canvas();

            IncorrectFoodPosition = true;
            GameOver = false;

            randomNumber = new Random();

            objectsInGame = new List<SnakeModel>();

            objectsInGame.Add(new SnakeModel("Food", "Null", 50, 200));
            objectsInGame.Add(new SnakeModel("SnakeBody", "Right", 100, 10));
            objectsInGame.Add(new SnakeModel("SnakeBody", "Right", 90, 10));
            objectsInGame.Add(new SnakeModel("SnakeBody", "Right", 80, 10));

            UpdateGameField();

            thread1 = new Thread(() => RunTheGame());

            thread1.Start();
        }
    }
}
