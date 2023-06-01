using Evernote.Abstractions;
using Evernote.Abstractions.Constants;
using Evernote.Abstractions.DataObjects;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using smpTools = Evernote.DAL.Staff.SimpleTools;

namespace Evernote.DAL.WebApi.Action
{
    public class ActionNotes : BaseAction, IActionNotes
    {
        public Task<RequestResult> CreateOne(ObjNoteCreateIn data)
        {
            throw new NotImplementedException();
        }

        public async Task<RequestResult<ObjNoteOut>> GetAll(ObjNoteIn data)
        {
            HttpClient httpClient = ActionStaff.Instance.GetHttpClient(useRootSertificate: true);
            string strUrl = ActionStaff.Instance.BuildUri("/Notes/GetAll");

            //strUrl = @$"{strUrl}/";// srvWebapi.Staff.BuildUri(strApi, strId);

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(strUrl);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    HttpContent httpContentResponse = response.Content;
                    string str_response = await httpContentResponse.ReadAsStringAsync();

                    var var_response = smpTools.Instance.mgcJsnGetDataByString<ObjNoteOut>(str_response);
                    return var_response;
                }
                else
                {
                    return new RequestResult<ObjNoteOut>(null,
                        RequestStatus.ServiceUnavailable);
                }
            }
            catch (Exception ex)
            {
                return new RequestResult<ObjNoteOut>(null, RequestStatus.SomethingWrong);
            }
        }

        public Task<RequestResult<ObjNoteOut>> GetOne(ObjNoteIn data)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResult> UpdateOne(ObjNoteUpdateIn data)
        {
            throw new NotImplementedException();
        }
    }
}
