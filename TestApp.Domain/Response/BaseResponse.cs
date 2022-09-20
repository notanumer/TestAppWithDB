using TestApp.Domain.Enum;

namespace TestApp.Domain.Response
{
    public class BaseResponse<T> : IBaseResponse<T>
    {
        public string ExceptionDescription { get; set; }
        public StatusCode StatusCode { get; set; }
        public T Data { get; set; }
    }

    public interface IBaseResponse<T>
    {
        string ExceptionDescription { get; set; }
        StatusCode StatusCode { get; set; }
        T Data { get; set; }
    }
}
