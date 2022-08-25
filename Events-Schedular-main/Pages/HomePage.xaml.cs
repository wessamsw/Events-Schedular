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
    public static class ObjectExtensions
    {
        public static T ToObject<T>(this IDictionary<string, object> source)
            where T : class, new()
        {
            var someObject = new T();
            var someObjectType = someObject.GetType();

            foreach (var item in source)
            {
                someObjectType
                         .GetProperty(item.Key)
                         .SetValue(someObject, item.Value, null);
            }


            return someObject;
        }

        public static IDictionary<string, object> AsDictionary(this object source, BindingFlags bindingAttr = BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance)
        {
            return source.GetType().GetProperties(bindingAttr).ToDictionary
            (
                propInfo => propInfo.Name,
                propInfo => propInfo.GetValue(source, null)
            );

        }
    }


    public partial class HomePage : Page
    {

        static List<task> tasks;
        static List<task> finishedTasks = new List<task>();
        public HomePage()
        {
            InitializeComponent();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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

     
        private void lst_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void delete_task(object sender, RoutedEventArgs e) {



            Button b = sender as Button;
            task u = b.CommandParameter as task;
            lst.Items.Remove(u);
            var id = u.id;
            for (int i = 0; i < tasks.Count; i++)
            { if (tasks[i].id == u.id) {

                    tasks.RemoveAt(i);
                    lst.Items.Clear();
                    foreach (task s in tasks) {
                      
                        DateTime dt = Convert.ToDateTime(string.Format("{0} {1}", s.startDate, s.startTime));
                        string dateShow = dt.ToString();
                        DateTime dt2 = Convert.ToDateTime(string.Format("{0} {1}", s.endDate, s.endTime));
                        string endDateShow = dt.ToString();


                        lst.Items.Add(new task() { name = s.name, id = s.id, user = s.user, shownStartTime = dateShow ,shownEndTime=endDateShow, status=s.status});


                    }

                }

            }

            var formcontent = new FormUrlEncodedContent(new[]
       {
                new KeyValuePair<string,string>("id",id)
           
              });

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost/datastructure/delete_task.php");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.PostAsync(client.BaseAddress, formcontent).Result;
            if (response.IsSuccessStatusCode) {

                MessageBox.Show("event deleted ");

            
            
            }




        }


        private void sort_events(object sender, RoutedEventArgs e) {


            var Orderedtasks = from x in tasks
                               orderby x.sortTime
                               select x;
            Orderedtasks.ToList();
            lst.Items.Clear();
            foreach (task s in Orderedtasks) {
                DateTime dt2 = Convert.ToDateTime(string.Format("{0} {1}", s.endDate, s.endTime));
                string endDateShow = dt2.ToString();
                DateTime dt1 = Convert.ToDateTime(string.Format("{0} {1}", s.startDate, s.startTime));
                string dateShow1 = dt1.ToString();
                TimeSpan ts = dt1 - DateTime.Today;
                string timere = string.Format(" {0} days {1} hours ", ts.Days, ts.Hours);
                lst.Items.Add(new task() { name = s.name, id = s.id, user = s.user, shownStartTime = dateShow1, shownEndTime = endDateShow, status = s.status, remainingTime = timere });

            }

        }


        private async void load_tasks(object sender, RoutedEventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost/datastructure/get_tasks.php");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("").Result;
            if (response.IsSuccessStatusCode)
            {
                tasks = await response.Content.ReadAsAsync<List<task>>();
                List<task> tobeRemoved = new List<task>();
                foreach (task s in tasks)
                {


                    DateTime dt = Convert.ToDateTime(string.Format("{0} {1}", s.startDate, s.startTime));
                    s.sortTime = dt;
                    string dateShow = dt.ToString();
                    if (dt < DateTime.Today)
                    {
                        if (MessageBox.Show("Event: " + s.name + " has eneded did you attend it or not " + s.user, "event ended", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        {
                            task u = new task();
                            s.status = "attended"; 
                            u = s;
                            tobeRemoved.Add(s);
                            finishedTasks.Add(u);
                            MessageBox.Show(u.name);


                        }
                        else
                        {

                            task u = new task();
                            u = s;
                            tobeRemoved.Add(s);
                            finishedTasks.Add(u);

                        }


                    }
                    else {

                        DateTime dt2 = Convert.ToDateTime(string.Format("{0} {1}", s.endDate, s.endTime));
                        string endDateShow = dt2.ToString();
                        DateTime dt1 = Convert.ToDateTime(string.Format("{0} {1}", s.startDate, s.startTime));
                        string dateShow1 = dt1.ToString();
                        TimeSpan ts = dt1- DateTime.Today;
                       string timere =string.Format(" {0} days {1} hours ", ts.Days,ts.Hours);

                        lst.Items.Add(new task() { name = s.name, id = s.id, user = s.user, shownStartTime = dateShow1, shownEndTime = endDateShow, status = s.status ,remainingTime=timere });

                    }






                }
                tasks.RemoveAll(x => tobeRemoved.Contains(x));
            }

        }


        private void load_ended(object sender, RoutedEventArgs e)
        {

            lst.Visibility = System.Windows.Visibility.Hidden;
            lst_completed.Visibility = System.Windows.Visibility.Visible;
            foreach (task s in finishedTasks) {
                DateTime dt2 = Convert.ToDateTime(string.Format("{0} {1}", s.endDate, s.endTime));
                string endDateShow = dt2.ToString();
                DateTime dt1 = Convert.ToDateTime(string.Format("{0} {1}", s.startDate, s.startTime));
                string dateShow1 = dt1.ToString();

                lst_completed.Items.Add(new task() { name = s.name, id = s.id, user = s.user, shownStartTime = dateShow1, shownEndTime = endDateShow, status = s.status });

            }



        }
    }


    }
