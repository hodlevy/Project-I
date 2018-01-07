using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class FactoryBL
    {
        /// <summary>
        /// constructor for BL layer
        /// </summary>
        /// <returns>new BL</returns>
        public static IBL GetBL()
        {
            return new Bl();
        }
    }
}
