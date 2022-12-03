using Domain.Common;

namespace Api.Responses
{
    public class ApiResponse<T>
    {
        public T Data { get; set; }

        public ApiResponse(T data)
        {
            Data = data; 
        }

        public Metadata Meta { get; set; }
    }
}
