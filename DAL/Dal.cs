using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Dal
    {
        /// <summary>
        /// constructor for the DAL layer
        /// </summary>
        /// <returns>new DAL</returns>
        public static Idal GetDal()
        {
            return new Dal_imp();
        }
    }
}
