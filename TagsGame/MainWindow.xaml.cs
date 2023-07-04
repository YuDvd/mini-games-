using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace MiniGames
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Images/bachTags.jpg")));
        }

        private void Button_Start_Tag(object sender, RoutedEventArgs e)
        {
            Tag tag = new Tag();
            tag.Show();

            Thread.Sleep(100);
            Close();
        }

        private void Button_Exit(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Start_Snake(object sender, RoutedEventArgs e)
        {
            Snake snake = new Snake();
            snake.Show();

            Thread.Sleep(100);
            Close();
        }
    }
}
