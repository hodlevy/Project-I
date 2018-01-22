using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.IO;
using System.Xml.Serialization;
using System.Xml.Linq;

namespace DAL
{
    public class Dal_XML_imp : Idal
    {
        private XElement root;
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
            SaveToXML(mothers, motherPath);
        }
        public void DeleteMother(string ID)
        {
            Mother mother = GetMother(ID);
            if (mother.Id == null)
                throw new Exception("Mother doesn't exist");
            List<Mother> mothers = LoadFromXML<List<Mother>>(motherPath);
            mothers.Remove(mother);
            SaveToXML(mothers, motherPath);
            // delete the contracts she related to
            List<Contract> contractList = LoadFromXML<List<Contract>>(contractPath);
            List<Contract> contracts = GetContractsByID(mother.Id);
            if (contracts != null)
            {
                foreach (Contract contract in contracts)
                    contractList.Remove(contract);
                SaveToXML(contractList, motherPath);
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
            SaveToXML(mothers, motherPath);
        }
        public List<Mother> AllMothers()
        {
            List<Mother> mothers = LoadFromXML<List<Mother>>(motherPath);
            return mothers;
        }
        #endregion
        #region Child
        public void SaveChildListLinq(List<Child> childList)
        {
            root = new XElement("children",
                                    from p in childList
                                    select new XElement("child",
                                        new XElement("id", p.Id),
                                        new XElement("motherId", p.MotherId),
                                        new XElement("firstName", p.FirstName),
                                        new XElement("birthDate", p.BirthDate),
                                        new XElement("isSpecialNeeds", p.IsSpecialNeeds),
                                        new XElement("specialNeeds", p.SpecialNeeds)
                                            ));
            root.Save(childPath);
        }
        private void LoadData()
        {
            try
            {
                root = XElement.Load(childPath);
            }
            catch
            {
                throw new Exception("File upload problem");
            }
        }
        public List<Child> LoadChildListLinq(string childFile)
        {
            LoadData();
            List<Child> children;
            try
            {
                children = (from c in root.Elements()
                            select new Child()
                            {
                                Id = c.Element("id").Value,
                                MotherId = c.Element("motherId").Value,
                                FirstName = c.Element("firstName").Value,
                                BirthDate = DateTime.Parse(c.Element("birthDate").Value),
                                IsSpecialNeeds = bool.Parse(c.Element("isSpecialNeeds").Value),
                                SpecialNeeds = c.Element("specialNeeds").Value
                            }).ToList();
            }
            catch
            {
                children = null;
            }
            return children;
        }
        public void AddChild(Child child)
        {

            Child child2 = GetChild(child.Id);
            if (child2.Id != null)
                throw new Exception("Child already exist");
            root.Add(new XElement("child",
            new XElement("id", child.Id),
            new XElement("motherId", child.MotherId),
            new XElement("firstName", child.FirstName),
            new XElement("birthDate", child.BirthDate),
            new XElement("isSpecialNeeds", child.IsSpecialNeeds),
            new XElement("specialNeeds", child.SpecialNeeds)
                            ));
            root.Save(childPath);
        }
        public void DeleteChild(string ID)
        {
            Child child = GetChild(ID);
            if (child.Id == null)
                throw new Exception("Child doesn't exist");
            XElement childElement;
            childElement = (from c in root.Elements()
                            where (c.Element("id").Value) == ID
                            select c).First();
            childElement.Remove();
            root.Save(childPath);
            List<Contract> contractList = LoadFromXML<List<Contract>>(contractPath);
            List<Contract> contracts = GetContractsByID(child.Id);
            if (contracts != null)
            {
                foreach (Contract contract in contracts)
                    contractList.Remove(contract);
                SaveToXML(contractList, contractPath);
            }
        }
        public void UpdateChild(Child child)
        {
            XElement childElement = (from c in root.Elements()
                                       where (c.Element("id").Value) == child.Id
                                       select c).FirstOrDefault();

            childElement.Element("firstName").Value = child.FirstName;
            childElement.Element("birthDate").Value = (child.BirthDate).ToShortDateString();
            childElement.Element("isSpecialNeeds").Value = child.IsSpecialNeeds.ToString();
            childElement.Element("specialNeeds").Value = child.SpecialNeeds;

            root.Save(childPath);
        }
        public List<Child> AllChildren()
        {
            List<Child> children = LoadChildListLinq(childPath);
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
            List<Child> list = LoadChildListLinq(childPath);
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