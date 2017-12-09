using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    class Contract
    {
        private static int number = 0;
        private string childId;
        private string NannyId;
        private bool haveMet;
        private bool haveSigned;
        private double payForHour;
        private double payForMonth;
        private bool perWhat;
        private DateTime beginDate;
        private DateTime endDate;

        public string ChildId
        {
            get
            {
                return childId;
            }

            set
            {
                childId = value;
            }
        }

        public string NannyId1
        {
            get
            {
                return NannyId;
            }

            set
            {
                NannyId = value;
            }
        }

        public bool HaveMet
        {
            get
            {
                return haveMet;
            }

            set
            {
                haveMet = value;
            }
        }

        public bool HaveSigned
        {
            get
            {
                return haveSigned;
            }

            set
            {
                haveSigned = value;
            }
        }

        public double PayForHour
        {
            get
            {
                return payForHour;
            }

            set
            {
                payForHour = value;
            }
        }

        public double PayForMonth
        {
            get
            {
                return payForMonth;
            }

            set
            {
                payForMonth = value;
            }
        }

        public bool PerWhat
        {
            get
            {
                return perWhat;
            }

            set
            {
                perWhat = value;
            }
        }

        public DateTime BeginDate
        {
            get
            {
                return beginDate;
            }

            set
            {
                beginDate = value;
            }
        }

        public DateTime EndDate
        {
            get
            {
                return endDate;
            }

            set
            {
                endDate = value;
            }
        }
        //public override string ToString()
        //{
        //    return base.ToString();
        //}
    }
}