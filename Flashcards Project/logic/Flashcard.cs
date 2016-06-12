namespace Flashcards_Project.logic
{
    public class Flashcard
    {
        public Flashcard(string front, string back)
        {
            Front = front;
            Back = back;
        }

        public string Front { get; private set; }
        public string Back { get; }

        public bool IsCorrectAnswer(string answer)
        {
            return answer != null && string.Equals(answer.ToLower(), Back.ToLower());
        }
    }
}