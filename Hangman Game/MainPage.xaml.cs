using System.ComponentModel;

namespace Hangman_Game
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {

        #region Fields

        List<string> words = new List<string>()
        {
            "python",
            "javascript",
            "maui",
            "csharp",
            "mongodb",
            "sql",
            "xaml",
            "word",
            "excel",
            "powerpoint",
            "code",
            "hotreload",
            "snippets"
        };

        private List<char> letters = new List<char>();

        public List<char> Letters { 
            get => letters;
            set
            {
                letters = value;
                OnPropertyChanged();
            }
        }


        private string message;

        public string Message
        {
            get => message;
            set
            {
                message = value;
                OnPropertyChanged();
            }
        }


        string answer = "";

        List<char> guessed = new List<char>();

        #endregion

        #region UI Property

        private string spotlight;

        public string Spotlight
        {
            get => spotlight;
            set
            {
                spotlight = value;
                OnPropertyChanged();
            }
        }


        #endregion


        #region Consractor

        public MainPage()
        {
            InitializeComponent();

            Letters.AddRange("abcdefghijklmnopqrstuvwxyz");

            BindingContext = this;

            PickWord();

            CalculateWord(answer, guessed);
        }

        #endregion

        #region Game Engine

        private void PickWord()
        {
            Random random = new Random();

            answer = words[random.Next(0, words.Count)];

        }

        private void CalculateWord(string answer, List<char> guessed)
        {
            var temp = answer.Select(c => (guessed.IndexOf(c) >= 0 ? c : '_' )).ToArray();

            Spotlight = string.Join(' ', temp);
        }

        private void HandleGuess(char letter)
        {
            if(guessed.IndexOf(letter) == -1)
            {
                // Add letter to guessed list if not already guessed
                guessed.Add(letter);
            }

            if (answer.IndexOf(letter) >= 0)
            {
                // Correct guess
                CalculateWord(answer, guessed);
                CheckIfGameWon();
            }
            else
            {
                // Incorrect guess
                // Handle incorrect guess logic here (e.g., decrement lives, show message, etc.)
            }
        }

        private void CheckIfGameWon()
        {
            if (Spotlight.Replace(" ", "") == answer)
            {
                // Game won logic here (e.g., show message, reset game, etc.)
                message = "Congratulations! You've won!";
            }
        }

        #endregion

        private void Button_Clicked(object sender, EventArgs e)
        {
            var btn = sender as Button;

            if (btn != null)
            {
                var letter = btn.Text;
                btn.IsEnabled = false;

                HandleGuess(letter[0]);
            }
        }

        
    }
}
