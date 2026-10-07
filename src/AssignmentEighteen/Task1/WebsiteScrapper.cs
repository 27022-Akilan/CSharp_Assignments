using AssignmentEighteen.IOHelper;

namespace AssignmentEighteen.Task1
{
    /// <summary>
    /// Represents the functionalities to get the data from the Website using the url.
    /// </summary>
    public class WebsiteScrapper
    {
        /// <summary>
        /// Gets the content from the website.
        /// </summary>
        /// <returns>A task object.</returns>
        public async Task GetContentAsync()
        {
            HttpClient client = new HttpClient();
            string url = "https://openlibrary.org/search.json?q=the+lord+of+the+rings";
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                ConsolePresenter.DisplayMessage($"Content on the URL  [{url}] is : ");
                ConsolePresenter.DisplayMessage(new string('=', Console.WindowWidth));
                ConsolePresenter.DisplayMessage(json.Substring(0, 300));
                ConsolePresenter.DisplayMessage(new string('=', Console.WindowWidth));
            }
            else
            {
                ConsolePresenter.DisplayMessage($"Cant fetch from [{url}] at this moment");
            }
        }
    }
}
