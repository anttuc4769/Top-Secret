namespace Hydra.Models
{
    public class PaginationModel
    {
        public int Page { get; set; }
        public int Total { get; set; }
        public int ItemsPerPage { get; set; }
        public int Skip => Page * ItemsPerPage;
    }
}
