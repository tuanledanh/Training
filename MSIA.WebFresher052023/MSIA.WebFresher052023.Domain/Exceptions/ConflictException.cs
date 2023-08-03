using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class ConflictException : Exception
    {
        #region Fields
        public int ErrorCode { get; set; }
        #endregion
        #region Constructor
        public ConflictException() { }
        public ConflictException(int errorCode)
        {
            ErrorCode = errorCode;
        }
        #endregion

        #region Methods
        public ConflictException(string message) : base(message)
        {

        }
        public ConflictException(string message, int errorCode) : base(message)
        {
            ErrorCode = errorCode;
        }
        #endregion
    }
}
