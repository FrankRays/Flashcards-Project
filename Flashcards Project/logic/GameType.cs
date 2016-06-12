using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using Flashcards_Project.windows;
using Microsoft.Win32;

namespace Flashcards_Project.logic
{
    public abstract class GameType
    {
        protected List<Flashcard> Flashcards;

        protected GameType()
        {
            IsOver = false;
            Flashcards = new List<Flashcard>();
        }

        public bool IsOver { get; protected set; }

        public string SourceDirectory { get; private set; }

        public abstract Flashcard GetCurrentFlashcard();
        protected abstract string GetGameInfo();
        public abstract string GetCardsLeftLabelContent();
        public abstract string GetLivesLeftLabelContent();

        public bool SetSourceFile()
        {
            var Dialog = new OpenFileDialog {Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"};

            bool? result = Dialog.ShowDialog();

            if (result == true)
            {
                SourceDirectory = Dialog.FileName;
                return true;
            }
            return false;
        }

        public void ShowGameInfo(Window window)
        {
            MessageBox.Show(window, GetGameInfo(), "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public virtual void LoadFlashcards(GameWindow window)
        {
            try
            {
                using (var reader = new StreamReader(SourceDirectory, Encoding.UTF8))
                {
                    string front;
                    string back;

                    while ((front = reader.ReadLine()) != null)
                    {
                        back = reader.ReadLine();
                        Flashcards.Add(new Flashcard(front, back));
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show(window, "Unable to load flashcards from file!", "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        public abstract void NextFlashcard();
        public abstract string GetOverMessage();
        public abstract bool CheckAnswer(string answer);
    }
}