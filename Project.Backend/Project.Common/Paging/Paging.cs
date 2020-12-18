namespace Project.Common.Paging
{
    public class Paging : IPaging
    {
        const int maxPageSize = 20;
        private int pageSize = 10;

        public int PageSize 
        {
            get => pageSize;
            set => pageSize = (value > maxPageSize) ? maxPageSize : value;
        }

        public int PageNumber { get; set; } = 1;
    }
}
