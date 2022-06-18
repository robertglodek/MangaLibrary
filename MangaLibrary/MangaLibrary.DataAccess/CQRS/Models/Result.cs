using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.DataAccess.CQRS.Models
{
    public class Result<T> 
    {
        private Result()
        {
        }
        public bool IsSuccess { get; init; }

        public string ErrorMessage { get; init; }

        public T Value { get; init; }

        public static Result<T> Success(T response) => new Result<T>() { IsSuccess = true, Value = response };

        public static Result<T> Fail(string errorMessage) => new Result<T>() { IsSuccess = false, ErrorMessage = errorMessage };
    }
}
