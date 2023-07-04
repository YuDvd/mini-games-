using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MiniGames.Model
{
    internal class SnakeModel
    {
        public string Type;                                         //тип
        public string Direction;                                    //направление
        public int x;                                               //ось х
        public int y;                                               //ось у
        public Rectangle rectangle;                                 //кввадрат
        public Ellipse ellipse;                                     //круг

        public SnakeModel(string type, string direction, int x, int y)
        {
            Type = type;
            this.x = x;
            this.y = y;
            Direction = direction;

            rectangle = new Rectangle();
            rectangle.Width = 10;
            rectangle.Height = 10;
            rectangle.Fill = Brushes.Gold;

            ellipse = new Ellipse();
            ellipse.Width = 10;
            ellipse.Height = 10;
            ellipse.Fill = Brushes.White;
        }
    }
}
