namespace BaseApi.Application.Services
{
    public class ResponseService(bool success, string message)
    {
        public bool Success { get; } = success;
        public string Message { get; } = message;

        public static ResponseService SeccessResponse(string message = "Operação realizada com sucesso.")
            => new(true, message);

        public static ResponseService ErrorResponse(string message)
            => new(false, message);
    }

    public class ResponseService<T>(bool success, string message, T? data = default) : ResponseService(success, message)
    {
        public T? Data { get; set; } = data;

        public static ResponseService<T> SeccessResponse(T data, string message = "Operação realizada com sucesso.")
            => new(true, message, data);
    }
}
