using Newtonsoft.Json;
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
using YourWpfAppNamespace;

namespace GetRandomQuotes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {

        private readonly ApiController _apiController;
        private readonly JsonController _jsonController = new JsonController();

        private Quote _quote = new Quote();    

        public MainWindow()
        {
            InitializeComponent();
            _apiController = new ApiController();
            FetchApiResponse();
        }

        private async void FetchApiResponse()
        {
            try
            {
                _responseData = await _apiController.GetApiResponseAsync();
                WindowSetup(_responseData);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void WindowSetup(string _responseData)
        {
            List<Quote> quotes = JsonConvert.DeserializeObject<List<Quote>>(_responseData);

            foreach (var quote in quotes)
            {
                txtMain.Text = quote.QuoteText;
            }
        }

    }
}