using AVStock.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVStock.Application.Interfaces
{
    public interface ILabSampleRepository
    {
        #region Lab Sample
        Task<int> SaveLabSample(LabSample_Request parameters);
        Task<IEnumerable<LabSample_Response>> GetLabSampleList(LabSample_Search parameters);
        Task<LabSample_Response?> GetLabSampleById(long Id);
        #endregion

        #region Lab Sample Details
        Task<int> SaveLabSampleDetails(LabSampleDetails_Request parameters);
        Task<IEnumerable<LabSampleDetails_Response>> GetLabSampleDetailsList(LabSampleDetails_Search parameters);
        #endregion
    }
}
