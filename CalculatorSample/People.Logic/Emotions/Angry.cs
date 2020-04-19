using Loggers;
using PeopleEmotions.Logic.Interfaces;

namespace PeopleEmotions.Logic.Emotions
{
    public class Angry : IEmotion
    {
        private ILogger _logger;

        public Angry(ILogger logger)
        {
            _logger = logger;
        }

        public virtual Mood HideEmotion()
        {
            _logger.Log("I want to die.");
            return Mood.Depression;
        }

        public virtual Mood ShowEmotion()
        {
            _logger.Log("You wanna play? Lets play!");
            return Mood.Bad;
        }
    }
}
