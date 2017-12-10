using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Nanny
    {
        private string id;
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
        private TimeSpan[,] workHours = new TimeSpan[6, 3];
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
                bool flag = true;
                foreach (char c in value)
                {
                    if (c < '0' || c > '9')
                        flag = false;
                }
                if (!flag)
                    throw new Exception ("Phone number must to be with only digits!!");
                phoneNumber = value;
            }
        }

        public string Address
        {
            get
            {
                return address;
            }

            set
            {
                address = value;
            }
        }

        public bool IsElevator
        {
            get
            {
                return isElevator;
            }

            set
            {
                isElevator = value;
            }
        }

        public int Floor
        {
            get
            {
                return floor;
            }

            set
            {
                floor = value;
            }
        }

        public int Experience
        {
            get
            {
                return experience;
            }

            set
            {
                experience = value;
            }
        }

        public int MaxChildren
        {
            get
            {
                return maxChildren;
            }

            set
            {
                maxChildren = value;
            }
        }

        public int MinAge
        {
            get
            {
                return minAge;
            }

            set
            {
                minAge = value;
            }
        }

        public int MaxAge
        {
            get
            {
                return maxAge;
            }

            set
            {
                maxAge = value;
            }
        }

        public bool IfHourPaid
        {
            get
            {
                return ifHourPaid;
            }

            set
            {
                ifHourPaid = value;
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

        public bool[] IsWorking
        {
            get
            {
                return isWorking;
            }

            set
            {
                isWorking = value;
            }
        }

        public TimeSpan[,] WorkHours
        {
            get
            {
                return workHours;
            }

            set
            {
                workHours = value;
            }
        }

        public bool VacationCheck
        {
            get
            {
                return vacationCheck;
            }

            set
            {
                vacationCheck = value;
            }
        }

        public string Recommendation
        {
            get
            {
                return recommendation;
            }

            set
            {
                recommendation = value;
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
