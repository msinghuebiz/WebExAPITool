using RestSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebExAPITool.Intersight.Client;

namespace WebExAPITool.Intersight
{
    public class GetIntersightData
    {
        private WebExAPITool.Intersight.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        public WebExAPITool.Intersight.Client.ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                }
                return _exceptionFactory;
            }
            set { _exceptionFactory = value; }
        }

        public GetIntersightData()
        {

        }
        private const string ISO8601_DATETIME_FORMAT = "o";

        private string _dateTimeFormat = ISO8601_DATETIME_FORMAT;

        /// <summary>
        /// Gets or sets the the date time format used when serializing in the ApiClient
        /// By default, it's set to ISO 8601 - "o", for others see:
        /// https://msdn.microsoft.com/en-us/library/az4se3k1(v=vs.110).aspx
        /// and https://msdn.microsoft.com/en-us/library/8kb3ddd4(v=vs.110).aspx
        /// No validation is done to ensure that the string you're providing is valid
        /// </summary>
        /// <value>The DateTimeFormat string</value>
        public String DateTimeFormat
        {
            get
            {
                return _dateTimeFormat;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    // Never allow a blank or null string, go back to the default
                    _dateTimeFormat = ISO8601_DATETIME_FORMAT;
                    return;
                }

                // Caution, no validation when you choose date time format other than ISO 8601
                // Take a look at the above links
                _dateTimeFormat = value;
            }
        }
        private string ParameterToString(object obj)
        {
            if (obj is DateTime)
                // Return a formatted date string - Can be customized with Configuration.DateTimeFormat
                // Defaults to an ISO 8601, using the known as a Round-trip date/time pattern ("o")
                // https://msdn.microsoft.com/en-us/library/az4se3k1(v=vs.110).aspx#Anchor_8
                // For example: 2009-06-15T13:45:30.0000000
                return ((DateTime)obj).ToString(DateTimeFormat);
            else if (obj is DateTimeOffset)
                // Return a formatted date string - Can be customized with Configuration.DateTimeFormat
                // Defaults to an ISO 8601, using the known as a Round-trip date/time pattern ("o")
                // https://msdn.microsoft.com/en-us/library/az4se3k1(v=vs.110).aspx#Anchor_8
                // For example: 2009-06-15T13:45:30.0000000
                return ((DateTimeOffset)obj).ToString(DateTimeFormat);
            else if (obj is IList)
            {
                var flattenedString = new StringBuilder();
                foreach (var param in (IList)obj)
                {
                    if (flattenedString.Length > 0)
                        flattenedString.Append(",");
                    flattenedString.Append(param);
                }
                return flattenedString.ToString();
            }
            else
                return Convert.ToString(obj);
        }

        public async Task<ApiResponse<T>> ExecuteAPI<T>(String functionName , string path , string api_key ,Dictionary<String, object>  param = null, Dictionary<String, object> qparam = null)
        {

            ////https://5d079d727564612d305b9414.intersight.com/api/v1
        //    var path = "C:\\Uebiz\\WebExAPITool_V2\\WebExAPITool\\WebExAPITool.Intersight\\SecretKey.pem";
            var intersightIntialConfig = new Intersight.Client.IntersightApiClient("https://www.intersight.com/api/v1",
            path, api_key);



            //intersightIntialConfig.prepare_auth_header("/cond/Alarms", RestSharp.Method.GET, null, new Dictionary<string, string>());

            var localVarPath = functionName;
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new Dictionary<String, String>();
            var localVarHeaderParams = new Dictionary<String, String>(intersightIntialConfig.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = intersightIntialConfig.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = intersightIntialConfig.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            // check when param is not null 
            if (param != null)
            {
                foreach (var item in param)
                {
                    localVarPathParams.Add(item.Key, ParameterToString(item.Value));
                }
            }

            // check when param is not null 
            if (qparam != null)
            {
                foreach (var item in qparam)
                {
                    localVarQueryParams.Add(item.Key, ParameterToString(item.Value));
                }
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)intersightIntialConfig.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("CondAlarmsGet", localVarResponse);
                if (exception != null) throw exception;
            }

            var response = new ApiResponse<T>(localVarStatusCode,
                 localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                 (T)intersightIntialConfig.Configuration.ApiClient.Deserialize(localVarResponse, typeof(T)));


          return response;
        }

    }
}
