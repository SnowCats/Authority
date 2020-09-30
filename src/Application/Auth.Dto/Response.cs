using System;
namespace Auth.Dto
{
    /// <summary>
    /// 响应类
    /// </summary>
    public class Response
    {
        /// <summary>
        /// 返回数据
        /// </summary>
        public dynamic Data { get; set; }

        /// <summary>
        /// 状态码
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// 返回消息
        /// </summary>
        public string Message { get; set; }
    }
}
