using AssignmentEighteen.Enums;
using AssignmentEighteen.InputHelper;
using AssignmentEighteen.IOHelper;
using AssignmentEighteen.Task1;
using AssignmentEighteen.Task2;
using AssignmentEighteen.Task3;
using AssignmentEighteen.Task4;
using AssignmentEighteen.Task5;
using AssignmentEighteen.Task6;
using AssignmentEighteen.Task7;

namespace AssignmentEighteen
{
    /// <summary>
    /// Gets the Input and navigates to the desired task.
    /// </summary>
    public class TaskNavigator
    {
        private WebsiteScrapper _scrapper = new WebsiteScrapper();
        private ArrayManager _arrayManager = new ArrayManager();
        private ThreadImplementation _threadImplemtation = new ThreadImplementation();
        private DataAnalyser _dataAnalyser = new DataAnalyser();
        private DeadlockRecoverer _deadlockRecoverer = new DeadlockRecoverer();
        private ConfigureAwaitManager _configureAwaitManager = new ConfigureAwaitManager();
        private ExceptionHandler _exceptionHandler = new ExceptionHandler();

        /// <summary>
        /// Navigates the menu.
        /// </summary>
        /// <returns>Task object.</returns>
        public async Task NavigateMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                this.DisplayMenu();
                bool validOption = InputReader.GetInput<MenuOptions>("Enter your option : ", Validator.ValidateEnumOption<MenuOptions>, out MenuOptions option);
                if (!validOption)
                {
                    return;
                }

                switch (option)
                {
                    case MenuOptions.WebsiteScrapping:
                        await this._scrapper.GetContentAsync();
                        break;
                    case MenuOptions.ArrayOperations:
                        this._arrayManager.SquareArray();
                        break;
                    case MenuOptions.MultiThreading:
                        this._threadImplemtation.RunThread();
                        break;
                    case MenuOptions.DataAnalyser:
                        await this._dataAnalyser.AnalyseDataAsync();
                        break;
                    case MenuOptions.DeadLockAnalyser:
                        await this._deadlockRecoverer.DeadlockMethodAsync();
                        break;
                    case MenuOptions.ConfigureAwaitManager:
                        await this._configureAwaitManager.MethodBAsync();
                        break;
                    case MenuOptions.ExceptionHandler:
                        await this._exceptionHandler.HandleExceptionAsync();
                        break;
                    case MenuOptions.Exit:
                        isRunning = false;
                        break;
                }
            }
        }

        private void DisplayMenu()
        {
            string menu = "\n=====================================" +
                          "\n1.Scrape Data from website." +
                          "\n2.Perform Array operations." +
                          "\n3.MultiThreading." +
                          "\n4.Analyse data." +
                          "\n5.Analyse and recover the deadlock." +
                          "\n6.Configure await" +
                          "\n7.Exception Handler." +
                          "\n8.Exit" +
                          "\n=====================================";
            ConsolePresenter.DisplayMessage(menu);
        }
    }
}
