using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.IO;
using System.Xml.Serialization;

namespace DAL
{
    public class Dal_XML_imp : Idal
    {
        #region Path Strings
        private readonly string nannyPath = @"nannyXMLFile.xml";
        private readonly string motherPath = @"motherXMLFile.xml";
        private readonly string childPath = @"childXMLFile.xml";
        private readonly string contractPath = @"contractXMLFile.xml";
        #endregion
        #region Nanny
        public void AddNanny(Nanny nanny)
        {
            Nanny nanny2 = GetNanny(nanny.Id);
            if (nanny2.Id != null)
                throw new Exception("Nanny already exist");
            List<Nanny> nannies = LoadFromXML<List<Nanny>>(nannyPath);
            nannies.Add(nanny);
            SaveToXML(nannies, nannyPath);
        }
        public void DeleteNanny(string ID)
        {
            Nanny nanny = GetNanny(ID);
            if (nanny.Id == null)
                throw new Exception("Nanny doesn't exist");
            List<Nanny> nannies = LoadFromXML<List<Nanny>>(nannyPath);
            nannies.Remove(nanny);
            SaveToXML(nannies, nannyPath);
            // delete the contracts she related to
            List<Contract> contractList = LoadFromXML<List<Contract>>(contractPath);  
            List<Contract> contracts = GetContractsByID(nanny.Id);
            if (contracts != null)
            {
                foreach (Contract contract in contracts)
                    contractList.Remove(contract);
                SaveToXML(contractList, nannyPath);
            }
        }
        public void UpdateNanny(Nanny nanny)
        {
            Nanny nanny2 = GetNanny(nanny.Id);
            if (nanny2.Id == null)
                throw new Exception("Nanny doesn't exist");
            List<Nanny> nannies = LoadFromXML<List<Nanny>>(nannyPath);
            foreach (Nanny nan in nannies)
            {
                if (nanny.Id == nan.Id)
                {
                    nannies.Remove(nan);
                    nannies.Add(nanny);
                    break;
                }
            }
            SaveToXML(nannies, nannyPath);
        }
        public List<Nanny> AllNannys()
        {
            List<Nanny> nannies = LoadFromXML<List<Nanny>>(nannyPath);
            return nannies;
        }
        #endregion
        #region Mother
        public void AddMother(Mother mother)
        {
            Mother mother2 = GetMother(mother.Id);
            if (mother2.Id != null)
                throw new Exception("Mother already exist");
            List<Mother> mothers = LoadFromXML<List<Mother>>(motherPath);
            mothers.Add(mother);
            SaveToXML(mothers, nannyPath);
        }
        public void DeleteMother(string ID)
        {
            Mother mother = GetMother(ID);
            if (mother.Id == null)
                throw new Exception("Mother doesn't exist");
            List<Mother> mothers = LoadFromXML<List<Mother>>(motherPath);
            mothers.Remove(mother);
            SaveToXML(mothers, nannyPath);
            // delete the contracts she related to
            List<Contract> contractList = LoadFromXML<List<Contract>>(contractPath);
            List<Contract> contracts = GetContractsByID(mother.Id);
            if (contracts != null)
            {
                foreach (Contract contract in contracts)
                    contractList.Remove(contract);
                SaveToXML(contractList, nannyPath);
            }
        }
        public void UpdateMother(Mother mother)
        {
            Mother mother2 = GetMother(mother.Id);
            if (mother2.Id == null)
                throw new Exception("Mother doesn't exist");
            List<Mother> mothers = LoadFromXML<List<Mother>>(motherPath);
            foreach (Mother mom in mothers)
            {
                if (mother.Id == mom.Id)
                {
                    mothers.Remove(mom);
                    mothers.Add(mother);
                    break;
                }
            }
            SaveToXML(mothers, nannyPath);
        }
        public List<Mother> AllMothers()
        {
            List<Mother> mothers = LoadFromXML<List<Mother>>(motherPath);
            return mothers;
        }
        #endregion
        #region Child
        public void AddChild(Child child)
        {

        }
        public void DeleteChild(string ID)
        {

        }
        public void UpdateChild(Child child)
        {

        }
        public List<Child> AllChildren()
        {
            List<Child> children = LoadFromXML<List<Child>>(childPath);
            return children;
        }
        #endregion
        #region Contract
        public void AddContract(Contract contract)
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
            List<Contract> contracts = LoadFromXML<List<Contract>>(contractPath);
            contracts.Add(contract);
            SaveToXML(contracts, contractPath);
        }
        public void DeleteContract(int number)
        {
            Contract contract = GetContract(number);
            if (contract.Code != number)
                throw new Exception("Contract doesn't exist");
            List<Contract> contracts = LoadFromXML<List<Contract>>(contractPath);
            contracts.Remove(contract);
            SaveToXML(contracts, contractPath);
        }
        public void UpdateContract(Contract contract)
        {
            Contract contract2 = GetContractByID(contract.ChildId);
            if (contract2.ChildId == null) //
                throw new Exception("Contract doesn't exist");
            List<Contract> contracts = LoadFromXML<List<Contract>>(contractPath);
            foreach (Contract contra in contracts)
            {
                if (contract.ChildId == contra.ChildId)
                {
                    contracts.Remove(contra);
                    contracts.Add(contract);
                    contracts.Sort();
                    break;
                }
            }
            SaveToXML(contracts, contractPath);
        }
        public List<Contract> AllContracts()
        {
            List<Contract> contracts = LoadFromXML<List<Contract>>(contractPath);
            return contracts;
        }
        #endregion
        #region XML Serializer
        private static void SaveToXML<T>(T source, string path)
        {
            FileStream file = new FileStream(path, FileMode.Create);
            XmlSerializer xmlSerializer = new XmlSerializer(source.GetType());
            xmlSerializer.Serialize(file, source);
            file.Close();
        }
        private static T LoadFromXML<T>(string path)
        {
            FileStream file = new FileStream(path, FileMode.Open);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            T result = (T)xmlSerializer.Deserialize(file);
            file.Close();
            return result;
        }
        #endregion
        #region Get Functions
        Nanny GetNanny(string nannyID)
        {
            List<Nanny> list = LoadFromXML<List<Nanny>>(nannyPath);
            Nanny nanny = new Nanny();
            List<Nanny> list2 = null;
            list2 = list.FindAll(item => item.Id == nannyID);
            if (list2.Count() != 0)
                nanny = list2[0];
            return nanny;
        }
        Mother GetMother(string motherID)
        {
            List<Mother> list = LoadFromXML<List<Mother>>(motherPath);
            Mother mother = new Mother();
            List<Mother> list2 = null;
            list2 = list.FindAll(item => item.Id == motherID);
            if (list2.Count() != 0)
                mother = list2[0];
            return mother;
        }
        Child GetChild(string childID)
        {
            List<Child> list = LoadFromXML<List<Child>>(childPath);
            Child child = new Child();
            List<Child> list2 = null;
            list2 = list.FindAll(item => item.Id == childID);
            if (list2.Count() != 0)
                child = list2[0];
            return child;
        }
        Contract GetContract(int number)
        {
            List<Contract> list = LoadFromXML<List<Contract>>(contractPath);
            Contract contract = new Contract();
            List<Contract> list2 = null;
            list2 = list.FindAll(item => item.Code == number);
            if (list2.Count() != 0)
                contract = list2[0];
            return contract;
        }
        Contract GetContractByID(string ID)
        {
            List<Contract> list = LoadFromXML<List<Contract>>(contractPath);
            List<Contract> contracts = null;
            contracts = list.FindAll(item => item.NannyId == ID || item.MotherId == ID || item.ChildId == ID);
            return contracts[0];
        }
        List<Contract> GetContractsByID(string ID)
        {
            List<Contract> list = LoadFromXML<List<Contract>>(contractPath);
            List<Contract> contracts = null;
            contracts = list.FindAll(item => item.NannyId == ID || item.MotherId == ID || item.ChildId == ID);
            return contracts;
        }
        #endregion
    }
}