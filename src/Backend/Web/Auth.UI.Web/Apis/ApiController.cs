using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Auth.UI.Web.Apis
{
    /// <summary>
    /// ApiController基类
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ApiController : Controller
    {
        /// <summary>
        /// 获取时间戳
        /// </summary>
        /// <returns></returns>
        protected static long UnixTimestampFromTime(DateTime? dateTime = null)
        {
            if (!dateTime.HasValue)
            {
                dateTime = DateTime.Now;
            }
            long unixTimestamp= dateTime.Value.Ticks - new DateTime(1970, 1, 1).Ticks;
            unixTimestamp/= TimeSpan.TicksPerSecond;

            return unixTimestamp;
        }

        /// <summary>
        /// 时间戳转时间
        /// </summary>
        /// <param name="unixTimestamp"></param>
        /// <returns></returns>
        protected static DateTime TimeFromUnixTimestamp(int unixTimestamp)
        {
            DateTime unixYear0 = new DateTime(1970, 1, 1);
            long unixTimeStampInTicks = unixTimestamp* TimeSpan.TicksPerSecond;
            DateTime dateTime = new DateTime(unixYear0.Ticks + unixTimeStampInTicks);
            return dateTime;
        }
    }
}
