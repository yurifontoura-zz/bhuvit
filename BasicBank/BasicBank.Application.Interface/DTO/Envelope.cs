namespace BasicBank.Application.Interface.DTO
{
    public class Envelope
    {
        public Envelope() { Success = false; }
        public Envelope(bool success, string? message)
        {
            Message = message;
            Success = success;
        }

        public bool Success { get; set; }
        public string? Message { get; set; }
        public void SetSuccess()
        {
            Message = "Success!";
            Success = true;
        }
    }

    public class TypedEnvelope<T> : Envelope where T : class
    {
        public TypedEnvelope() { Success = false; }

        public TypedEnvelope(T data, bool success, string? message) : base(success, message)
        {
            Data = data;
        }

        public T? Data { get; set; }

        public void SetSuccess(T data)
        {
            Data = data;
            Message = "Success!";
            Success = true;
        }
    }
}
