using System;
using Flashcards_Project.windows;

namespace Flashcards_Project.logic
{
    public class TestGame : GameType
    {
        public TestGame()
        {
            CardsLeft = GetStartingNumberOfCards();
            Lives = GetStartingNumberOfLives();
        }

        private int Lives { get; set; }
        private int CardsLeft { get; set; }
        private int Points { get; set; }
        private Flashcard CurrentFlashcard { get; set; }

        private static int GetStartingNumberOfCards()
        {
            return 20;
        }

        private static int GetStartingNumberOfLives()
        {
            return 3;
        }

        public override Flashcard GetCurrentFlashcard()
        {
            return CurrentFlashcard;
        }

        protected override string GetGameInfo()
        {
            return "Test is a change to challange your knowlege.\n" +
                   "20 flashcards will be randomly chosen and you will have 3 lives.\n" +
                   "At the end, your score will bo shown.";
        }

        public override string GetCardsLeftLabelContent()
        {
            return "Left: " + CardsLeft;
        }

        public override string GetLivesLeftLabelContent()
        {
            return "Left: " + Lives;
        }

        public override void NextFlashcard()
        {
            if (CardsLeft == 0)
                IsOver = true;

            var rand = new Random();
            int index = rand.Next(Flashcards.Count);
            CurrentFlashcard = Flashcards[index];
        }

        public override string GetOverMessage()
        {
            if (Lives != -1)
                return "Congratulations!\n" +
                       "You managed to complete test with " +
                       Points + " points and " + Lives +
                       " lives left!";

            return "Game Over!\n" +
                   "You are out of lives. Points earned: " +
                   Points;
        }

        public override bool CheckAnswer(string answer)
        {
            bool result = GetCurrentFlashcard().IsCorrectAnswer(answer);
            if (result)
            {
                Points++;
                Flashcards.Remove(CurrentFlashcard);
                if (--CardsLeft == 0)
                {
                    IsOver = true;
                    return true;
                }
            }
            else
            {
                if (--Lives < 0)
                    IsOver = true;
            }
            NextFlashcard();
            return result;
        }

        public override void LoadFlashcards(GameWindow window)
        {
            base.LoadFlashcards(window);

            if (Flashcards.Count < 20)
                CardsLeft = Flashcards.Count;

            NextFlashcard();
        }
    }
}