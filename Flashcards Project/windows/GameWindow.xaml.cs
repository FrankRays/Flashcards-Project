using System.Windows;
using System.Windows.Media;
using Flashcards_Project.logic;

namespace Flashcards_Project.windows
{
    /// <summary>
    ///     Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window, IAppWindow
    {
        public GameWindow(GameType Game)
        {
            InitializeComponent();
            this.Game = Game;
            this.Game.LoadFlashcards(this);
            Update();
        }

        public GameType Game { get; set; }

        public void Info()
        {
            Game.ShowGameInfo(this);
        }

        public void Back()
        {
            var window = new MainWindow();
            window.Show();
            Close();
        }

        private void Update()
        {
            CardsLabel.Content = Game.GetCardsLeftLabelContent();
            LivesLabel.Content = Game.GetLivesLeftLabelContent();
            Answerbox.Text = "";
            FlashcardLabel.Content = Game.GetCurrentFlashcard().Front;
        }

        private void AnswerButton_Click(object sender, RoutedEventArgs e)
        {
            Action(ActionOption.Answer);
        }

        private void Over()
        {
            MessageBox.Show(this, Game.GetOverMessage(), "Game Over",
                MessageBoxButton.OK, MessageBoxImage.Information);

            Back();
        }

        private void GiveUpButton_Click(object sender, RoutedEventArgs e)
        {
            Action(ActionOption.GiveUp);
        }

        private void WtfButton_Click(object sender, RoutedEventArgs e)
        {
            Info();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(this, "Are you sure you want to exit?", "Exit",
                MessageBoxButton.OKCancel, MessageBoxImage.Question);

            if (result != MessageBoxResult.OK) return;

            Back();
        }

        private void Action(ActionOption option)
        {
            bool result;

            switch (option)
            {
                case ActionOption.Answer:
                    result = Game.CheckAnswer(Answerbox.Text);
                    NotifyAnswer(result);
                    break;
                case ActionOption.GiveUp:
                    ShowCorrectAnswer();
                    result = Game.CheckAnswer(null);
                    break;
                default:
                    result = false;
                    break;
            }

            if (Game.IsOver)
            {
                Over();
            }

            Update();
        }

        private void ShowCorrectAnswer()
        {
            NotificationLabel.Foreground = Brushes.Red;
            NotificationLabel.Content = Game.GetCurrentFlashcard().Back;
        }

        private void NotifyAnswer(bool answer)
        {
            if (answer)
            {
                NotificationLabel.Foreground = Brushes.Green;
                NotificationLabel.Content = "Goodjob!";
            }
            else
            {
                NotificationLabel.Foreground = Brushes.Red;
                NotificationLabel.Content = "Wrong answer!";
            }
        }
    }

    internal enum ActionOption
    {
        Answer,
        GiveUp
    }
}