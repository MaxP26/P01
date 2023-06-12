using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
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
using WebApplicationAPIDemo.Models;

namespace WpfAppApiDb
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly HttpClient httpClient;


        public MainWindow()
        {
            InitializeComponent();
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:7215");
            httpClient.DefaultRequestHeaders.Add("login", "Ivan");
        }

        void UpdateDatagrid()
        {
            var wt = httpClient.GetAsync("api/students");
            wt.Wait();
            var response = wt.Result;
            if (response.IsSuccessStatusCode)
            {
                var wt1 = response.Content.ReadFromJsonAsync<IEnumerable<Student>>();
                wt1.Wait();
                var collection = wt1.Result;
                dg.ItemsSource = new ObservableCollection<Student>(wt1.Result);
            }

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var student = new Student { Name = "Peter", Surname = "Havatsko" };
            var wr = httpClient.PostAsJsonAsync("api/students", student);
            wr.Wait();
            UpdateDatagrid();


        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateDatagrid();
        }
    }
}
