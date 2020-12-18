namespace Project.Common.Filtering
{
    public interface IFiltering<TFilter>
    {
        TFilter Filter { get; set; }
    }
}
