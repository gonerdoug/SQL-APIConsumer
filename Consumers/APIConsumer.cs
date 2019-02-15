using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace SQLAPI_Consumer
{
    /// <summary>
    /// This class will be used for consume API using the URL provided.
    /// Actually only GET & POST Method are supported.
    /// </summary>
    public static class APIConsumer
    {
        /// <summary>
        /// Fixed Context type supported.
        /// </summary>
        private const string CONTENTTYPE = "application/json; charset=utf-8";

        /// <summary>
        /// Fixed string for POST method
        /// </summary>
        private const string POST_WebMethod = "POST";

        /// <summary>
        /// Fixed string for GET method
        /// </summary>
        private const string GET_WebMethod = "GET";

        /// <summary>
        /// POST to Resful API sending Json body.
        /// </summary>
        /// <param name="url">API URL</param>
        /// <param name="JsonBody">Content Application By Default Json</param>
        /// <param name="Token">Header Authorization token</param>
        /// <returns>String Api result</returns>
        public static string POSTMethod(string url, string JsonBody, string Token = "")
        {
            string ContentResult = string.Empty ;
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.ContentType = CONTENTTYPE;
                request.Method = POST_WebMethod; 

                if (!String.IsNullOrEmpty(Token))
                    request.Headers.Add(HttpRequestHeader.Authorization, Token);

                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(JsonBody);
                    streamWriter.Flush();
                }

                var httpResponse = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    ContentResult = result;
                }
            }
            catch (Exception ex)
            {
                ContentResult = ex.Message.ToString();
                throw ex;
            }

            return ContentResult;
        }

        /// <summary>
        /// Request GET Method to the URL API provided.
        /// </summary>
        /// <param name="url">API URL</param>
        /// <param name="Token">Header Authorization Token</param>
        /// <returns>String Api result</returns>
        public static string GETMethod(string url, string Token = "")
        {
            string ContentResult = string.Empty;
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.ContentType = CONTENTTYPE;
                request.Method = GET_WebMethod;

                if (!String.IsNullOrEmpty(Token))
                    request.Headers.Add(HttpRequestHeader.Authorization, Token);

                var httpResponse = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    ContentResult = result;
                }
            }
            catch (Exception ex)
            {
                ContentResult = ex.Message.ToString();
                throw ex;
            }

            return ContentResult;
        }

        /// <summary>
        /// Request GET Method to the URL API provided.
        /// </summary>
        /// <param name="url">API URL</param>
        /// <param name="Id">Id</param>
        /// <param name="Token">Authorization Token</param>
        /// <returns>String Api result</returns>
        public static string GETMethod(string url, string Id, string Token = "")
        {
            string ContentResult = string.Empty;
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(string.Concat(url,"/",Id));
                request.ContentType = CONTENTTYPE;
                request.Method = GET_WebMethod;

                if (!string.IsNullOrEmpty(Token))
                    request.Headers.Add(HttpRequestHeader.Authorization, Token);

                var httpResponse = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    ContentResult = result;
                }
            }
            catch (Exception ex)
            {
                ContentResult = ex.Message.ToString();
                throw ex;
            }

            return ContentResult;
        }

        /// <summary>
        /// Request GET Method to the URL API provided.
        /// </summary>
        /// <typeparam name="T">Object used to deserialize the result</typeparam>
        /// <param name="url">API URL</param>
        /// <param name="Token">Authorization token</param>
        /// <returns>String Api result</returns>
        public static string GETMethod<T>(string url, ref T ObjectResult, string Token = "")
        {
            string ContentResult = string.Empty;
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.ContentType = CONTENTTYPE;
                request.Method = GET_WebMethod;

                if (!string.IsNullOrEmpty(Token))
                    request.Headers.Add(HttpRequestHeader.Authorization, Token);

                var httpResponse = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    ObjectResult = JsonConvert.DeserializeObject<T>(result);
                    ContentResult = result;
                }
            }
            catch (Exception ex)
            {
                ContentResult = ex.Message.ToString();
                throw ex;
            }

            return ContentResult;
        }

        /// <summary>
        /// Request GET Method to the URL API provided.
        /// </summary>
        /// <typeparam name="T">Object used to deserialize the result</typeparam>
        /// <param name="url">API URL</param>
        /// <param name="Token">Authorization token</param>
        /// <returns>String Api result</returns>
        public static string GETMethod<T>(string url, string Id, ref T ObjectResult, string Token = "")
        {
            string ContentResult = string.Empty;
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(string.Concat(url,"/",Id));
                request.ContentType = CONTENTTYPE;
                request.Method = GET_WebMethod;

                if (!string.IsNullOrEmpty(Token))
                    request.Headers.Add(HttpRequestHeader.Authorization, Token);

                var httpResponse = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    ObjectResult = JsonConvert.DeserializeObject<T>(result);
                    ContentResult = result;
                }
            }
            catch (Exception ex)
            {
                ContentResult = ex.Message.ToString();
                throw ex;
            }

            return ContentResult;
        }
    }
}
