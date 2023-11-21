using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Core.DTO
{
    public class Search
    {
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Coursename { get; set; } = null!;
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }

        public decimal? Markofstd { get; set; }

    }
}
