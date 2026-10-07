using System.Text.Json;
using AssignmentEighteen.IOHelper;

namespace AssignmentEighteen.Task4
{
    /// <summary>
    ///  Represents the analysis of the data.
    /// </summary>
    public class DataAnalyser
    {
        /// <summary>
        /// Analyse the data and display the number of key value pairs.
        /// </summary>
        /// <returns>Task object</returns>
        public async Task AnalyseDataAsync()
        {
            long result = await this.MethodCAsync();
            ConsolePresenter.DisplayMessage($"The number of key value pairs is {result}");
        }

        /// <summary>
        /// Represents the large CPU bound operation.
        /// </summary>
        /// <returns>URL for web service call.</returns>
        public async Task<string> MethodAAsync()
        {
            ConsolePresenter.DisplayMessage($"Method A : Performing CPU bound operation.");
            for (long i = 0; i < 500000000; i++)
            {
            }

            // Given just for suppress warning.
            await Task.Delay(1000);
            ConsolePresenter.DisplayMessage($"Method A : Completed the CPU bound operation. Returning the URL");
            return "https://openlibrary.org/search.json?q=the+lord+of+the+rings";
        }

        /// <summary>
        /// Gets the response from the URL.
        /// </summary>
        /// <returns>Response from the API.</returns>
        public async Task<string> MethodBAsync()
        {
            ConsolePresenter.DisplayMessage($"Method B : Calling Method A to get the URL");
            string url = await this.MethodAAsync();
            ConsolePresenter.DisplayMessage($"Method B : Got the URL : {url}");

            using HttpClient client = new HttpClient();
            string response = await client.GetStringAsync(url);
            ConsolePresenter.DisplayMessage("Method B : Sending the Response to the Method C");
            return response;
        }

        /// <summary>
        ///  Caculates the number of key value pairs in the response.
        /// </summary>
        /// <returns>Number of key value pairs in the response.</returns>
        public async Task<long> MethodCAsync()
        {
            ConsolePresenter.DisplayMessage($"Method C : Getting response from the Method B");
            string json = await this.MethodBAsync();

            ConsolePresenter.DisplayMessage("Method C : Started processing Json...");

            using JsonDocument document = JsonDocument.Parse(json);

            long count = 0;
            foreach (JsonProperty property in document.RootElement.EnumerateObject())
            {
                count++;
            }

            return count;
        }
    }
}
