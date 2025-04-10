using System.Globalization;
using App.Shared.Other.Constants;
using App.Shared.Other.Helpers.LocalizationContinare;
using Microsoft.AspNetCore.Http;

namespace App.Shared.ResponseData
{

    public class Result<T>
    {
        public bool IsSuccess { get; private set; }
        public int StatusCode { get; private set; }
        public string Key { get; private set; }
        public string? Message { get; private set; }
        public T? Data { get; private set; }
        public Pagination? Pagination { get; private set; }

        private Result(bool isSuccess, int statusCode, string key, string? message, T? data, Pagination? pagination)
        {
            IsSuccess = isSuccess;
            StatusCode = statusCode;
            Key = key;
            Message = message;
            Data = data;
            Pagination = pagination;
        }

        public static Result<T> Success(T data, string? successMessageKey = null, Pagination? pagination = null)
            => CreateResult(true, StatusCodes.Status200OK, ResponseKey.Success, data, successMessageKey, pagination);

        public static Result<T> Fail(string errorMessageKey, int statusCode = StatusCodes.Status400BadRequest, string key = ResponseKey.Failure)
            => CreateResult(false, statusCode, key, default, errorMessageKey, null);

        public static Result<T> ValidationErrors(string errorMessage, int statusCode = StatusCodes.Status400BadRequest, string key = ResponseKey.InvalidParameters)
            => new Result<T>(false, statusCode, key, errorMessage, default, null);

        private static Result<T> CreateResult(bool isSuccess, int statusCode, string key, T? data, string? messageKey, Pagination? pagination)
        {
            string? localizedMessage = string.IsNullOrEmpty(messageKey)
                ? null
                : LocalizerHelper.LocalizeMessage(messageKey, CultureInfo.CurrentCulture.TwoLetterISOLanguageName, DefaultPaths.GeneralLocalizationPath);

            return new Result<T>(isSuccess, statusCode, key, localizedMessage, data, pagination);
        }
    }



}
