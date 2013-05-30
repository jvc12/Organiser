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
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Microsoft.SqlServer;


namespace Organiser
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            string ConString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                
                /*CmdString = "SELECT * FROM test";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("test");
                sda.Fill(dt);
                dataGrid1.ItemsSource = dt.DefaultView;*/


                string sampleXmlFile = @".\data.xml";
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(sampleXmlFile);
                DataView dataView = new DataView(dataSet.Tables[0]);
                dataGrid1.ItemsSource = dataView;



            }



 
        }
    }
}
