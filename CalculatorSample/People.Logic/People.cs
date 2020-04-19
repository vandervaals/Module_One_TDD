using PeopleEmotions.Logic.Interfaces;

namespace PeopleEmotions.Logic
{
    public class People
    {
        private Mood _currentMood;
        private IEmotion _emotion;

        public People(IEmotion emotion)
        {
            _emotion = emotion;
            _currentMood = Mood.Normal;
        }

        public Mood CurrentMood => _currentMood;

        public IEmotion Emotion
        {
            set
            {
                _emotion = value;
            }
        }

        public void FeelEmotion()
        {
            _currentMood =_emotion.ShowEmotion();
        }

        public void IgnoreEmotion()
        {
            _currentMood = _emotion.HideEmotion();
        }
    }
}
