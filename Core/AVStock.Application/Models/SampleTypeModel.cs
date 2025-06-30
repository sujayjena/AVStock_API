using AVStock.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVStock.Application.Models
{
    public class SampleTypeModel
    {
    }
    public class SampleType_Request : BaseEntity
    {
        public string? SampleType { get; set; }
        public bool? IsActive { get; set; }
    }

    public class SampleType_Response : BaseResponseEntity
    {
        public string? SampleType { get; set; }
        public bool? IsActive { get; set; }
    }
}
