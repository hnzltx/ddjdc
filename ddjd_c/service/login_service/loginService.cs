using ddjd_c.common.AllRequest;
using ddjd_c.common;
using ddjd_c.http;
using ddjd_c.vo.login;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddjd_c.service.login_service
{
    class loginService
    {
        /// <summary>
        /// 登录验证。
        /// </summary>
        /// <param name="dic"></param>
        /// <returns>返回登录信息对象</returns>
        public static loginReturnInfo loginValidate(Dictionary<string, object> dic) {
            return JsonHelper.DeserializeJsonToObject<loginReturnInfo>(baseHttp.PostStrFunction(loginRequest.Login, dic));
        }


        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="dic"></param>
        /// <returns>返回JsonObject</returns>
        public static JObject loginValidate2(Dictionary<string, object> dic) {
            return JsonHelper.getJObject(baseHttp.PostStrFunction(loginRequest.Login, dic));
        }

    }
}
