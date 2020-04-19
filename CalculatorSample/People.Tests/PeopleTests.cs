using Loggers;
using Ninject;
using NUnit.Framework;
using PeopleEmotions.Logic;
using PeopleEmotions.Logic.Emotions;
using PeopleEmotions.Logic.Interfaces;

namespace CalculatorSample.Tests
{
    [TestFixture]
    public class PersonTests
    {
        private StandardKernel GetKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<People>().ToSelf();
            kernel.Bind<ILogger>().To<DebugLogger>();
            return kernel;
        }

        private People GetHappyPeople()
        {
            var kernel = GetKernel();
            kernel.Bind<IEmotion>().To<Happiness>();
            return kernel.Get<People>();
        }

        private People GetAngryPeople()
        {
            var kernel = GetKernel();
            kernel.Bind<IEmotion>().To<Angry>();
            return kernel.Get<People>();
        }

        [Test]
        public void PeopleFeelHappiness()
        {
            var people = GetHappyPeople();
            people.FeelEmotion();
            Assert.AreEqual(Mood.Ok, people.CurrentMood);
        }

        [Test]
        public void PeopleIgnoreHappiness()
        {
            var people = GetHappyPeople();
            people.IgnoreEmotion();
            Assert.AreEqual(Mood.Good, people.CurrentMood);
        }

        [Test]
        public void PeopleFeelAngry()
        {
            var people = GetAngryPeople();
            people.FeelEmotion();
            Assert.AreEqual(Mood.Bad, people.CurrentMood);
        }

        [Test]
        public void PeopleIgnoreAngry()
        {
            var people = GetAngryPeople();
            people.IgnoreEmotion();
            Assert.AreEqual(Mood.Depression, people.CurrentMood);
        }
    }
}
