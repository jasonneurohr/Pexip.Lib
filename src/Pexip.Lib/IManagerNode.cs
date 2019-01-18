namespace Pexip.Lib
{
    public interface IManagerNode
    {
        IParticipants Participants { get; }
        IParticipantHistory ParticipantHistory { get; }
        IConferences Conferences { get; }
        IConferenceHistory ConferenceHistory { get; }
    }
}
