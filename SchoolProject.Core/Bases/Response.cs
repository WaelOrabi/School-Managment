using System.Net;

public class Response<T>
{
    public HttpStatusCode StatusCode { get; set; }
    public object Meta { get; set; }
    public bool Succeeded { get; set; }
    public string Message { get; set; }
    public T Data { get; set; }

    public Response(T data = default, string message = null, bool succeeded = true, HttpStatusCode statusCode = HttpStatusCode.OK)
    {
        Data = data;
        Message = message;
        Succeeded = succeeded;
        StatusCode = statusCode;
    }

}