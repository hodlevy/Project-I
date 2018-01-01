using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    internal class Dal_imp : Idal
    {
        public Dal_imp()
        {
            DataSource.listNanny = new List<Nanny>();
            DataSource.listMother = new List<Mother>();
            DataSource.listChild = new List<Child>();
            DataSource.listContract = new List<Contract>();
        }
        #region Nanny
        void Idal.AddNanny(Nanny nanny)
        {
            Nanny nanny2 = GetNanny(nanny.Id);
            if(nanny2 != null)
                throw new Exception("Nanny already exist");
            DataSource.listNanny.Add(nanny2);
        }
        void Idal.DeleteNanny(string ID)
        {
            Nanny nanny2 = GetNanny(ID);
            if (nanny2 == null)
                throw new Exception("Nanny doesn't exist");
            DataSource.listNanny.Remove(nanny2);
            List<Contract> contracts = GetContractByID(nanny2.Id);
            if(contracts != null)
            {
                foreach(Contract contract in contracts)
                    DataSource.listContract.Remove(contract);
            }
        }
        void Idal.UpdateNanny(Nanny nanny)
        {
            Nanny nanny2 = GetNanny(nanny.Id);
            if (nanny2 == null)
                throw new Exception("Nanny doesn't exist");
            foreach (Nanny nan in DataSource.listNanny)
            {
                if (nanny2.Id == nan.Id)
                {
                    DataSource.listNanny.Remove(nan);
                    DataSource.listNanny.Add(nanny2);
                    break;
                }
            }
        }
        #endregion
        #region Mother
        void Idal.AddMother(Mother mother)
        {
            Mother mother2 = GetMother(mother.Id);
            if (mother2 != null)
                throw new Exception("Mother already exist");
            DataSource.listMother.Add(mother2);
        }
        void Idal.DeleteMother(string ID)
        {
            Mother mother2 = GetMother(ID);
            if (mother2 == null)
                throw new Exception("Mother doesn't exist");
            DataSource.listMother.Remove(mother2);
            List<Contract> contracts = GetContractByID(mother2.Id);
            if (contracts != null)
            {
                foreach (Contract contract in contracts)
                    DataSource.listContract.Remove(contract);
            }
        }
        void Idal.UpdateMother(Mother mother)
        {
            Mother mother2 = GetMother(mother.Id);
            if (mother2 == null)
                throw new Exception("Mother doesn't exist");
            foreach (Mother mom in DataSource.listMother)
            {
                if (mother2.Id == mom.Id)
                {
                    DataSource.listMother.Remove(mom);
                    DataSource.listMother.Add(mother2);
                    break;
                }
            }
        }
        #endregion
        #region Child
        void Idal.AddChild(Child child)
        {
            Child child2 = GetChild(child.Id);
            if (child2.Id != null)
                throw new Exception("Child already exist");
            Mother mother = GetMother(child.MotherId);
            if (mother.Id == null)
                throw new Exception("Mother doesn't exist");
            DataSource.listChild.Add(child2);
        }
        void Idal.DeleteChild(string ID)
        {
            Child child2 = GetChild(ID);
            if (child2.Id == null)
                throw new Exception("Child doesn't exist");
            DataSource.listChild.Remove(child2);
            List<Contract> contracts = GetContractByID(child2.Id);
            if (contracts != null)
            {
                foreach (Contract contract in contracts)
                    DataSource.listContract.Remove(contract);
            }
        }
        void Idal.UpdateChild(Child child)
        {
            Child child2 = GetChild(child.Id);
            if (child2 == null)
                throw new Exception("Child doesn't exist");
            foreach (Child ch in DataSource.listChild)
            {
                if (child2.Id == ch.Id)
                {
                    DataSource.listChild.Remove(ch);
                    DataSource.listChild.Add(child2);
                    break;
                }
            }
        }
        #endregion
        #region Contract
        void Idal.AddContract(Contract contract)
        {
            Nanny nanny = GetNanny(contract.NannyId);
            if (nanny == null)
                throw new Exception("Nanny doesn't exist");
            Mother mother = GetMother(contract.MotherId);
            if (mother == null)
                throw new Exception("Mother doesn't exist");
            contract.Number++;
            DataSource.listContract.Add(contract);
        }
        void Idal.DeleteContract(int number)
        {
            Contract contract2 = GetContract(number);
            if (contract2 == null)
                throw new Exception("Contract doesn't exist");
            DataSource.listContract.Remove(contract2);
        }
        void Idal.UpdateContract(Contract contract)
        {
            Contract contract2 = GetContract(contract.Number);
            if (contract2 == null)
                throw new Exception("Contract doesn't exist");
            foreach (Contract contra in DataSource.listContract)
            {
                if (contract2.Number == contra.Number)
                {
                    DataSource.listContract.Remove(contra);
                    DataSource.listContract.Add(contract2);
                    break;
                }
            }
        }
        #endregion
        #region Lists
        List<Nanny> Idal.AllNannys()
        {
            return DataSource.listNanny;
        }
        List<Mother> Idal.AllMothers()
        {
            return DataSource.listMother;
        }
        List<Child> Idal.AllChildren()
        {
            List<Child> listChild = null;
            foreach (Mother mother in DataSource.listMother)
            {
                foreach (Child child in DataSource.listChild)
                {
                    if (child.MotherId == mother.Id)
                        listChild.Add(child);
                }
            }
            return listChild;
        }
        List<Contract> Idal.AllContracts()
        {
            return DataSource.listContract;
        }
        #endregion
        #region Get Function
        Nanny GetNanny(string nannyID)
        {
            Nanny nanny = new Nanny();
            var v = from item in DataSource.listNanny
                    where item.Id == nannyID
                    select item;
            nanny = v.First();
            return nanny;
        }
        Mother GetMother(string motherID)
        {
            Mother mother = new Mother();
            var v = from item in DataSource.listMother
                    where item.Id == motherID
                    select item;
            mother = v.First();
            return mother;
        }
        Child GetChild(string childID)
        {
            Child child = new Child();
            //var v = from item in DataSource.listChild
            //        where item.Id == childID
            //        select item;
            //child = v.First();
            List<Child> list = null;
            list[0] = null;
            list = DataSource.listChild.FindAll(item => item.Id == childID);
            child = list[0];
            return child;
        }
        Contract GetContract(int number)
        {
            Contract contract = new Contract();
            var v = from item in DataSource.listContract
                    where item.Number == number
                    select item;
            contract = v.First();
            return contract;
        }
        List<Contract> GetContractByID(string ID)
        {
            List<Contract> contracts = null;
            contracts = DataSource.listContract.FindAll(item => item.NannyId == ID || item.MotherId == ID || item.ChildId == ID);
            return contracts;
        }
        #endregion
    }
}