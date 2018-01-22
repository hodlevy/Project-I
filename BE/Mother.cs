using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BE
{
    public class Mother
    {
        readonly string id;
        private string lastName;
        private string firstName;
        private string phoneNumber;
        private string address;
        private string searchingArea;
        [XmlIgnore]
        private bool[] needsNanny = new bool[6];
        private string needsNannyString;
        [XmlIgnore]
        private TimeSpan[,] needsNannyHours = new TimeSpan[6, 2];
        private string needsNannyHoursString;
        private string comments;
        /// <summary>
        /// To string override
        /// </summary>
        /// <returns>string to print</returns>
        public override string ToString()
        {
            string print = "Name: " + firstName + ' ' + lastName + "\nID: " + id + "\nPhone number: " + phoneNumber +
                "\nAddress: " + address + "\nSearching Area: " + searchingArea + "\nComments: " + comments + "\nNeeds Hours:";
            for (int i = 0; i < 6; i++)
            {
                if (needsNanny[i])
                    print += "\n" + (Days)i + ": " + needsNannyHours[i, 0].ToString() + " - " + needsNannyHours[i, 1].ToString();
            }
            return print;
        }
        /// <summary>
        /// default constructor
        /// </summary>
        public Mother()
        {
            id = null;
            lastName = null;
            firstName = null;
            phoneNumber = null;
            address = null;
            searchingArea = null;
            needsNanny = null;
            needsNannyHours = null;
            comments = null;
        }
        /// <summary>
        /// copy constructor
        /// </summary>
        /// <param name="mother"></param>
        public Mother(Mother mother)
        {
            if (IDCheck(mother.id))
                id = mother.id;
            else
                throw new Exception("Wrong ID Number");
            lastName = mother.lastName;
            firstName = mother.firstName;
            bool flag = true;
            foreach (char c in mother.phoneNumber)
            {
                if (c < '0' || c > '9')
                    flag = false;
            }
            if (!flag)
                throw new Exception("Phone number must to be with only digits!!");
            phoneNumber = mother.phoneNumber;
            address = mother.address;
            searchingArea = mother.searchingArea;
            needsNanny = mother.needsNanny;
            needsNannyHours = mother.needsNannyHours;
            comments = mother.comments;
        }
        /// <summary>
        /// constructor by everything
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="first_name"></param>
        /// <param name="last_name"></param>
        /// <param name="phone_number"></param>
        /// <param name="address_"></param>
        /// <param name="searching_area"></param>
        /// <param name="needs_nanny"></param>
        /// <param name="needs_nanny_hours"></param>
        /// <param name="comments_"></param>
        public Mother(string ID, string first_name, string last_name, string phone_number, string address_, string searching_area,
            bool[] needs_nanny, TimeSpan[,] needs_nanny_hours, string comments_)
        {
            if (IDCheck(ID))
                id = ID;
            else
                throw new Exception("Wrong ID Number");
            lastName = last_name;
            firstName = first_name;
            bool flag = true;
            foreach (char c in phone_number)
            {
                if (c < '0' || c > '9')
                    flag = false;
            }
            if (!flag)
                throw new Exception("Phone number must to be with only digits!!");
            phoneNumber = phone_number;
            address = address_;
            searchingArea = searching_area;
            needsNanny = needs_nanny;
            needsNannyHours = needs_nanny_hours;
            comments = comments_;
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

        public TimeSpan[,] NeedsNannyHours
        {
            get
            {
                return needsNannyHours;
            }

            set
            {
                needsNannyHours = value;
            }
        }

        public bool[] NeedsNanny
        {
            get
            {
                return needsNanny;
            }

            set
            {
                needsNanny = value;
            }
        }

        public string NeedsNannyString
        {
            get
            {
                if (needsNanny == null)
                    return null;
                string result = "";
                if (needsNanny != null)
                {
                    for (int i = 0; i < 6; i++)
                            result += "," + needsNanny[i];
                }
                return result;
            }

            set
            {
                if (value != null && value.Length > 0)
                {
                    string[] values = value.Split(',');
                    needsNanny = new bool[6];
                    for (int i = 0; i < 6; i++)
                            needsNanny[i] = bool.Parse(values[i]);
                }
            }
        }

        public string NeedsNannyHoursString
        {
            get
            {
                if (needsNannyHours == null)
                    return null;
                string result = "";
                if (needsNannyHours != null)
                {
                    for (int i = 0; i < 6; i++)
                        for (int j = 0; j < 2; j++)
                            result += "," + needsNannyHours[i, j];
                }
                return result;
            }
            set
            {
                if (value != null && value.Length > 0)
                {
                    string[] values = value.Split(',');
                    needsNannyHours = new TimeSpan[6, 2];
                    for (int i = 0; i < 6; i++)
                        for (int j = 0; j < 2; j++)
                            needsNannyHours[i, j] = TimeSpan.Parse(values[i]);
                }
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
