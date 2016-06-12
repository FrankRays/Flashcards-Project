using System.Windows;
using Flashcards_Project.logic;

namespace Flashcards_Project.windows
{
    /// <summary>
    ///     Interaction logic for TrainingWindow.xaml
    /// </summary>
    public partial class TrainingWindow : Window, IAppWindow
    {
        public TrainingWindow()
        {
            Game = new TrainingGame();
            InitializeComponent();
        }

        public TrainingGame Game { get; set; }

        public void Back()
        {
            var window = new MainWindow();
            window.Show();
            Close();
        }

        public void Info()
        {
            Game.ShowGameInfo(this);
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            bool isSet = Game.SetSourceFile();

            if (isSet)
            {
                var window = new GameWindow(Game);
                window.Show();
                Close();
            }
        }

        private void WtfButton_Click(object sender, RoutedEventArgs e)
        {
            Info();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Back();
        }
    }
}