using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
   //amit you are stupid
   //hello
    class Mother
    {
        readonly string  id;
        private string lastName;
        private string firstName;
        private string phoneNumber;
        private string address;
        private string searchingArea;
        private bool[] needsNanny = new bool[6];
        private TimeSpan[,] needsNannyHours = new TimeSpan[6, 3];
        private string comments;
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

        public string SearchingArea
        {
            get
            {
                return searchingArea;
            }

            set
            {
                searchingArea = value;
            }
        }

        public string Comments
        {
            get
            {
                return comments;
            }

            set
            {
                comments = value;
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
