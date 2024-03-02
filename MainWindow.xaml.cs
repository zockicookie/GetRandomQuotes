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

        private string _responseData;

        private readonly ApiController _apiController;

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

                var quote = JsonConvert.DeserializeObject<List<Quote>>(_responseData);

                if (quote != null && quote.Count > 0)
                {
                    Quote quote1 = new Quote();
                    quote1 = quote[0];

                    txtMain.Text = $"\"{quote1.quote}\"\n\n-{quote1.author}\n\nCategory: {quote1.category}";
                }
                else
                {
                    MessageBox.Show("No quotes found in the response.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}