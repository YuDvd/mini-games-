using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using System.Windows.Shapes;
using MiniGames.Model;
using System.Windows.Threading;
using System.Threading;
using System.Timers;
using System.Web.UI;
using Timer = System.Web.UI.Timer;

namespace MiniGames
{
    /// <summary>
    /// Логика взаимодействия для Snake.xaml
    /// </summary>
    public partial class Snake : MetroWindow
    {
        SnakeViewModel model = new SnakeViewModel();

        int Step = 0;

        

        DateTime start;
        DispatcherTimer timer = new DispatcherTimer();

        public Snake()
        {
            InitializeComponent();


            

            start = DateTime.Now;

            timer.Tick += Timer_Tick;
            timer.Interval = TimeSpan.FromMilliseconds(0.001);
            timer.Start();

            model.WinComplete += Model_WinComplete;


            DataContext = new SnakeViewModel();

            Messenger.Default.Register<CloseSnakeMessage>(this, CloseSnake);
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            tblTimer.Text = (DateTime.Now - start).ToString(@"mm\:ss\.f");
            tblScore.Text = model.Score.ToString();
        }

        private void Model_WinComplete(object sender, EventArgs e)
        {
            if (model.GameOver == true)
            {
                brd.Visibility = Visibility.Visible;
                canvas.Visibility = Visibility.Collapsed;
                timer.Stop();

                Step = model.Score;
                SaveFileToDatabase();

            }
            
        }
        private void SaveFileToDatabase()
        {
            string connectionString = @"Data Source=WIN-G1TEAHN2ED8\SQLEXPRESS;Initial Catalog=Record_bd;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = @"INSERT INTO [dbo].[Snake_Table] VALUES (@Step)";
                command.Parameters.Add("@Step", SqlDbType.Int, 10000);

                List<SnakeRecord> record = new List<SnakeRecord>();
                // Шаги              
                //SnakeViewModel snake = new SnakeViewModel();
                //tblScore.Text = model.Score.ToString();
                //Dispatcher.Invoke(new Action(delegate ()
                //{

                ////}));
                //int Step = Convert.ToInt32(tblScore.Text);
                
                // передаем данные в команду через параметр
                command.Parameters["@Step"].Value = Step;

                var r = new SnakeRecord()
                {
                    Step = Step,
                };

                record.Add(r);
                var ordList = record.OrderBy(x => x.Step)
                    .Select((x, i) => { x.SnakeId = i + 1; return x; })
                    .Take(5)
                    .ToArray();

                records.ItemsSource = ordList;
                //records.ItemsSource = record;

                command.ExecuteNonQuery();
                
                connection.Close();

            }
        }
        void CloseSnake(CloseSnakeMessage obj)
        {
            Close();
        }

        private void Window_Keypressed(object sender, KeyEventArgs e)
        {
            Messenger.Default.Send(new KeyPressedMessage() { keyEventArgs = e });
        }


        private void Restart_Game(object sender, RoutedEventArgs e)
        {

            Snake snake = new Snake();
            snake.Show();

            Close();
        }

        private void Close_Snake(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Click_Menu(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
