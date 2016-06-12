using System.Windows;

namespace Flashcards_Project.windows
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IAppWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void Back()
        {
            Application.Current.Shutdown();
        }

        public void Info()
        {
            MessageBox.Show(this, "Flashcards is a game-like method to learn new words!", "About", MessageBoxButton.OK,
                MessageBoxImage.Information);
        }

        private void TestButton_Click(object sender, RoutedEventArgs e)
        {
            Test();
        }

        private void TrainingButton_Click(object sender, RoutedEventArgs e)
        {
            Training();
        }

        private void OptionsButton_Click(object sender, RoutedEventArgs e)
        {
            Options();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Back();
        }

        private void Test()
        {
            var window = new TestWindow();
            window.Show();
            Close();
        }

        private void Options()
        {
            var window = new OptionWindow();
            window.Show();
            Close();
        }

        private void AboutButton_Click(object sender, RoutedEventArgs e)
        {
            Info();
        }

        private void Training()
        {
            var window = new TrainingWindow();
            window.Show();
            Close();
        }
    }
}