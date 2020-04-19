using PeopleEmotions.Logic.Interfaces;

namespace PeopleEmotions.Logic.NotSOLID
{
    public class SadPeople
    {
        public Sadness Sadness;
        public Mood CurrentMood;

        public SadPeople()
        {
            Sadness = new Sadness();
        }

        public void FeelEmotion()
        {
            CurrentMood = Sadness.ShowEmotion();
        }

        public void IgnoreEmotion()
        {
            CurrentMood = Sadness.HideEmotion();
        }
    }
}
