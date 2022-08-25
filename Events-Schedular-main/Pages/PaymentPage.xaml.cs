using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
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

namespace UIKitTutorials.Pages
{
    /// <summary>
    /// Lógica de interacción para PaymentPage.xaml
    /// </summary>
    public partial class PaymentPage : Page
    {
         static List<task> tasks;
        public PaymentPage()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private async void Border_Loaded(object sender, RoutedEventArgs e)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost/datastructure/get_tasks.php");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("").Result;

            if (response.IsSuccessStatusCode)
            {
                 tasks = await response.Content.ReadAsAsync<List<task>>();
                foreach (task s in tasks)
                {

                    comboBox1.Items.Add(s.name);

                }
            }
        }
        class task
        {
            public String id { get; set; }
            public String name { get; set; }
            public String user { get; set; }
            public string startDate { get; set; }
            public string startTime { get; set; }
            public string endDate { get; set; }
            public string endTime { get; set; }
            public string remainingTime { get; set; }
            public string shownStartTime { get; set; }
            public string shownEndTime { get; set; }
            public string status { get; set; }
            public DateTime sortTime { get; set; }
        }


        class Response
        {
            public Dictionary<String, dynamic> data;
            public String msg;
            public String result;
        }



        private async  void show_data(object sender, EventArgs e)
        {
           

            foreach (task data in tasks)
            { if (data.name == comboBox1.Text)
                {
                    name.Text = data.name;
                    user.Text = data.user;
                    start_date.Text = data.startDate;
                    start_time.Text = data.startTime;
                    iD.Text = data.id;
                    end_date.Text = data.endDate;
                    end_time.Text = data.endTime;
                    break;
                }
            

            }

        }


        public void update_data(object sender, EventArgs e) {

            var seleted_name = comboBox1.Text;
            var Name = name.Text;
            var User = user.Text;
            var Date = start_date.Text;
            var Time = start_time.Text;
            var id=iD.Text;
            var enddat = end_date.Text;
            var endTim = end_time.Text;
            foreach (task u in tasks) {

                if (u.name == seleted_name) {
                    u.name = Name;
                    u.user = User;
                    u.startDate = Date;
                    u.startTime = Time;
                    u.endTime = enddat;
                    u.endDate = endTim;
                
                    break;

                }
            
            
            }


            var formcontent = new FormUrlEncodedContent(new[]
           {
                new KeyValuePair<string,string>("id",id),
                new KeyValuePair<string,string>("name",Name),
                new KeyValuePair<string,string>("user",User),
                new KeyValuePair<string,string>("date",Date),
                new KeyValuePair<string,string>("time",Time),
                new KeyValuePair<string,string>("endTime",endTim),
                new KeyValuePair<string,string>("endDate",enddat)
              });

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost/datastructure/Update_task.php");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response =  client.PostAsync(client.BaseAddress, formcontent).Result;
            if (response.IsSuccessStatusCode) {


                MessageBox.Show("task updated successfully ");
                name.Clear();
                user.Clear(); 
                start_date.Clear();
                start_time.Clear();
                iD.Clear();
                end_date.Clear();
                end_time.Clear();


            }
        }
    }
}