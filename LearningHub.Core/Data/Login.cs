using System;
using System.Collections.Generic;

namespace LearningHub.Core.Data
{
    public partial class Login
    {
        public decimal Loginid { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public decimal? Roledid { get; set; }
        public decimal? Studentid { get; set; }

        public virtual Role? Roled { get; set; }
        public virtual Student? Student { get; set; }
    }
}
