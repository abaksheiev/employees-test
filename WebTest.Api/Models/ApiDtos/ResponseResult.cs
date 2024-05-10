using static WebTest.Contracts.Constants;

namespace WebTest.Models.ApiDtos
{
    public class ResponseResult<TEntity>
    {
        public  string Status { get; private set; }

        public TEntity Data { get; private set; }

        public string Message { get; private set; }

        public ResponseResult(TEntity data, string status, string msg)
        {
            Status = status;
            Message = msg;
            Data = data;
        }
        public static ResponseResult<TEntity> BuildSuccess(TEntity data,  string msg = null)
        {
            string successMsg = string.IsNullOrWhiteSpace(msg) ? ResponseMessages.Success : msg;
            return new ResponseResult<TEntity>(data, ResponseStatus.Success, successMsg);
        }

        public static ResponseResult<TEntity> BuildError(TEntity data, string msg = null)
        {
            string errorMsg = string.IsNullOrWhiteSpace(msg) ? ResponseMessages.Error : msg;
            return new ResponseResult<TEntity>(data, ResponseStatus.Error, errorMsg);
        }

        public static ResponseResult<TEntity> BuildBadRequest(TEntity data, string msg=null)
        {
            string badRequestMsg = string.IsNullOrWhiteSpace(msg) ? ResponseMessages.BadRequest : msg;
            return new ResponseResult<TEntity>(data, ResponseStatus.BadRequest, badRequestMsg);
        }
    }
}
