using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using smpTools = Evernote.DAL.Staff.SimpleTools;
using Evernote.Abstractions;

namespace Evernote.DAL.WebApi.Action
{
    public class BaseAction
    {
        protected string prtGetErrorMesage(string strUrl, HttpResponseMessage response)
        {
            string output = string.Empty;

            output += $"URL: {strUrl}\n";
            output += "\n";
            output += response.ToString();

            return output;
        }

        protected async Task<RequestResult<T>> prtGetWithId<T>(
            string strToken,
            string strApi,
            string strId,
            CancellationToken cts,
            bool useRootCertificate = false,
            bool addSlashAtEnd = false) where T : class
        {
            HttpClient httpClient = ActionStaff.Instance.GetHttpClient(strToken, useRootCertificate);
            string strUrl = ActionStaff.Instance.BuildUri(strApi, strId, addSlashAtEnd);

            //strUrl = @$"{strUrl}/";// srvWebapi.Staff.BuildUri(strApi, strId);

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(strUrl);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    HttpContent httpContentResponse = response.Content;
                    string str_response = await httpContentResponse.ReadAsStringAsync();

                    var var_response = smpTools.Instance.mgcJsnGetDataByString<T>(str_response);
                    return var_response;
                }
                else
                {
                    return new RequestResult<T>(null,
                        RequestStatus.ServiceUnavailable,
                        $"{nameof(response.StatusCode)}: {response.StatusCode.ToString()}, {nameof(response.ReasonPhrase)}:{response.ReasonPhrase.ToString()}");
                }
            }
            catch (Exception ex)
            {
                return new RequestResult<T>(null, RequestStatus.SomethingWrong, $"{ex.Message}");
            }
        }

        protected async Task<RequestResult<T>> prtPost<T>(
            string strToken,
            string strApi,
            object data,
            CancellationToken cts,
            bool useRootCertificate = false,
            bool addSlashAtEnd = false) where T : class
        {
            HttpClient httpClient = ActionStaff.Instance.GetHttpClient(strToken, useRootCertificate);
            string strUrl = ActionStaff.Instance.BuildUri(strApi, addSlashAtEnd: addSlashAtEnd);

            var vHttpContent = ActionStaff.Instance.GetHttpContent(data);
            if (!vHttpContent.IsValid)
            {
                return new RequestResult<T>(null, vHttpContent.Status, vHttpContent.Message);
            }


            try
            {
                HttpResponseMessage response = await httpClient.PostAsync(strUrl, vHttpContent.Data);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    HttpContent httpContentResponse = response.Content;
                    string str_response = await httpContentResponse.ReadAsStringAsync();

                    var var_response = smpTools.Instance.mgcJsnGetDataByString<T>(str_response);
                    return var_response;
                }
                else
                {
                    return new RequestResult<T>(null,
                        RequestStatus.ServiceUnavailable,
                        $"{nameof(response.StatusCode)}: {response.StatusCode.ToString()}, {nameof(response.ReasonPhrase)}:{response.ReasonPhrase.ToString()}");
                }
            }
            catch (Exception ex)
            {
                return new RequestResult<T>(null, RequestStatus.SomethingWrong, $"{ex.Message}");
            }
        }
    }
}
