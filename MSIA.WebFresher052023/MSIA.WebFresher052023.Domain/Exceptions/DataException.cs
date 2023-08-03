using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class DataException : Exception
    {
        #region Fields
        public int ErrorCode { get; set; }
        #endregion
        #region Constructor
        public DataException() { }
        public DataException(int errorCode)
        {
            ErrorCode = errorCode;
        }
        #endregion

        #region Methods
        public DataException(string message) : base(message)
        {

        }
        public DataException(string message, int errorCode) : base(message)
        {
            ErrorCode = errorCode;
        } 
        #endregion
    }
}
