
namespace CManager.Domain.Models;

public class ResponseResultObject<T> : ResponseResult
{
    public T? Data { get; set; }
}
