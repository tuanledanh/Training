using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class NotFoundException : Exception
    {
        #region Fields
        public int ErrorCode { get; set; }
        #endregion
        #region Constructor
        public NotFoundException() { }
        public NotFoundException(int errorCode)
        {
            ErrorCode = errorCode;
        }
        #endregion

        #region Methods
        public NotFoundException(string message) : base(message)
        {

        }
        public NotFoundException(string message, int errorCode) : base(message)
        {
            ErrorCode = errorCode;
        } 
        #endregion
    }
}
