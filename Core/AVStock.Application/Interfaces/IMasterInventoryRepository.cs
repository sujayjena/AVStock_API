using AVStock.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVStock.Application.Interfaces
{
    public interface IMasterInventoryRepository
    {
        #region Inwarding

        Task<int> SaveInwarding(Inwarding_Request parameters);
        Task<IEnumerable<Inwarding_Response>> GetInwardingList(Inwarding_Search parameters);
        Task<Inwarding_Response?> GetInwardingById(long Id);

        #endregion

        #region Outwarding

        #endregion
    }
}
