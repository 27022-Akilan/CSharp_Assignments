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
                Console.WriteLine($"Content on the URL  [{url}] is : ");
                Console.WriteLine(new string('=', Console.WindowWidth));
                Console.WriteLine(json.Substring(0, 300));
                Console.WriteLine(new string('=', Console.WindowWidth));
            }
            else
            {
                Console.WriteLine($"Cant fetch from [{url}] at this moment");
            }
        }
    }
}
