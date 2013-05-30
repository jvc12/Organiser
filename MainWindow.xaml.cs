using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using System.Speech.Synthesis;
using System.Xml;
using System.IO;
using Microsoft.Xml.XQuery;
using System.Web;


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
        }

        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            
            this.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)(() =>
            {
                DateTime now1 = DateTime.Now;
                string strTime = now1.ToShortTimeString();
                //Display time in the window
                textBlock1.Text = strTime; 
                string strdate = now1.ToShortDateString();                
                
                /*
                 * 
                 * Check the values accordingly
                DateTime productDate = DateTime.Now;

                // write only date

                string txtProductDate = productDate.ToShortDateString();

                // set the value in 12 hour format

                string twelveHourFormatHour = int.Parse(productDate.ToString("hh")).ToString();

                // set the value in 24 hour format

                string twentyFourHourFormatHour = int.Parse(productDate.ToString("HH")).ToString();

                // set the minute

                string minutes = productDate.ToString("mm");

                // get the AM and PM

                string ampm = productDate.ToString("tt");

                MessageBox.Show(txtProductDate);
                MessageBox.Show(twelveHourFormatHour);
                MessageBox.Show(twentyFourHourFormatHour);
                MessageBox.Show(minutes);
                MessageBox.Show(ampm);
                
                 * 
                 * 
                 *********************************************************/
                /*SpeechSynthesizer obj = new SpeechSynthesizer();
                obj.Speak("Your reminder for" + strdate + " named " + textBox1.Text); //can be used to notify the user by audio conformation*/

                //MessageBox.Show("Your reminder for" + strdate + "named " + textBox1.Text);//Pop up message for visual conformation
                

                //Retrieve data from XML document


            }));
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            string theDate = datePicker1.ToString();
            /*MessageBox.Show(theDate);
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into test select '" + theDate + "','" + textBox2.Text + "','" +textBox1.Text+ "'", con);  
            cmd.ExecuteNonQuery();
            MessageBox.Show("Reminder is set Successfully on "+theDate); //Show message box
            con.Close();  // Closes the connection*/

             //SpeechSynthesizer obj = new SpeechSynthesizer();
             //obj.Speak("Your reminder for" + textBox1.Text+"is set on"+ theDate + "at" +textBox2.Text);


             
             if (File.Exists("./data.xml")) 
                {
                    //MessageBox.Show("yay file found");

                   XmlDocument oXmlDocument = new XmlDocument();
                   oXmlDocument.Load(@".\data.xml");
                   XmlNode oXmlRootNode = oXmlDocument.SelectSingleNode("records");
                   XmlNode oXmlRecordNode = oXmlRootNode.AppendChild(
                     oXmlDocument.CreateNode(XmlNodeType.Element, "record", ""));
                      oXmlRecordNode.AppendChild(oXmlDocument.CreateNode(XmlNodeType.Element,
                     "Date", "")).InnerText = datePicker1.Text;
                      oXmlRecordNode.AppendChild(oXmlDocument.CreateNode(XmlNodeType.Element,
                     "Time", "")).InnerText = textBox2.Text;
                      oXmlRecordNode.AppendChild(oXmlDocument.CreateNode(XmlNodeType.Element,
                      "Name", "")).InnerText = textBox1.Text;
                       oXmlDocument.Save(@".\data.xml");
                       MessageBox.Show("The reminder was set succesfully");
                   
             }  
             else
             {
                 //MessageBox.Show("You are fooled by this application");
                 StringWriter stringwriter = new StringWriter();
                 XmlTextWriter xmlTextWriter = new XmlTextWriter(stringwriter);
                 xmlTextWriter.Formatting = Formatting.Indented;
                    xmlTextWriter.WriteStartDocument();
                    xmlTextWriter.WriteStartElement("records");
                    xmlTextWriter.WriteEndElement();            
                    xmlTextWriter.WriteEndDocument();
                    XmlDocument docSave = new XmlDocument();
                    docSave.LoadXml(stringwriter.ToString());
                    //write the path where you want to save the Xml file
                    docSave.Save(@".\data.xml");
                   //document saved
                    XmlDocument oXmlDocument = new XmlDocument();
                    oXmlDocument.Load(@".\data.xml");
                    XmlNode oXmlRootNode = oXmlDocument.SelectSingleNode("records");
                    XmlNode oXmlRecordNode = oXmlRootNode.AppendChild(
                      oXmlDocument.CreateNode(XmlNodeType.Element, "record", ""));
                    oXmlRecordNode.AppendChild(oXmlDocument.CreateNode(XmlNodeType.Element,
                   "Date", "")).InnerText = datePicker1.Text;
                    oXmlRecordNode.AppendChild(oXmlDocument.CreateNode(XmlNodeType.Element,
                   "Time", "")).InnerText = textBox2.Text;
                    oXmlRecordNode.AppendChild(oXmlDocument.CreateNode(XmlNodeType.Element,
                    "Name", "")).InnerText = textBox1.Text;

                    oXmlDocument.Save(@".\data.xml");
                    MessageBox.Show("The reminder was set succesfully");
                  
             }
            //Storing data in local XML document

             XmlDocument doc = new XmlDocument();
             doc.Load(@".\data.xml");
             var orderids = from order in
                                doc.Descendants("OrderId")
                            select new
                            {
                                OrderId = order.Value
                            };

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
