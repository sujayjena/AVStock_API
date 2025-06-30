using AVStock.Domain.Entities;
using AVStock.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AVStock.Application.Models
{
    #region Lab Sample
    public class LabSample_Search : BaseSearchEntity
    {
    }

    public class LabSample_Request : BaseEntity
    {
        public LabSample_Request()
        {
            sampleDetailsList = new List<LabSampleDetails_Request>();
        }
        public string? SampleNo { get; set; }
        public int? PatientId { get; set; }
        public int? OrderId { get; set; }
        public int? SampleTypeId { get; set; }
        public bool? IsActive { get; set; }
        public List<LabSampleDetails_Request> sampleDetailsList { get; set; }
    }

    public class LabSample_Response : BaseResponseEntity
    {
        public string? SampleNo { get; set; }
        public int? PatientId { get; set; }
        public int? OrderId { get; set; }
        public string? OrderNo { get; set; }
        public int? SampleTypeId { get; set; }
        public string? SampleType { get; set; }
        public bool? IsActive { get; set; }
        public List<LabSampleDetails_Response> sampleDetailsList { get; set; }
    }
    #endregion

    #region LabSample Details
    public class LabSampleDetails_Search : BaseSearchEntity
    {
        public int? LabSampleId { get; set; }
    }

    public class LabSampleDetails_Request : BaseEntity
    {
        [JsonIgnore]
        public int? LabSampleId { get; set; }
        public int? TestId { get; set; }
        public bool? IsActive { get; set; }
    }

    public class LabSampleDetails_Response : BaseResponseEntity
    {
        public int? LabSampleId { get; set; }
        public string? SampleNo { get; set; }
        public int? TestId { get; set; }
        public string? TestName { get; set; }
        public bool? IsActive { get; set; }
    }
    #endregion
}
