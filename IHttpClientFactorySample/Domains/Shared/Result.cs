namespace IHttpClientFactorySample.Domains.Shared;

public class Result<T>
{
    public T? Data { get; }
    public bool IsSuccess { get; }
    public string Message { get; }

    private Result(T? data, bool isSuccess, string message)
    {
        Data = data;
        IsSuccess = isSuccess;
        Message = message;
    }

    public static Result<T> Success(T data, string message = "Success") =>
        new(data, true, message);

    public static Result<T> Failure(string message) =>
        new(default, false, message);
}
