using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    class Nanny 
    {
        readonly string id;
        private string lastName;
        private string firstName;
        private DateTime birthDate;
        private string phoneNumber;
        private string address;
        private bool isElevator;
        private int floor;
        private int experience;
        private int maxChildren;
        private int minAge;
        private int maxAge;
        private bool ifHourPaid;
        private double payForHour;
        private double payForMonth;
        private bool[] isWorking = new bool[6];
        private TimeSpan[,] workHours = new TimeSpan[6,3];
        private bool vacationCheck;
        private string recommendation;
        //public override string ToString()
        //{
        //    return base.ToString();
        //}
        public string Id
        {
            set
            {
                    if (IDCheck(value))
                        id = value;
                    else
                        throw new Exception("Wrong ID Number"); 
            }
            get
            {
                return id;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }

            set
            {
                lastName = value;
            }
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }

            set
            {
                firstName = value;
            }
        }

        public DateTime BirthDate
        {
            get
            {
                return birthDate;
            }

            set
            {
                birthDate = value;
            }
        }

        public string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }

            set
            {
                phoneNumber = value;
            }
        }

        static bool IDCheck(String strID)
        {
            int[] id_12_digits = { 1, 2, 1, 2, 1, 2, 1, 2, 1 };
            int count = 0;

            if (strID == null)
                return false;

            strID = strID.PadLeft(9, '0');

            for (int i = 0; i < 9; i++)
            {
                int num = Int32.Parse(strID.Substring(i, 1)) * id_12_digits[i];

                if (num > 9)
                    num = (num / 10) + (num % 10);

                count += num;
            }

            return (count % 10 == 0);
        }
    }
}
