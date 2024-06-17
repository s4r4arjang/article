namespace EndPoint.Web.Admin.Models.Results
{
    public enum StatusCode
    {
        Success = 200,
        Duplicate = 2
    }
    public enum ResultStatus
    {
        Success = 1,
        Error = 2
    }
    public class ResultModel
    {
        public string Message { get; set; }
        public ResultStatus resultStatus { get; set; }
        public bool Success { get; set; }
    }
}
