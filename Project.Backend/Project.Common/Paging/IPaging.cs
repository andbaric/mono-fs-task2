namespace Project.Common.Paging
{
    public interface IPaging
    {
        int PageSize {get; set;}
        int PageNumber { get; set; }
    }
}
