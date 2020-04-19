namespace PeopleEmotions.Logic.Interfaces
{
    public interface IEmotion
    {
        Mood ShowEmotion();
        Mood HideEmotion();
    }

    public enum Mood
    {
        Ok,
        Good,
        Normal,
        Bad,
        Depression
    }
}
