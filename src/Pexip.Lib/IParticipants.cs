using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pexip.Lib
{
    public interface IParticipants
    {
        Task<IList<ParticipantsObject>> Get();
        Task<IList<ParticipantsObject>> Get(string callQuality);
        Task<int> GetTotal();
        Task<IList<ParticipantMediaStreamObject>> GetMediaStreams(string id);
    }
}
