using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TaskListMvc.Web.Infrastructure
{
    public class StandardJsonResult : JsonResult
    {
        public string ErrorMessage { get; set; }

        public override void ExecuteResult(ControllerContext context)
        {
            var response = context.HttpContext.Response;
            response.ContentType = 
                !string.IsNullOrEmpty(this.ContentType) 
                ? this.ContentType : "application/json";

            if (this.ContentEncoding != null)
            {
                response.ContentEncoding = this.ContentEncoding;
            }

            var settings = new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            if (Data == null)
            {
                response.StatusCode = 400;
                Data = new { ErrorMessage = ErrorMessage };
            }
            response.Write(JsonConvert.SerializeObject(this.Data, 
                settings));
        }
    }
}