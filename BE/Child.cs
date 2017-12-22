using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Child
    {
        readonly string id;
        readonly string motherId;
        private string firstName;
        readonly DateTime birthDate;
        private bool isSpecialNeeds;
        private string specialNeeds;
        public override string ToString()
        {
            string print = "Name: " + firstName + "\nID: " + id + "\nMother's ID: " + motherId + "\nBirth Date: " + birthDate.ToString();
            if (isSpecialNeeds)
                print += "\nSpecial Needs: " + specialNeeds;
            return print;
        }
        public Child()
        {
            id = null;
            motherId = null;
            firstName = null;
            birthDate = DateTime.Now;
            isSpecialNeeds = false;
            specialNeeds = null;
        }
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
        }

        public string MotherId
        {
            get
            {
                return motherId;
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
