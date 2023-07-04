using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniGames.Model
{
    internal class TagModel
    {
        int size = 4;                               //длина
        int[,] map;                                 //массив, представляющий из себя поле для кнопок
        int spaceX;                                 //ось х
        int spaceY;                                 //ось у
        static Random random = new Random();        


        public event EventHandler WinComplete;

        public TagModel()
        {
            map = new int[size, size];
        }
        /// <summary>
        /// Запуск игры
        /// </summary>
        public void Start()
        {
            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                    map[x, y] = ConvertCoordsToPosition(x, y) + 1;
            spaceX = size - 1;
            spaceY = size - 1;
            map[spaceX, spaceY] = 0;
        }

        /// <summary>
        /// Проверка числа на уникальность
        /// </summary>
        /// <returns></returns>
        public bool CheckNumber()
        {
            if (!(spaceX == size - 1 && spaceY == size - 1))
            {
                return false;
            }

            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    if (!(x == size - 1 && y == size - 1))
                    {
                        if (map[x, y] != ConvertCoordsToPosition(x, y) + 1)
                        {
                            return false;
                        }
                    }
                }
            }

            WinComplete?.Invoke(this, EventArgs.Empty); 
            return true;
        }
        /// <summary>
        /// Заполнение клеток числами
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public int GetNumber(int position)
        {
            int x, y;
            ConvertPositionToCoords(position, out x, out y);
            if (x < 0 || x >= size) return 0;
            if (y < 0 || y >= size) return 0;
            return map[x, y];
        }
        /// <summary>
        /// Сдвиг кнопок
        /// </summary>
        /// <param name="position"></param>
        public void Shift(int position)
        {
            int x, y;
            ConvertPositionToCoords(position, out x, out y);
            if (Math.Abs(spaceX - x) + Math.Abs(spaceY - y) != 1)
                return;
            map[spaceX, spaceY] = map[x, y];
            map[x, y] = 0;
            spaceX = x;
            spaceY = y;
        }

        /// <summary>
        /// Микс кнопок
        /// </summary>
        public void ShiftRandom()
        {
            int number = random.Next(0, 4);
            int x = spaceX;
            int y = spaceY;

            switch (number)
            {
                case 0: x--; break;
                case 1: x++; break;
                case 2: y--; break;
                case 3: y++; break;
            }

            Shift(ConvertCoordsToPosition(x, y));
        }
        /// <summary>
        /// Конвертация координат позиции
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private int ConvertCoordsToPosition(int x, int y)
        {
            if (x < 0)
            {
                x = 0;
            }
            if (x > size - 1)
            {
                x = size - 1;
            }
            if (y < 0)
            {
                y = 0;
            }
            if (y > size - 1)
            {
                y = size - 1;
            }


            return y * size + x;
        }
        /// <summary>
        /// Конвертация позиция по координатам
        /// </summary>
        /// <param name="position"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void ConvertPositionToCoords(int position, out int x, out int y)
        {
            if (position < 0)
            {
                position = 0;
            }
            if (position > size * size - 1)
            {
                position = size * size - 1;
            }


            x = position % size;
            y = position / size;
        }
    }
}
