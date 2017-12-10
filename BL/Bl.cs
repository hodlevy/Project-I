using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BL
{
    public class Bl : IBL
    {
        void AddNanny(Nanny nanny)
        {
            int nannyAge = DateTime.Now.Year - nanny.BirthDate.Year;
            if (nannyAge < 18)
                throw new Exception("Nanny is too young");
            bool flag = false;
            foreach (Nanny nanny2 in DataSource.listNanny)
            {
                if (nanny.Id == nanny2.Id)
                {
                    flag = true;
                }
            }
            if (flag)
                throw new Exception("Nanny already exist");
            DataSource.listNanny.Add(nanny);
        }
        void DeleteNanny(Nanny nanny)
        {
            DataSource.listNanny.Remove(nanny);
        }
        void UpdateNanny(Nanny nanny)
        {
            foreach (Nanny nanny2 in DataSource.listNanny)
            {
                if (nanny.Id == nanny2.Id)
                {
                    DataSource.listNanny.Remove(nanny2);
                    DataSource.listNanny.Add(nanny);
                    break;
                }
            }
        }
        void AddMother(Mother mother)
        {
            bool flag = false;
            foreach (Mother mother2 in DataSource.listMother)
            {
                if (mother.Id == mother2.Id)
                {
                    flag = true;
                }
            }
            if (flag)
                throw new Exception("Mother already exist");
            DataSource.listMother.Add(mother);
        }
        void DeleteMother(Mother mother)
        {
            DataSource.listMother.Remove(mother);
        }
        void UpdateMother(Mother mother)
        {
            foreach (Mother mother2 in DataSource.listMother)
            {
                if (mother2.Id == mother.Id)
                {
                    DataSource.listMother.Remove(mother2);
                    DataSource.listMother.Add(mother);
                    break;
                }
            }
        }
        void AddChild(Child child)
        {
            bool flag = false;
            foreach (Child child2 in DataSource.listChild)
            {
                if (child.Id == child2.Id)
                {
                    flag = true;
                }
            }
            if (flag)
                throw new Exception("Child already exist");
            DataSource.listChild.Add(child);
        }
        void DeleteChild(Child child)
        {
            DataSource.listChild.Remove(child);
        }
        void UpdateChild(Child child)
        {
            foreach (Child child2 in DataSource.listChild)
            {
                if (child2.Id == child.Id)
                {
                    DataSource.listChild.Remove(child2);
                    DataSource.listChild.Add(child);
                    break;
                }
            }
        }
        void AddContract(Contract contract)
        {
            int childMonthes = 0;
            foreach (Child child in DataSource.listChild)
            {
                if (contract.ChildId == child.Id)
                    childMonthes = child.BirthDate.Month;
            }
            //if (child.BirthDate.y )
            bool flag = false;
            string id = contract.NannyId;
            foreach (Nanny nanny in DataSource.listNanny)
            {
                if (id == nanny.Id)
                {
                    flag = true;
                }
            }
            if (!flag)
                throw new Exception("Nanny doesn't exist");
            flag = false;
            id = contract.MotherId;
            foreach (Mother mother in DataSource.listMother)
            {
                if (id == mother.Id)
                {
                    flag = true;
                }
            }
            if (!flag)
                throw new Exception("Mother doesn't exist");
            contract.Number++;
            DataSource.listContract.Add(contract);
        }
        void DeleteContract(Contract contract)
        {
            DataSource.listContract.Remove(contract);
        }
        void UpdateContract(Contract contract)
        {
            foreach (Contract contract2 in DataSource.listContract)
            {
                if (contract.Number == contract2.Number)
                {
                    DataSource.listContract.Remove(contract2);
                    DataSource.listContract.Add(contract);
                    break;
                }
            }
        }
        List<Nanny> AllNannys()
        {
            return DataSource.listNanny;
        }
        List<Mother> AllMothers()
        {
            return DataSource.listMother;
        }
        List<Child> AllChildren()
        {
            return DataSource.listChild;
        }
        List<Contract> AllContracts()
        {
            return DataSource.listContract;
        }
    }
}
