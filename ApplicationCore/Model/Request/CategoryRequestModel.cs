using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Model.Request
{
    public class CategoryRequestModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; } = string.Empty;
    }
}
