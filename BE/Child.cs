using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Child
    {
        private string id;
        private string motherId;
        private string firstName;
        private DateTime birthDate;
        private bool isSpecialNeeds;
        private string specialNeeds;
        /// <summary>
        /// To string override
        /// </summary>
        /// <returns>string to print</returns>
        public override string ToString()
        {
            string print = "Name: " + firstName + "\nID: " + id + "\nMother's ID: " + motherId + "\nBirth Date: " + birthDate.ToShortDateString();
            if (isSpecialNeeds)
                print += "\nSpecial Needs: " + specialNeeds;
            return print;
        }
        /// <summary>
        /// default constructor
        /// </summary>
        public Child()
        {
            id = null;
            motherId = null;
            firstName = null;
            birthDate = DateTime.Now;
            isSpecialNeeds = false;
            specialNeeds = null;
        }
        /// <summary>
        /// copy constructor
        /// </summary>
        /// <param name="child"></param>
        public Child(Child child)
        {
            if (IDCheck(child.id))
                id = child.id;
            else
                throw new Exception("Wrong ID Number");
            motherId = child.motherId;
            firstName = child.firstName;
            birthDate = child.birthDate;
            isSpecialNeeds = child.isSpecialNeeds;
            specialNeeds = child.specialNeeds;
        }
        /// <summary>
        /// constructor by everything
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="mother_id"></param>
        /// <param name="first_name"></param>
        /// <param name="birth_date"></param>
        /// <param name="is_special_needs"></param>
        /// <param name="special_needs"></param>
        public Child(string ID, string mother_id, string first_name, DateTime birth_date, bool is_special_needs, string special_needs)
        {
            if (IDCheck(ID))
                id = ID;
            else
                throw new Exception("Wrong ID Number");
            motherId = mother_id;
            firstName = first_name;
            birthDate = birth_date;
            isSpecialNeeds = is_special_needs;
            specialNeeds = special_needs;
        }
        #region Properties
        public string Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
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

        public bool IsSpecialNeeds
        {
            get
            {
                return isSpecialNeeds;
            }

            set
            {
                isSpecialNeeds = value;
            }
        }

        public string SpecialNeeds
        {
            get
            {
                return specialNeeds;
            }

            set
            {
                specialNeeds = value;
            }
        }
        /// <summary>
        /// Checks if the received ID is proper
        /// </summary>
        /// <param name="strID"></param>
        /// <returns>True if the ID is proper, otherwise false</returns>
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
