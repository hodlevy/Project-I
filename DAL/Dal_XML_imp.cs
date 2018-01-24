using System;
using System.Collections.Generic;
using System.Linq;
using BE;
using System.IO;
using System.Xml.Serialization;
using System.Xml.Linq;

namespace DAL
{
    public class Dal_XML_imp : Idal
    {
        #region Path Strings + Files
        private readonly string nannyPath = @"nannyXMLFile.xml";
        private readonly string motherPath = @"motherXMLFile.xml";
        private readonly string childPath = @"childXMLFile.xml";
        private readonly string contractPath = @"contractXMLFile.xml";
        private XElement root;
        public void Start(string path, string type)
        {
            if (!File.Exists(path))
                CreateFiles(path, type);
            else
                LoadData();
        }
        private void CreateFiles(string path, string type)
        {
            root = new XElement(type);
            root.Save(path);
        }
        public Dal_XML_imp()
        {
            if (!File.Exists(nannyPath))
                SaveToXML(new List<Nanny>(), nannyPath);
            if (!File.Exists(motherPath))
                SaveToXML(new List<Mother>(), motherPath);
            Start(childPath, "Children");
            if (!File.Exists(contractPath))
                SaveToXML(new List<Contract>(), contractPath);
        }
        #endregion
        #region Nanny
        public void AddNanny(Nanny nanny)
        {
            List<Nanny> nannies = LoadFromXML<List<Nanny>>(nannyPath);
            var nanny2 = (from item in nannies
                         where item.Id == nanny.Id
                         select item).FirstOrDefault();
            if (nanny2 != null)
                throw new Exception("Nanny already exist");
            nannies.Add(nanny);
            SaveToXML(nannies, nannyPath);
        }
        public void DeleteNanny(string ID)
        {
            List<Nanny> nannies = LoadFromXML<List<Nanny>>(nannyPath);
            var nanny = (from item in nannies
                          where item.Id == ID
                          select item).FirstOrDefault();
            if (nanny.Id == null)
                throw new Exception("Nanny doesn't exist");
            nannies.Remove(nanny);
            SaveToXML(nannies, nannyPath);
            // delete the contracts she related to
            List<Contract> contractList = LoadFromXML<List<Contract>>(contractPath);
            var contracts = from item in contractList
                         where item.NannyId == ID
                         select item;
            if (contracts != null)
            {
                foreach (Contract contract in contracts.ToList())
                    contractList.Remove(contract);
                SaveToXML(contractList, contractPath);
            }
        }
        public void UpdateNanny(Nanny nanny)
        {
            List<Nanny> nannies = LoadFromXML<List<Nanny>>(nannyPath);
            var nanny2 = (from item in nannies
                         where item.Id == nanny.Id
                         select item).FirstOrDefault();
            if (nanny2.Id == null)
                throw new Exception("Nanny doesn't exist");
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
            List<Mother> mothers = LoadFromXML<List<Mother>>(motherPath);
            var mother2 = (from item in mothers
                          where item.Id == mother.Id
                          select item).FirstOrDefault();
            if (mother2 != null)
                throw new Exception("Mother already exist");
            mothers.Add(mother);
            SaveToXML(mothers, motherPath);
        }
        public void DeleteMother(string ID)
        {
            List<Mother> mothers = LoadFromXML<List<Mother>>(motherPath);
            var mother = (from item in mothers
                           where item.Id == ID
                           select item).FirstOrDefault();
            if (mother.Id == null)
                throw new Exception("Mother doesn't exist");
            mothers.Remove(mother);
            SaveToXML(mothers, motherPath);
            // delete the contracts she related to
            List<Contract> contractList = LoadFromXML<List<Contract>>(contractPath);
            var contracts = (from item in contractList
                            where item.MotherId == ID
                            select item);
            if (contracts != null)
            {
                foreach (Contract contract in contracts.ToList())
                    contractList.Remove(contract);
                SaveToXML(contractList, contractPath);
            }
        }
        public void UpdateMother(Mother mother)
        {
            List<Mother> mothers = LoadFromXML<List<Mother>>(motherPath);
            var mother2 = (from item in mothers
                           where item.Id == mother.Id
                           select item).FirstOrDefault();
            if (mother2.Id == null)
                throw new Exception("Mother doesn't exist");
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
            List<Child> children = LoadChildListLinq(childPath);
            var child2 = (from item in children
                         where item.Id == child.Id
                         select item).FirstOrDefault();
            if (child2 != null)
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
            List<Child> children = LoadChildListLinq(childPath);
            var child = (from item in children
                          where item.Id == ID
                          select item).FirstOrDefault();
            if (child.Id == null)
                throw new Exception("Child doesn't exist");
            XElement childElement;
            childElement = (from c in root.Elements()
                            where (c.Element("id").Value) == ID
                            select c).First();
            childElement.Remove();
            root.Save(childPath);
            List<Contract> contractList = LoadFromXML<List<Contract>>(contractPath);
            var contracts = from item in contractList
                            where item.ChildId == ID
                            select item;
            if (contracts != null)
            {
                foreach (Contract contract in contracts.ToList())
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
            List<Nanny> nannies = LoadFromXML<List<Nanny>>(nannyPath);
            var nanny = (from item in nannies
                         where item.Id == contract.NannyId
                         select item).FirstOrDefault();
            if (nanny.Id == null)
                throw new Exception("Nanny doesn't exist");
            List<Mother> mothers = LoadFromXML<List<Mother>>(motherPath);
            var mother = (from item in mothers
                          where item.Id == contract.MotherId
                          select item).FirstOrDefault();
            if (mother.Id == null)
                throw new Exception("Mother doesn't exist");
            List<Child> children = LoadChildListLinq(childPath);
            var child = (from item in children
                          where item.Id == contract.ChildId
                          select item).FirstOrDefault();
            int age = DateTime.Now.Month - child.BirthDate.Month + (DateTime.Now.Year - child.BirthDate.Year) * 12;
            if (nanny.MaxAge < age || nanny.MinAge > age)
                throw new Exception("The child's age doesn't meet the conditions of the nanny");
            List<Contract> contracts = LoadFromXML<List<Contract>>(contractPath);
            contracts.Add(contract);
            SaveToXML(contracts, contractPath);
        }
        public void DeleteContract(int number)
        {
            List<Contract> contracts = LoadFromXML<List<Contract>>(contractPath);
            var contract = (from item in contracts
                          where item.Code == number
                          select item).FirstOrDefault();
            if (contract.Code != number)
                throw new Exception("Contract doesn't exist");
            contracts.Remove(contract);
            SaveToXML(contracts, contractPath);
        }
        public void UpdateContract(Contract contract)
        {
            List<Contract> contracts = LoadFromXML<List<Contract>>(contractPath);
            var contract2 = (from item in contracts
                            where item.ChildId == contract.ChildId
                            select item).FirstOrDefault();
            if (contract2.ChildId == null) //
                throw new Exception("Contract doesn't exist");
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
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
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
        Nanny Idal.GetNanny(string nannyID)
        {
            List<Nanny> list = LoadFromXML<List<Nanny>>(nannyPath);
            Nanny nanny = new Nanny();
            List<Nanny> list2 = null;
            list2 = list.FindAll(item => item.Id == nannyID);
            if (list2.Count() != 0)
                nanny = list2[0];
            return nanny;
        }
        Mother Idal.GetMother(string motherID)
        {
            List<Mother> list = LoadFromXML<List<Mother>>(motherPath);
            Mother mother = new Mother();
            List<Mother> list2 = null;
            list2 = list.FindAll(item => item.Id == motherID);
            if (list2.Count() != 0)
                mother = list2[0];
            return mother;
        }
        Child Idal.GetChild(string childID)
        {
            List<Child> list = LoadChildListLinq(childPath);
            Child child = new Child();
            List<Child> list2 = null;
            list2 = list.FindAll(item => item.Id == childID);
            if (list2.Count() != 0)
                child = list2[0];
            return child;
        }
        Contract Idal.GetContract(int number)
        {
            List<Contract> list = LoadFromXML<List<Contract>>(contractPath);
            Contract contract = new Contract();
            List<Contract> list2 = null;
            list2 = list.FindAll(item => item.Code == number);
            if (list2.Count() != 0)
                contract = list2[0];
            return contract;
        }
        Contract Idal.GetContractByID(string ID)
        {
            List<Contract> list = LoadFromXML<List<Contract>>(contractPath);
            List<Contract> contracts = null;
            contracts = list.FindAll(item => item.NannyId == ID || item.MotherId == ID || item.ChildId == ID);
            return contracts[0];
        }
        List<Contract> Idal.GetContractsByID(string ID)
        {
            List<Contract> list = LoadFromXML<List<Contract>>(contractPath);
            List<Contract> contracts = null;
            contracts = list.FindAll(item => item.NannyId == ID || item.MotherId == ID || item.ChildId == ID);
            return contracts;
        }
        #endregion
    }
}