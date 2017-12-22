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
        void Idal.DeleteNanny(Nanny nanny)
        {
            Nanny nanny2 = GetNanny(nanny.Id);
            if (nanny2 == null)
                throw new Exception("Nanny doesn't exist");
            DataSource.listNanny.Remove(nanny2);
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
        void Idal.DeleteMother(Mother mother)
        {
            Mother mother2 = GetMother(mother.Id);
            if (mother2 == null)
                throw new Exception("Mother doesn't exist");
            DataSource.listMother.Remove(mother2);
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
            if (child2 != null)
                throw new Exception("Child already exist");
            DataSource.listChild.Add(child2);
        }
        void Idal.DeleteChild(Child child)
        {
            Child child2 = GetChild(child.Id);
            if (child2 == null)
                throw new Exception("Child doesn't exist");
            DataSource.listChild.Remove(child2);
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
            if (nanny != null)
                throw new Exception("Nanny already exist");
            Mother mother = GetMother(contract.MotherId);
            if (mother != null)
                throw new Exception("Mother already exist");
            contract.Number++;
            DataSource.listContract.Add(contract);
        }
        void Idal.DeleteContract(Contract contract)
        {
            DataSource.listContract.Remove(contract);
        }
        void Idal.UpdateContract(Contract contract)
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
            return DataSource.listChild;
        }
        List<Contract> Idal.AllContracts()
        {
            return DataSource.listContract;
        }
        #endregion
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
            var v = from item in DataSource.listChild
                    where item.Id == childID
                    select item;
            child = v.First();
            return child;
        }
    }
}
