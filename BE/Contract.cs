﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Contract : IComparable
    {
        private static int number = 0;
        private int code;
        private string childId;
        private string nannyId;
        private string motherId;
        private bool haveMet;
        private bool haveSigned;
        private double payForHour;
        private double payForMonth;
        private bool perWhat;
        private DateTime beginDate;
        private DateTime endDate;
        private double salary;
        /// <summary>
        /// To string override
        /// </summary>
        /// <returns>string to print</returns>
        public override string ToString()
        {
            string print = "Number: " + code + "\nChild's ID: " + childId + "\nNanny's ID: " + nannyId + "\nMother's ID: " + motherId +
                "\nDoes They Have Met? " + haveMet.ToString() + "\nDoes They Have Signed? " + haveSigned.ToString() + "\nPay for Hour/Month: " + payForHour + "/" + payForMonth +
                "\nBegin-End Dates: " + beginDate.ToShortDateString() + " - " + endDate.ToShortDateString() + "\nSalary: " + salary;
            return print;
        }
        public int CompareTo(object contract)
        {
            return this.code.CompareTo(((Contract)contract).code);
        }
        /// <summary>
        /// default constructor
        /// </summary>
        public Contract()
        {
            code = number;
            childId = null;
            nannyId = null;
            motherId = null;
            haveMet = false;
            haveSigned = false;
            payForHour = 0;
            payForMonth = 0;
            perWhat = false;
            beginDate = DateTime.Now;
            endDate = DateTime.Now;
        }
        /// <summary>
        /// copy constructor
        /// </summary>
        /// <param name="contract"></param>
        public Contract(Contract contract)
        {
            code = number;
            childId = contract.childId;
            nannyId = contract.nannyId;
            motherId = contract.motherId;
            haveMet = contract.haveMet;
            haveSigned = contract.haveSigned;
            payForHour = contract.payForHour;
            payForMonth = contract.payForMonth;
            perWhat = contract.perWhat;
            beginDate = contract.beginDate;
            endDate = contract.endDate;
        }
        /// <summary>
        /// constructor by everything
        /// </summary>
        /// <param name="child_id"></param>
        /// <param name="nanny_id"></param>
        /// <param name="mother_id"></param>
        /// <param name="have_met"></param>
        /// <param name="have_signed"></param>
        /// <param name="pay_for_hour"></param>
        /// <param name="pay_for_month"></param>
        /// <param name="per_what"></param>
        /// <param name="begin_date"></param>
        /// <param name="end_date"></param>
        public Contract(string child_id, string nanny_id, string mother_id, bool have_met, bool have_signed,
            double pay_for_hour, double pay_for_month, bool per_what, DateTime begin_date, DateTime end_date)
        {
            code = ++number;
            childId = child_id;
            nannyId = nanny_id;
            motherId = mother_id;
            haveMet = have_met;
            haveSigned = have_signed;
            payForHour = pay_for_hour;
            payForMonth = pay_for_month;
            perWhat = per_what;
            beginDate = begin_date;
            endDate = end_date;
        }
        #region Properties
        public string ChildId
        {
            get
            {
                return childId;
            }
            set { childId = value; }
        }

        public string NannyId
        {
            get
            {
                return nannyId;
            }
            set { nannyId = value; }
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
            set { motherId = value; }
        }

        public double Salary
        {
            get
            {
                return salary;
            }

            set
            {
                salary = value;
            }
        }

        public int Code
        {
            get
            {
                return code;
            }
            set
            {
                code = value;
            }
        }
        #endregion
    }
}