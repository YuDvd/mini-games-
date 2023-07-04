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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using MiniGames.Model;
using System.IO;
using System.Windows.Controls.Primitives;

namespace MiniGames
{
    /// <summary>
    /// Логика взаимодействия для Tag.xaml
    /// </summary>
    public partial class Tag : MetroWindow
    {
        public static string connectionSource = @"WIN-G1TEAHN2ED8\SQLEXPRESS";

        TagModel model;
        TagRecord Record = new TagRecord();
        

        DateTime start;
        DispatcherTimer timer = new DispatcherTimer();
        

        public Tag()
        {
            InitializeComponent();
            model = new TagModel();
            new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "Images/bachTags.jpg")));
            
            model.WinComplete += Model_WinComplete;
            start = DateTime.Now;
            model.ShiftRandom();

            timer.Tick += Timer_Tick;
            timer.Interval = TimeSpan.FromMilliseconds(0.001);
            timer.Start();
        }
        /// <summary>
        /// Метод, схораняющий данные в базу данных
        /// </summary>
        private  void SaveFileToDatabase()
        {
            string connectionString = $"Data Source={connectionSource};Initial Catalog=Record_bd;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;             
                command.CommandText = @"INSERT INTO [dbo].[Record_table] VALUES (@Date, @Time, @Pos)";
                command.Parameters.Add("@Date", SqlDbType.NVarChar, 50);
                command.Parameters.Add("@Time", SqlDbType.NVarChar, 50);
                command.Parameters.Add("@Pos", SqlDbType.Int, 1000000);

                List<TagRecord> record = new List<TagRecord>();

                // Date
                string Date = DateTime.Now.ToString();
                // Время прохождения
                string Time = tblTimer.Text;
                // Позиция
                int Pos = Record.Pos;
                
                

                // передаем данные в команду через параметры
                command.Parameters["@Pos"].Value = GameResultOutput();
                command.Parameters["@Time"].Value = Time;
                command.Parameters["@Date"].Value = Date;


                var r = new TagRecord()
                {
                    Date = Date,
                    Time = Time,
                };
                record.Add(r);
                var ordList = record.OrderBy(x => x.Time)
                    .Select((x, i) => { x.Date.ToString() ; return x; })
                    .Take(10)
                    .ToArray();

                records.ItemsSource = ordList;

                command.ExecuteNonQuery();

                connection.Close();
            }
        }
        /// <summary>
        /// Метод, который берет Id из базы данных и возаращает его
        /// </summary>
        /// <returns></returns>
        public static int GameResultOutput()
        {
            string connectionString = $"Data Source={connectionSource};Initial Catalog=Record_bd;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            SqlCommand command = new SqlCommand();
            command.CommandText = @"SELECT TOP 1 Id FROM [Record_bd].[dbo].[Record_table] ORDER BY Id DESC";
            //command.CommandText = @"SELECT Id FROM [Record_bd].[dbo].[Record_table] ORDER BY Id DESC";
            command.Connection = sqlConnection;
            string value = command.ExecuteScalar().ToString();
            int id = Convert.ToInt32(value);
            sqlConnection.Close();
            return id;
        }
        //public static string StatisticaBd()
        //{
        //    string connectionString = @"Data Source=WIN-G1TEAHN2ED8\SQLEXPRESS;Initial Catalog=Record_bd;Integrated Security=True";
        //    SqlConnection sqlConnection = new SqlConnection(connectionString);
        //    sqlConnection.Open();
        //    SqlCommand command = new SqlCommand();
        //    command.CommandText = "SELECT TOP(1000) [Id] ,[Date] ,[Time] ,[Pos] FROM[Record_bd].[dbo].[Record_table]";
        //    command.Connection = sqlConnection;

        //    string value = command.ExecuteScalar().ToString();
        //    return value;
        //}
        private void BtnAgain_Click(object sender, RoutedEventArgs e)
        {
            Tag tag = new Tag();
            tag.Show();

            Close();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            tblTimer.Text = (DateTime.Now - start).ToString(@"mm\:ss\.f");
        }
        private void Model_WinComplete(object sender, EventArgs e)
        {
            brd.Visibility = Visibility.Visible;
            timer.Stop();


            SaveFileToDatabase();  

        }


        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            StartGame();          
        }

        private void StartGame()
        {
            model.Start();
            for (int i = 0; i < 200; i++)
                model.ShiftRandom();
            RefreshButton();
        }
        /// <summary>
        /// Обновление кнопок
        /// </summary>
        private void RefreshButton()
        {
            for (int pos = 0; pos < 16; pos++)
            {
                int number = model.GetNumber(pos);
                FuncButton(pos).Content = number.ToString();
                if (number > 0)
                    FuncButton(pos).Visibility = Visibility.Visible;
                else if (number == 0)
                    FuncButton(pos).Visibility = Visibility.Collapsed;

            }
        }
        /// <summary>
        /// Основная логика игры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Logics_Click(object sender, RoutedEventArgs e)
        {
            int position = Convert.ToInt16(((Button)sender).Tag);
            model.Shift(position);
            RefreshButton();
            if (model.CheckNumber())
            {
                brd.Visibility = Visibility.Visible;
            }
        }

        private Button FuncButton(int position)
        {
            switch (position)
            {
                case 0: return button0;
                case 1: return button1;
                case 2: return button2;
                case 3: return button3;
                case 4: return button4;
                case 5: return button5;
                case 6: return button6;
                case 7: return button7;
                case 8: return button8;
                case 9: return button9;
                case 10: return button10;
                case 11: return button11;
                case 12: return button12;
                case 13: return button13;
                case 14: return button14;
                case 15: return button15;
                default: return null;
            }
        }

        private void Click_Exit(object sender, RoutedEventArgs e)
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

