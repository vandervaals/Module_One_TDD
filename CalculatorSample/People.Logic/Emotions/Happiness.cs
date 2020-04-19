using Loggers;
using PeopleEmotions.Logic.Interfaces;

namespace PeopleEmotions.Logic.Emotions
{
    public class Happiness : IEmotion
    {
        private ILogger _logger;

        public Happiness(ILogger logger)
        {
            _logger = logger;
        }

        public virtual Mood HideEmotion()
        {
            _logger.Log("Yes, I`m happy.");
            return Mood.Good;
        }

        public virtual Mood ShowEmotion()
        {
            _logger.Log("All Right!!!");
            return Mood.Ok;
        }
    }
}
