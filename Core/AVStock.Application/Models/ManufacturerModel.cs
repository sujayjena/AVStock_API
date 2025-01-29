using AVStock.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVStock.Application.Models
{
    public class ManufacturerModel
    {
    }
    public class Manufacturer_Request : BaseEntity
    {
        public string? Manufacturer { get; set; }
        public bool? IsActive { get; set; }
    }

    public class Manufacturer_Response : BaseResponseEntity
    {
        public string? Manufacturer { get; set; }
        public bool? IsActive { get; set; }
    }
}
