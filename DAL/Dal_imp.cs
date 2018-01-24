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
        /// <summary>
        /// initialization for DAL
        /// </summary>
        public Dal_imp()
        {
            DataSource.listNanny = new List<Nanny>();
            DataSource.listMother = new List<Mother>();
            DataSource.listChild = new List<Child>();
            DataSource.listContract = new List<Contract>();
        }
        #region Nanny
        /// <summary>
        /// add nanny
        /// </summary>
        /// <param name="nanny"></param>
        void Idal.AddNanny(Nanny nanny)
        {
            Nanny nanny2 = GetNanny(nanny.Id);
            if(nanny2.Id != null)
                throw new Exception("Nanny already exist");
            DataSource.listNanny.Add(nanny);
        }
        /// <summary>
        /// delete nanny
        /// </summary>
        /// <param name="ID"></param>
        void Idal.DeleteNanny(string ID)
        {
            Nanny nanny2 = GetNanny(ID);
            if (nanny2.Id == null)
                throw new Exception("Nanny doesn't exist");
            DataSource.listNanny.Remove(nanny2);
            // delete the contracts she related to
            List<Contract> contracts = GetContractsByID(nanny2.Id);
            if(contracts != null)
            {
                foreach(Contract contract in contracts)
                    DataSource.listContract.Remove(contract);
            }
        }
        /// <summary>
        /// update nanny
        /// </summary>
        /// <param name="nanny"></param>
        void Idal.UpdateNanny(Nanny nanny)
        {
            Nanny nanny2 = GetNanny(nanny.Id);
            if (nanny2.Id == null)
                throw new Exception("Nanny doesn't exist");
            foreach (Nanny nan in DataSource.listNanny)
            {
                if (nanny.Id == nan.Id)
                {
                    DataSource.listNanny.Remove(nan);
                    DataSource.listNanny.Add(nanny);
                    break;
                }
            }
        }
        #endregion
        #region Mother
        /// <summary>
        /// add mother
        /// </summary>
        /// <param name="mother"></param>
        void Idal.AddMother(Mother mother)
        {
            Mother mother2 = GetMother(mother.Id);
            if (mother2.Id != null)
                throw new Exception("Mother already exist");
            DataSource.listMother.Add(mother);
        }
        /// <summary>
        /// delete mother
        /// </summary>
        /// <param name="ID"></param>
        void Idal.DeleteMother(string ID)
        {
            Mother mother2 = GetMother(ID);
            if (mother2.Id == null)
                throw new Exception("Mother doesn't exist");
            DataSource.listMother.Remove(mother2);
            // delete the contracts she related to
            List<Contract> contracts = GetContractsByID(mother2.Id);
            if (contracts != null)
            {
                foreach (Contract contract in contracts)
                    DataSource.listContract.Remove(contract);
            }
        }
        /// <summary>
        /// update mother
        /// </summary>
        /// <param name="mother"></param>
        void Idal.UpdateMother(Mother mother)
        {
            Mother mother2 = GetMother(mother.Id);
            if (mother2.Id == null)
                throw new Exception("Mother doesn't exist");
            foreach (Mother mom in DataSource.listMother)
            {
                if (mother.Id == mom.Id)
                {
                    DataSource.listMother.Remove(mom);
                    DataSource.listMother.Add(mother);
                    break;
                }
            }
        }
        #endregion
        #region Child
        /// <summary>
        /// add child
        /// </summary>
        /// <param name="child"></param>
        void Idal.AddChild(Child child)
        {
            Child child2 = GetChild(child.Id);
            if (child2.Id != null)
                throw new Exception("Child already exist");
            Mother mother = GetMother(child.MotherId);
            if (mother.Id == null)
                throw new Exception("Mother doesn't exist");
            DataSource.listChild.Add(child);
        }
        /// <summary>
        /// delete child
        /// </summary>
        /// <param name="ID"></param>
        void Idal.DeleteChild(string ID)
        {
            Child child2 = GetChild(ID);
            if (child2.Id == null)
                throw new Exception("Child doesn't exist");
            DataSource.listChild.Remove(child2);
            // delete the contracts he related to
            List<Contract> contracts = GetContractsByID(child2.Id);
            if (contracts != null)
            {
                foreach (Contract contract in contracts)
                    DataSource.listContract.Remove(contract);
            }
        }
        /// <summary>
        /// update child
        /// </summary>
        /// <param name="child"></param>
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
                    DataSource.listChild.Add(child);
                    break;
                }
            }
        }
        #endregion
        #region Contract
        /// <summary>
        /// add contract
        /// </summary>
        /// <param name="contract"></param>
        void Idal.AddContract(Contract contract)
        {
            Nanny nanny = GetNanny(contract.NannyId);
            if (nanny.Id == null)
                throw new Exception("Nanny doesn't exist");
            Mother mother = GetMother(contract.MotherId);
            if (mother.Id == null)
                throw new Exception("Mother doesn't exist");
            Child child = GetChild(contract.ChildId);
            int age = DateTime.Now.Month - child.BirthDate.Month + (DateTime.Now.Year - child.BirthDate.Year) * 12;
            if (nanny.MaxAge < age || nanny.MinAge > age)
                throw new Exception("The child's age doesn't meet the conditions of the nanny");
            DataSource.listContract.Add(contract);
        }
        /// <summary>
        /// delete contract
        /// </summary>
        /// <param name="number"></param>
        void Idal.DeleteContract(int number)
        {
            Contract contract2 = GetContract(number);
            if (contract2.Code != number)
                throw new Exception("Contract doesn't exist");
            DataSource.listContract.Remove(contract2);
        }
        /// <summary>
        /// update contract
        /// </summary>
        /// <param name="contract"></param>
        void Idal.UpdateContract(Contract contract)
        {
            Contract contract2 = GetContractByID(contract.ChildId);
            if (contract2.ChildId == null) //
                throw new Exception("Contract doesn't exist");
            foreach (Contract contra in DataSource.listContract)
            {
                if (contract.ChildId == contra.ChildId)
                {
                    DataSource.listContract.Remove(contra);
                    DataSource.listContract.Add(contract);
                    DataSource.listContract.Sort();
                    break;
                }
            }
        }
        #endregion
        #region Lists
        /// <summary>
        /// get nanny's list
        /// </summary>
        /// <returns>nanny's list</returns>
        List<Nanny> Idal.AllNannys()
        {
            return DataSource.listNanny;
        }
        /// <summary>
        /// get mother's list
        /// </summary>
        /// <returns>mother's list</returns>
        List<Mother> Idal.AllMothers()
        {
            return DataSource.listMother;
        }
        /// <summary>
        /// get children's list
        /// </summary>
        /// <returns>children's list</returns>
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
        /// <summary>
        /// get contract's list
        /// </summary>
        /// <returns>contract's list</returns>
        List<Contract> Idal.AllContracts()
        {
            List<Contract> listContract = null;
            DataSource.listContract.Sort();
            return listContract;
        }
        #endregion
        #region Get Function
        /// <summary>
        /// get nanny by Id number
        /// </summary>
        /// <param name="nannyID"></param>
        /// <returns>nanny</returns>
        Nanny GetNanny(string nannyID)
        {
            Nanny nanny = new Nanny();
            List<Nanny> list = null;
            list = DataSource.listNanny.FindAll(item => item.Id == nannyID);
            if (list.Count() != 0)
                nanny = list[0];
            return nanny;
        }
        /// <summary>
        /// get mother by Id number
        /// </summary>
        /// <param name="motherID"></param>
        /// <returns>mother</returns>
        Mother GetMother(string motherID)
        {
            Mother mother = new Mother();
            List<Mother> list = null;
            list = DataSource.listMother.FindAll(item => item.Id == motherID);
            if (list.Count() != 0)
                mother = list[0];
            return mother;
        }
        /// <summary>
        /// get child by Id number
        /// </summary>
        /// <param name="childID"></param>
        /// <returns>child</returns>
        Child GetChild(string childID)
        {
            Child child = new Child();
            List<Child> list = null;
            list = DataSource.listChild.FindAll(item => item.Id == childID);
            if(list.Count() != 0)
                child = list[0];
            return child;
        }
        /// <summary>
        /// get contract by number
        /// </summary>
        /// <param name="number"></param>
        /// <returns>contract</returns>
        Contract GetContract(int number)
        {
            Contract contract = new Contract();
            List<Contract> list = null;
            list = DataSource.listContract.FindAll(item => item.Code == number);
            if (list.Count() != 0)
                contract = list[0];
            return contract;
        }
        /// <summary>
        /// get contract by Id number
        /// </summary>
        /// <param name="ID"></param>
        /// <returns>contract</returns>
        Contract GetContractByID(string ID)
        {
            List<Contract> contracts = null;
            contracts = DataSource.listContract.FindAll(item => item.NannyId == ID || item.MotherId == ID || item.ChildId == ID);
            return contracts[0];
        }
        /// <summary>
        /// get all the contracts' list that fits to the id number
        /// </summary>
        /// <param name="ID"></param>
        /// <returns>list of contracts</returns>
        List<Contract> GetContractsByID(string ID)
        {
            List<Contract> contracts = null;
            contracts = DataSource.listContract.FindAll(item => item.NannyId == ID || item.MotherId == ID || item.ChildId == ID);
            return contracts;
        }

        Nanny Idal.GetNanny(string nannyID)
        {
            throw new NotImplementedException();
        }

        Mother Idal.GetMother(string motherID)
        {
            throw new NotImplementedException();
        }

        Child Idal.GetChild(string childID)
        {
            throw new NotImplementedException();
        }

        Contract Idal.GetContract(int number)
        {
            throw new NotImplementedException();
        }

        Contract Idal.GetContractByID(string ID)
        {
            throw new NotImplementedException();
        }

        List<Contract> Idal.GetContractsByID(string ID)
        {
            throw new NotImplementedException();
        }

        void Idal.Reset()
        {
            DataSource.listChild = null;
            DataSource.listContract = null;
            DataSource.listMother = null;
            DataSource.listNanny = null;
        }
        #endregion
    }
}