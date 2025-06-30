using AVStock.Application.Models;
using AVStock.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVStock.Application.Interfaces
{
    public interface ISampleTypeRepository
    {
        Task<int> SaveSampleType(SampleType_Request parameters);

        Task<IEnumerable<SampleType_Response>> GetSampleTypeList(BaseSearchEntity parameters);

        Task<SampleType_Response?> GetSampleTypeById(long Id);
    }
}
