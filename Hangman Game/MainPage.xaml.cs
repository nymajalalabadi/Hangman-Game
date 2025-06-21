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

        string answer = "";

        private string spotlight;

        List<char> guessed = new List<char>();

        #endregion

        #region UI Property

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

        #endregion
    }
}
