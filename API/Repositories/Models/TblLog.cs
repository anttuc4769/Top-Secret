using System;
using System.Collections.Generic;

namespace API.Repositories.Models
{
    public partial class TblLog
    {
        public int Id { get; set; }
        public string Text { get; set; } = null!;
        public string? Info { get; set; }
        public DateTimeOffset Created { get; set; }
    }
}
