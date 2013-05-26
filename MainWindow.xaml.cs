using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Threading;
using System.Windows.Threading;

namespace Organiser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Timers.Timer timer = new System.Timers.Timer(1000);

        public MainWindow()
        {

            InitializeComponent();
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
            timer.Enabled = true;
            /*while (true)
            {
                DateTime now1 = DateTime.Now;
                string strDate = now1.ToShortTimeString();
                textBlock1.Text = strDate;
            }*/
        }

        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            
            this.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)(() =>
            {
                DateTime now1 = DateTime.Now;
                string strDate = now1.ToShortTimeString();
                textBlock1.Text = strDate;
                /*secondHand.Angle = DateTime.Now.Second * 6;
                minuteHand.Angle = DateTime.Now.Minute * 6;
                hourHand.Angle = (DateTime.Now.Hour * 30) + (DateTime.Now.Minute * 0.5);*/
            }));
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            con.Open();
            //SqlCommand cmd = new SqlCommand("insert into organiser select '" + datePicker1.Text + "','" + textBox1.Text +"'", con);  // Sql query and connection object is assigned to SqlCommand object i.e. ‘cmd’.
            //SqlCommand cmd1 = new SqlCommand("insert into Organizer select '" + DateTimePicker1.Text +"'", con);
            //cmd.ExecuteNonQuery();   // SqlCommand is executed
            SqlCommand cmd = new SqlCommand("insert into Organizer select '" + DateTimePicker1.Text + "','" + textBox1.Text + "'", con);  
            cmd.ExecuteNonQuery();
            MessageBox.Show("Reminder is set Successfully on "+DateTimePicker1.Text); //Show message box
            con.Close();  // Closes the connection
           
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            var window = (Window)Application.LoadComponent(new Uri("Window1.xaml", UriKind.Relative));
            window.Show();
            
        }
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        

    }
}
