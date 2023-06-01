using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Evernote.Abstractions.Staff
{
    public class SimpleTools
    {
        static readonly Lazy<SimpleTools> LazyInstance = new Lazy<SimpleTools>(() => new SimpleTools(), true);
        public new static SimpleTools Instance => LazyInstance.Value;

        

        //RequestResult<string> GetStringContentFromResource(Assembly assembly, string str_resource_name)
        //{
        //    try
        //    {
        //        using (Stream stream = assembly.GetManifestResourceStream(str_resource_name))
        //        {
        //            using (StreamReader streamReader = new StreamReader(stream))
        //            {
        //                string content = streamReader.ReadToEnd();
        //                return new RequestResult<string>(content, statusOk);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return new RequestResult<string>(string.Empty, statusSomethingWrong, message: ex.Message);
        //    }
        //}

        public Task<RequestResult> mgcJsnSerialize2FileAsnc(
            object item,
            string str_path,
            NullValueHandling nullValueHandling = NullValueHandling.Ignore)
            => Task.Run(() => { return mgcJsnSerialize2File(item, str_path, nullValueHandling); });
        public RequestResult mgcJsnSerialize2File(
            object item,
            string str_path,
            NullValueHandling nullValueHandling = NullValueHandling.Ignore)
        {
            try
            {
                JsonSerializer jsonSerializer = new JsonSerializer();
                jsonSerializer.NullValueHandling = nullValueHandling;

                using (StreamWriter streamWriter = new StreamWriter(str_path))
                {
                    using (JsonWriter jsonWriter = new JsonTextWriter(streamWriter))
                    {
                        jsonSerializer.Serialize(jsonWriter, item);
                    }
                }
                return new RequestResult(RequestStatus.Ok);
            }
            catch (Exception ex)
            {
                return new RequestResult(RequestStatus.SerializationError, message: $"can not serialize json to file: {str_path} with error: {ex.Message}", ex);
            }
        }

        public Task<RequestResult<string>> mgcJsnGetStringByDataAsnc(object item)
            => Task.Run(() => { return mgcJsnGetStringByData(item); });
        public RequestResult<string> mgcJsnGetStringByData(object item)
        {
            try
            {
                string result = JsonConvert.SerializeObject(item);
                return new RequestResult<string>(result, RequestStatus.Ok);
            }
            catch (Exception ex)
            {
                return new RequestResult<string>(string.Empty, RequestStatus.SerializationError, message: $"can not serialize object to json with error: {ex.Message}", ex);
            }
        }

        public Task<RequestResult<T>> mgcJsnGetDataByStringAsnc<T>(string jsonString) where T : class
            => Task.Run(() => { return mgcJsnGetDataByString<T>(jsonString); });
        public RequestResult<T> mgcJsnGetDataByString<T>(string jsonString) where T : class
        {
            try
            {
                var data = JsonConvert.DeserializeObject<T>(jsonString);
                return new RequestResult<T>(data, RequestStatus.Ok);
            }
            catch (Exception ex)
            {
                return new RequestResult<T>(default(T), RequestStatus.SerializationError, message: $"can not deserialize string to object with error: {ex.Message}", ex);
            }
        }
    }
}
