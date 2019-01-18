using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pexip.Lib
{
    public interface IParticipantHistory
    {
        Task<IList<ParticipantHistoryObject>> Get();
        Task<IList<ParticipantHistoryObject>> Get(DateTimeOffset timeFilterStart, DateTimeOffset timeFilterEnd);
    }
}
