using System;
using System.Collections.Generic;
using System.Text;

namespace Domain_01.Models
{
    public class ResponseModel<T>
    {
        public int ResCode { get; set; }
        public string? ResDesc { get; set; }
        public EnumResponseType ResType { get; set; } = EnumResponseType.None;
        public bool IsSuccess { get; set; }
        public bool IsError { get { return !IsSuccess; } }
        public T? Result { get; set; }

        public static ResponseModel<T> Success(int resCode ,string  resDesc ,T result)
        {
            return new ResponseModel<T>
            {
                IsSuccess = true,
                ResDesc = resDesc,
                ResCode = resCode,
                ResType = EnumResponseType.Success,
                Result = result
            };
        }
        
        public static ResponseModel<T> Error(int resCode, string resDesc)
        {
            return new ResponseModel<T>
            {
                IsSuccess = false,
                ResDesc = resDesc,
                ResCode = resCode,
                ResType = EnumResponseType.Error,
            };
        }
    }

    public enum EnumResponseType { None ,Success ,Error,ValidationError ,SysTemError}

}
