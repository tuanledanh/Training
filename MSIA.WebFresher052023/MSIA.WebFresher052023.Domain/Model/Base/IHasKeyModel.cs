using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSIA.WebFresher052023.Domain.Model.Base
{
    public interface IHasKeyModel
    {
        #region Methods

        /// <summary>
        /// Lấy khóa của đối tượng
        /// </summary>
        /// <returns>Giá trị kiểu string</returns>
        /// Created by: ldtuan (20/07/2023)
        string GetKey();
        #endregion
    }
}
