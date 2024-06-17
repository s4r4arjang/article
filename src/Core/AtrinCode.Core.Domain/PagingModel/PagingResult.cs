namespace AtrinCode.Core.Domain.PagingModel
{
    public class PagingResult<TModel> where TModel : class
    {
        //public TFilter Filter { get; set; }
        public IEnumerable<TModel> Result { get; set; }
        public PagingData Paging { get; set; } = new PagingData();

    }
}
