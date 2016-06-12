using System.Linq;

namespace Flashcards_Project.logic
{
    public class TrainingGame : GameType
    {
        private int Attempts { get; set; }

        public override Flashcard GetCurrentFlashcard()
        {
            return Flashcards.First();
        }

        public override void NextFlashcard()
        {
            Flashcards.RemoveAt(0);

            if (Flashcards.Count == 0)
                IsOver = true;
        }

        public override string GetOverMessage()
        {
            return "Congratulations!\n" +
                   "You managed to complete training with " +
                   "only " + Attempts + " attempts!";
        }

        public override bool CheckAnswer(string answer)
        {
            Attempts++;
            bool result = GetCurrentFlashcard().IsCorrectAnswer(answer);
            if (result)
                NextFlashcard();
            return result;
        }

        protected override string GetGameInfo()
        {
            return "In training you have a chance to practice.\n" +
                   "Flashcards will be given in order and you will have unlimited lives.\n" +
                   "When you are ready, go test yourself!";
        }

        public override string GetCardsLeftLabelContent()
        {
            return "Left: " + Flashcards.Count;
        }

        public override string GetLivesLeftLabelContent()
        {
            return "Attempt: " + Attempts;
        }
    }
}