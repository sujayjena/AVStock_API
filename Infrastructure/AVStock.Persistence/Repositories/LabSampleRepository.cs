using AVStock.Application.Helpers;
using AVStock.Application.Interfaces;
using AVStock.Application.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVStock.Persistence.Repositories
{
    internal class LabSampleRepository : GenericRepository, ILabSampleRepository
    {

        private IConfiguration _configuration;

        public LabSampleRepository(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        #region Lab Sample
        public async Task<int> SaveLabSample(LabSample_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();
            queryParameters.Add("@Id", parameters.Id);
            queryParameters.Add("@SampleNo", parameters.SampleNo);
            queryParameters.Add("@PatientId", parameters.PatientId);
            queryParameters.Add("@OrderId", parameters.OrderId);
            queryParameters.Add("@SampleTypeId", parameters.SampleTypeId);
            queryParameters.Add("@IsActive", parameters.IsActive);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            return await SaveByStoredProcedure<int>("SaveLabSample", queryParameters);
        }

        public async Task<IEnumerable<LabSample_Response>> GetLabSampleList(LabSample_Search parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();
            queryParameters.Add("@SearchText", parameters.SearchText.SanitizeValue());
            queryParameters.Add("@IsActive", parameters.IsActive);
            queryParameters.Add("@PageNo", parameters.PageNo);
            queryParameters.Add("@PageSize", parameters.PageSize);
            queryParameters.Add("@Total", parameters.Total, null, System.Data.ParameterDirection.Output);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            var result = await ListByStoredProcedure<LabSample_Response>("GetLabSampleList", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }

        public async Task<LabSample_Response?> GetLabSampleById(long Id)
        {
            DynamicParameters queryParameters = new DynamicParameters();
            queryParameters.Add("@Id", Id);
            return (await ListByStoredProcedure<LabSample_Response>("GetLabSampleById", queryParameters)).FirstOrDefault();
        }
        #endregion

        #region Lab Sample Details
        public async Task<int> SaveLabSampleDetails(LabSampleDetails_Request parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();
            queryParameters.Add("@Id", parameters.Id);
            queryParameters.Add("@LabSampleId", parameters.LabSampleId);
            queryParameters.Add("@TestId", parameters.TestId);
            queryParameters.Add("@IsActive", parameters.IsActive);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            return await SaveByStoredProcedure<int>("SaveLabSampleDetails", queryParameters);
        }

        public async Task<IEnumerable<LabSampleDetails_Response>> GetLabSampleDetailsList(LabSampleDetails_Search parameters)
        {
            DynamicParameters queryParameters = new DynamicParameters();
            queryParameters.Add("@LabSampleId", parameters.LabSampleId);
            queryParameters.Add("@SearchText", parameters.SearchText.SanitizeValue());
            queryParameters.Add("@IsActive", parameters.IsActive);
            queryParameters.Add("@PageNo", parameters.PageNo);
            queryParameters.Add("@PageSize", parameters.PageSize);
            queryParameters.Add("@Total", parameters.Total, null, System.Data.ParameterDirection.Output);
            queryParameters.Add("@UserId", SessionManager.LoggedInUserId);

            var result = await ListByStoredProcedure<LabSampleDetails_Response>("GetLabSampleDetailsList", queryParameters);
            parameters.Total = queryParameters.Get<int>("Total");

            return result;
        }

        #endregion
    }
}
