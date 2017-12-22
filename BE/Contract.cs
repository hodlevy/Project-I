using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Contract
    {
        private static int number = 0;
        readonly string childId;
        readonly string nannyId;
        readonly string motherId;
        private bool haveMet;
        private bool haveSigned;
        private double payForHour;
        private double payForMonth;
        private bool perWhat;
        private DateTime beginDate;
        private DateTime endDate;
        // צריך לעשות את ה2% הנחה לכל אח
        // ה2% מופיע ב בי-אל ואני חושב שגם זה צריך
        public double MonthlyPayment()
        {
            if (perWhat)
                return PayForMonth;
            return 4 * payForHour;
        }
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

        public string NannyId
        {
            get
            {
                return nannyId;
            }

            set
            {
                nannyId = value;
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

        public int Number
        {
            get
            {
                return number;
            }
            set
            {
                number = value;
            }
        }

        public string MotherId
        {
            get
            {
                return motherId;
            }

            set
            {
                motherId = value;
            }
        }
        //public override string ToString()
        //{
        //    return base.ToString();
        //}
    }
}