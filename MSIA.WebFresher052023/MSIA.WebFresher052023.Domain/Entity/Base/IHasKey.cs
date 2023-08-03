using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSIA.WebFresher052023.Domain.Entity.Base
{
    public interface IHasKey
    {
        #region Methods

        /// <summary>
        /// Lấy khóa của đối tượng
        /// </summary>
        /// <returns>Giá trị kiểu guid</returns>
        /// Created by: ldtuan (19/07/2023)
        Guid GetKey(); 
        #endregion
    }
}
