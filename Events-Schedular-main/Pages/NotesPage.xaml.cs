using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using Newtonsoft.Json;
namespace UIKitTutorials.Pages
{
    /// <summary>
    /// Lógica de interacción para NotesPage.xaml
    /// </summary>
    public partial class NotesPage : Page
    {
        static List<task> tasks;
        public NotesPage()
        {
            InitializeComponent();
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


        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default["username"] = "seif";
            var name = name_txt.Text;
            var user = Properties.Settings.Default["username"].ToString(); ;
            var start = start_date_txt.Text;
            var endDate = end_date_txt.Text;
            var time = time_txt.Text;
            var endTime = end_time_txt.Text;
            bool intersects = false ;
            foreach (task s in tasks) {
                if (start == s.startDate && time == s.startTime) {
                    MessageBox.Show("this event intersects with another event please change the date or time");
                    intersects = true;
                   
                }
            
            
            }

            if (intersects == false ) {

             

                var formcontent = new FormUrlEncodedContent(new[]
               {
                new KeyValuePair<string,string>("user",user),
                new KeyValuePair<string, string>("date", start),
                new KeyValuePair<string, string>("name", name ),
                new KeyValuePair<string, string>("time", time ),
                new KeyValuePair<string, string>("endTime", endTime ),
                new KeyValuePair<string, string>("endDate", endDate )

              });

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost/datastructure/new_task.php");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsync(client.BaseAddress, formcontent).Result;
                string answer = await response.Content.ReadAsStringAsync();

                MessageBox.Show("task added successfuly ");
                name_txt.Clear();
                start_date_txt.Clear();
                end_date_txt.Clear();
                time_txt.Clear();
                end_date_txt.Clear();
                end_time_txt.Clear();







            }



        }

        class response 
        {
            public String answer  { get; set;}
        }

        private async void Border_Loaded_1(object sender, RoutedEventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost/datastructure/get_tasks.php");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("").Result;

            if (response.IsSuccessStatusCode)
            {
                tasks = await response.Content.ReadAsAsync<List<task>>();
            }
        }
    }



}
