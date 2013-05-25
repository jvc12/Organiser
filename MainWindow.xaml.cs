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

namespace Organiser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {


            DateTime now1 = DateTime.Now;
            string strDate = now1.ToShortTimeString();


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
    }
}
