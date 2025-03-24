using System.Collections.Generic;

namespace MyCqrsApi
{
    public class Result<T>
    {
        public bool Success { get; set; }
        public T? Data { get; set; }
        public List<string> Errors { get; set; } = new();

        public static Result<T> Ok(T data) => new() { Success = true, Data = data };
        public static Result<T> Fail(List<string> errors) => new() { Success = false, Errors = errors };
    }
}
