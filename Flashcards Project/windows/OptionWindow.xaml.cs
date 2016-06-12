using System.Windows;

namespace Flashcards_Project.windows
{
    /// <summary>
    ///     Interaction logic for OptionWindow.xaml
    /// </summary>
    public partial class OptionWindow : Window, IAppWindow
    {
        public OptionWindow()
        {
            InitializeComponent();
        }

        public void Back()
        {
            var main = new MainWindow();
            main.Show();
            Close();
        }

        public void Info()
        {
            MessageBox.Show(this, "Graphic design: Patryk Podworski\n" +
                                  "Sound efects: Patryk Podworski\n" +
                                  "Idea: Patryk Podworski", "Authors",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void VolumeButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeVolume();
        }

        private void ChangeVolume()
        {
            MessageBox.Show(this, "There is no sound!", "Lol", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }

        private void AuthorsButton_Click(object sender, RoutedEventArgs e)
        {
            Info();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Back();
        }
    }
}