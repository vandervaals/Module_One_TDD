using PeopleEmotions.Logic.Interfaces;
using System;

namespace PeopleEmotions.Logic.NotSOLID
{
    public class Sadness
    {
        public Mood HideEmotion()
        {
            Console.WriteLine("Depression");
            return Mood.Depression;
        }

        public Mood ShowEmotion()
        {
            Console.WriteLine("Bad");
            return Mood.Bad;
        }
    }
}
