using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pexip.Lib
{
    /// <summary>
    /// Provides the API for interacting with the Pexip Conference History API - /api/admin/history/v1/conference/
    /// </summary>
    public interface IConferenceHistory
    {
        Task<List<ConferenceHistoryObject>> Get();
        Task<List<ConferenceHistoryObject>> Get(DateTimeOffset timeFilterStart, DateTimeOffset timeFilterEnd);
        Task<int> GetTotal();
        Task<int> GetTotal(DateTime timeFilterStart, DateTime timeFilterEnd);
    }
}
