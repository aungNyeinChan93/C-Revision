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
    }

    public enum EnumResponseType { None ,Success ,Error,ValidationError ,SysTemError}

}
