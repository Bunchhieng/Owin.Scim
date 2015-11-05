﻿namespace Owin.Scim.Extensions
{
    using System;
    using System.Net;
    
    using Model;

    using Patching.Exceptions;
    using Patching.Operations;

    public static class JsonPatchExceptionExtensions
    {
        public static ScimError ToScimError(this ScimPatchException exception)
        {
            return new ScimError(
                GetStatusCode(exception),
                GetScimType(exception),
                GetDetail(exception));
        }

        private static HttpStatusCode GetStatusCode(ScimPatchException exception)
        {
            return HttpStatusCode.BadRequest;
        }

        private static ScimErrorType GetScimType(ScimPatchException exception)
        {
            return ScimErrorType.InvalidPath;

            switch (exception.FailedOperation.OperationType)
            {
                case OperationType.Add:
                    break;
                case OperationType.Remove:
                    break;
                case OperationType.Replace:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private static string GetDetail(ScimPatchException exception)
        {
            return null;
        }
    }
}