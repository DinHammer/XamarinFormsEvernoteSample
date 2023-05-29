using System;
using System.Collections.Generic;
using System.Text;

namespace Evernote.Abstractions.Constants
{
    public class BaseConstants
    {
        protected RequestStatus statusUnknown = RequestStatus.Unknown;
        protected RequestStatus statusOk = RequestStatus.Ok;
        protected RequestStatus statusNotModified = RequestStatus.NotModified;
        protected RequestStatus statusBadRequest = RequestStatus.BadRequest;
        protected RequestStatus statusUnauthorized = RequestStatus.Unauthorized;
        protected RequestStatus statusForbidden = RequestStatus.Forbidden;
        protected RequestStatus statusNotFound = RequestStatus.NotFound;
        protected RequestStatus statusInternalServerError = RequestStatus.InternalServerError;
        protected RequestStatus statusServiceUnavailable = RequestStatus.ServiceUnavailable;
        protected RequestStatus statusCanceled = RequestStatus.Canceled;
        protected RequestStatus statusInvalidRequest = RequestStatus.InvalidRequest;
        protected RequestStatus statusSerializationError = RequestStatus.SerializationError;
        protected RequestStatus statusDatabaseError = RequestStatus.DatabaseError;
        protected RequestStatus statusFileAccessError = RequestStatus.FileAccessError;
        protected RequestStatus statusNoContent = RequestStatus.NoContent;
        protected RequestStatus statusNotOneValue = RequestStatus.NotOneValue;
        protected RequestStatus statusNotUnique = RequestStatus.NotUnique;
        protected RequestStatus statusSomethingWrong = RequestStatus.SomethingWrong;
        protected RequestStatus statusAlreadyExist = RequestStatus.AlreadyExist;
        protected RequestStatus statusBlobErrorCreateContainer = RequestStatus.BlobErrorCreateContainer;
        protected RequestStatus statusBlobUploadError = RequestStatus.BlobUploadError;
        protected RequestStatus statusBlobGetAllItemError = RequestStatus.BlobGetAllItemError;
        protected RequestStatus statusInputParamsNotValid = RequestStatus.InputParamsNotValid;
    }
}
