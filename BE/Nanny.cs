using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Nanny
    {
        readonly string id;
        private string firstName;
        private string lastName;
        readonly DateTime birthDate;
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
        private TimeSpan[,] workHours = new TimeSpan[6, 2];
        private bool vacationCheck;
        private string recommendation;
        public override string ToString()
        {
            string print = "Name: " + firstName + ' ' + lastName + "\nID: " + id + "\nBirth Date: " + birthDate.ToString() + "\nPhone number: " + phoneNumber +
                "\nAddress: " + address + "\nThere Is an Elevator? " + isElevator.ToString() + "\nFloor: " + floor + "\nExperience: " + experience +
                "\nMax Amount of Children: " + maxChildren + "\nRange Ages: " + minAge + " - " + maxAge + " monthes\nPay for Hour/Month: " + payForHour + "/" + payForMonth +
                "\nVacation according to TMT? " + vacationCheck.ToString() + "\nRecommendation: " + recommendation;
            return print;
        }
        public Nanny(string ID, string first_name, string last_name, DateTime birth_date, string phone_number, string address_, bool is_elevator,
            int floor_, int experience_, int max_children, int min_age, int max_age, bool if_hour_paid, double pay_for_hour, double pay_for_month,
            bool vacation_check, string recommendation_, bool[] is_working, TimeSpan[,] work_hours)
        {
            if (IDCheck(ID))
                id = ID;
            else
                throw new Exception("Wrong ID Number");
            lastName = last_name;
            firstName = first_name;
            if (birth_date > DateTime.Now)
                throw new Exception("Wrong Birth Date");
            else
                birthDate = birth_date;
            phoneNumber = phone_number;
            address = address_;
            isElevator = is_elevator;
            floor = floor_;
            experience = experience_;
            maxChildren = max_children;
            minAge = min_age;
            maxAge = max_age;
            ifHourPaid = if_hour_paid;
            payForHour = pay_for_hour;
            payForMonth = pay_for_month;
            vacationCheck = vacation_check;
            recommendation = recommendation_;
            isWorking = is_working;
            workHours = work_hours;
        }
        public Nanny(Nanny nanny)
        {
            if (IDCheck(nanny.id))
                id = nanny.id;
            else
                throw new Exception("Wrong ID Number");
            lastName = nanny.lastName;
            firstName = nanny.firstName;
            if (nanny.birthDate > DateTime.Now)
                throw new Exception("Wrong Birth Date");
            else
                birthDate = nanny.birthDate;
            phoneNumber = nanny.phoneNumber;
            address = nanny.address;
            isElevator = nanny.isElevator;
            floor = nanny.floor;
            experience = nanny.experience;
            maxChildren = nanny.maxChildren;
            minAge = nanny.minAge;
            maxAge = nanny.maxAge;
            ifHourPaid = nanny.ifHourPaid;
            payForHour = nanny.payForHour;
            payForMonth = nanny.payForMonth;
            vacationCheck = nanny.vacationCheck;
            recommendation = nanny.recommendation;
            isWorking = nanny.isWorking;
            workHours = nanny.workHours;
        }
        public Nanny()
        {
            id = null;
            lastName = null;
            firstName = null;
            birthDate = DateTime.Now;
            phoneNumber = null;
            address = null;
            isElevator = false;
            floor = 0;
            experience = 0;
            maxChildren = 0;
            minAge = 0;
            maxAge = 0;
            ifHourPaid = false;
            payForHour = 0;
            payForMonth = 0;
            vacationCheck = false;
            recommendation = null;
            isWorking = null;
            workHours = null;
        }
        #region Properties
        public string Id
        {
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
                    throw new Exception("Phone number must to be with only digits!!");
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
        #endregion
    }
}
