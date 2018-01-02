using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;
using GoogleMapsApi;

namespace BL
{
    public class Bl : IBL
    {
        Idal MyDal;
        public Bl()
        {
            MyDal = Dal.GetDal();
            initialization();
        }
        void initialization()
        {
            Nanny Ayala_Zehavi = new Nanny
            ("123456782", "Ayala", "zehavi", new DateTime(1980, 5, 19), "Beit Ha-Defus St 21, Jerusalem", "0523433333", true, 2, 3, 14, 3, 8, true, 30, 5000, false, "", new bool[] { true, true, true, true, true, false },
                new TimeSpan[,]
                {
                    {TimeSpan.FromHours(7.5),TimeSpan.FromHours(15.5) }, {TimeSpan.FromHours(8),TimeSpan.FromHours(15.75) },{TimeSpan.FromHours(9),TimeSpan.FromHours(12) },{TimeSpan.FromHours(7.5),TimeSpan.FromHours(15.5) },{TimeSpan.FromHours(7),TimeSpan.FromHours(16.25) },{TimeSpan.FromHours(0),TimeSpan.FromHours(0) },
                }
                );
            Nanny Moria_Schneider = new Nanny
            ("258746916", "Moria", "Schneider", new DateTime(1992, 4, 9), "Shakhal St 15, Jerusalem", "0523433333", true, 2, 3, 14, 3, 8, true, 30, 5000, false, "", new bool[] { true, true, true, true, true, false },
                new TimeSpan[,]
                {
                    {TimeSpan.FromHours(7),TimeSpan.FromHours(15.5) }, {TimeSpan.FromHours(7),TimeSpan.FromHours(15) },{TimeSpan.FromHours(7),TimeSpan.FromHours(12) },{TimeSpan.FromHours(7),TimeSpan.FromHours(15.5) },{TimeSpan.FromHours(7),TimeSpan.FromHours(16.25) },{TimeSpan.FromHours(0),TimeSpan.FromHours(0) },
                }
                );
            DataSource.listNanny.Add(Ayala_Zehavi);
            DataSource.listNanny.Add(Moria_Schneider);
            Mother Ayelt_Shaked = new Mother
            ("113542872", "Ayelt", "Shaked", "0521234566", "Shakhal St 23,Jerusalem", "Shakhal St 23,Jerusalem", new bool[] { true, true, true, true, true, false },
               new TimeSpan[,]
                {
                    {TimeSpan.FromHours(7),TimeSpan.FromHours(15.5) }, {TimeSpan.FromHours(7),TimeSpan.FromHours(15) },{TimeSpan.FromHours(7),TimeSpan.FromHours(12) },{TimeSpan.FromHours(7),TimeSpan.FromHours(15.5) },{TimeSpan.FromHours(7),TimeSpan.FromHours(16.25) },{TimeSpan.FromHours(0),TimeSpan.FromHours(0) },
                }, "");
            Mother Gilat_Bennet = new Mother
           ("111112223", "Gilat", "Bennet", "0541485421", "HaMem Gimel St 4, Jerusalem", "HaMem Gimel St 4, Jerusalem", new bool[] { false, true, true, true, true, false },
              new TimeSpan[,]
               {
                    {TimeSpan.FromHours(0),TimeSpan.FromHours(0) }, {TimeSpan.FromHours(8),TimeSpan.FromHours(12) },{TimeSpan.FromHours(8),TimeSpan.FromHours(12) },{TimeSpan.FromHours(8),TimeSpan.FromHours(12) },{TimeSpan.FromHours(8),TimeSpan.FromHours(12) },{TimeSpan.FromHours(0),TimeSpan.FromHours(0) },
               }, "");
            DataSource.listMother.Add(Ayelt_Shaked);
            DataSource.listMother.Add(Gilat_Bennet);
            Child Elad = new Child("322690124", "113542872", "Elad", new DateTime(2016, 6, 20), true, "Is STUPID");
            Child Dror = new Child("302302039", "111112223", "Dror", new DateTime(2015, 1, 1), false, "");
            DataSource.listChild.Add(Elad);
            DataSource.listChild.Add(Dror);
            Contract contract1 = new Contract("322690124", "123456782", "113542872", true, true, 30, 5000, true, new DateTime(2017, 6, 20), new DateTime(2017, 12, 20));
            Contract contract2 = new Contract("302302039", "258746916", "111112223", true, true, 27, 4800, false, new DateTime(2015, 6, 1), new DateTime(2017, 12, 20));
            contract1.Salary = MonthlyPayment(contract1);
            DataSource.listContract.Add(contract1);
            contract2.Salary = MonthlyPayment(contract2);
            DataSource.listContract.Add(contract2);
        }
        #region Nanny
        void IBL.AddNanny(Nanny nanny)
        {
            int nannyAge = DateTime.Now.Year - nanny.BirthDate.Year;
            if (nannyAge == 18)
            {
                int monthes = DateTime.Now.Month - nanny.BirthDate.Month;
                if (monthes < 0)
                    throw new Exception("Nanny is too young!");
                if (monthes == 0)
                {
                    int days = DateTime.Now.Day - nanny.BirthDate.Day;
                    if (days < 0)
                        throw new Exception("Nanny is too young!");
                }
            }
            if (nannyAge < 18)
                throw new Exception("Nanny is too young!");
            MyDal.AddNanny(nanny);
        }
        void IBL.DeleteNanny(string ID)
        {
            MyDal.DeleteNanny(ID);
        }
        void IBL.UpdateNanny(Nanny nanny)
        {
            MyDal.UpdateNanny(nanny);
        }
        #endregion
        #region Mother
        void IBL.AddMother(Mother mother)
        {
            MyDal.AddMother(mother);
        }
        void IBL.DeleteMother(string ID)
        {
            MyDal.DeleteMother(ID);
        }
        void IBL.UpdateMother(Mother mother)
        {
            MyDal.UpdateMother(mother);
        }
        #endregion
        #region Child
        void IBL.AddChild(Child child)
        {
            int month = DateTime.Now.Month - child.BirthDate.Month;
            int year = DateTime.Now.Year - child.BirthDate.Year;
            if (month >= 3 || year > 0)
                MyDal.AddChild(child);
            else
                throw new Exception("The child is too young!");
        }
        void IBL.DeleteChild(string ID)
        {
            MyDal.DeleteChild(ID);
        }
        void IBL.UpdateChild(Child child)
        {
            MyDal.UpdateChild(child);
        }
        #endregion
        #region Contract
        void IBL.AddContract(Contract contract)
        {
            Nanny nanny = GetNanny(contract.NannyId);
            List<Contract> list = DataSource.listContract.FindAll(item => item.NannyId == nanny.Id);
            if (list.Count() == nanny.MaxChildren)
                throw new Exception("This is the maximum number of children!");
            //Child child = GetChild(contract.ChildId);
            //list = DataSource.listContract.FindAll(item => item.NannyId == nanny.Id && item.ChildId == child.Id);
            //if (list != null)
            //    throw new Exception("There is already contract which the nanny take care of this child");
            Mother mother = GetMother(contract.MotherId);
            list = DataSource.listContract.FindAll(item => item.NannyId == nanny.Id && item.MotherId == mother.Id);
            double discount = 0;
            if (list.Count() != 0)
                discount = (list.Count() - 1) * 0.02;
            contract.Salary = MonthlyPayment(contract) * (1 - discount);

            MyDal.AddContract(contract);
        }
        void IBL.DeleteContract(int number)
        {
            MyDal.DeleteContract(number);
        }
        void IBL.UpdateContract(Contract contract)
        {
            MyDal.UpdateContract(contract);
        }
        #endregion
        #region Lists
        List<Nanny> IBL.AllNannys()
        {
            return DataSource.listNanny;
        }
        List<Mother> IBL.AllMothers()
        {
            return DataSource.listMother;
        }
        List<Child> IBL.AllChildren()
        {
            return DataSource.listChild;
        }
        List<Contract> IBL.AllContracts()
        {
            return DataSource.listContract;
        }
        #endregion
        public static int CalculateDistance(string source, string dest)
        {
            var drivingDirectionRequest = new GoogleMapsApi.Entities.Directions.Request.DirectionsRequest
            {
                TravelMode = GoogleMapsApi.Entities.Directions.Request.TravelMode.Walking,
                Origin = source,
                Destination = dest,
            };
            GoogleMapsApi.Entities.Directions.Response.DirectionsResponse drivingDirections = GoogleMaps.Directions.Query(drivingDirectionRequest);
            GoogleMapsApi.Entities.Directions.Response.Route route = drivingDirections.Routes.First();
            GoogleMapsApi.Entities.Directions.Response.Leg leg = route.Legs.First();
            return leg.Distance.Value;
        }
        List<Nanny> VacationCheck_AllNanny()
        {
            List<Nanny> list = DataSource.listNanny.FindAll(x => x.VacationCheck == true);
            return list;
        }
        List<Nanny> IBL.PotentiallyNannies(Mother mother)
        {
            List<Nanny> nannies = new List<Nanny>();
            bool flag;
            foreach (Nanny nanny in DataSource.listNanny)
            {
                flag = true;
                for (int i = 0; i < 6; i++)
                {
                    if (!nanny.IsWorking[i] && mother.NeedsNanny[i])
                        flag = false;
                    else if (nanny.WorkHours[i, 0] >= mother.NeedsNannyHours[i, 0] || nanny.WorkHours[i, 1] <= mother.NeedsNannyHours[i, 1])
                        flag = false;
                }
                if (flag)
                    nannies.Add(nanny);
            }
            if (nannies.Count() == 0)
            {
                int[] preferness = new int[DataSource.listNanny.Count()];
                int days;
                for (int i = 0; i < DataSource.listNanny.Count(); i++)
                {
                    preferness[i] = 0;
                    days = 0;
                    for (int j = 0; j < 6; j++)
                    {
                        if (mother.NeedsNanny[j] && DataSource.listNanny[i].IsWorking[j])
                        {
                            days++;
                            if ((DataSource.listNanny[i].WorkHours[i, 0] >= mother.NeedsNannyHours[i, 0] || DataSource.listNanny[i].WorkHours[i, 1] <= mother.NeedsNannyHours[i, 1]))
                                preferness[i] += 2;
                        }
                    }
                    preferness[i]+=days;
                }
                int max;
                for (int i = 0; i < 5 && i < DataSource.listNanny.Count(); i++)
                {
                    max = 0;
                    for (int j = 0; j < DataSource.listNanny.Count(); j++)
                    {
                        if (max < preferness[j])
                            max = preferness[j];
                    }
                    for (int j = 0; j < DataSource.listNanny.Count(); j++)
                    {
                        if (preferness[j] == max)
                            nannies.Add(DataSource.listNanny[j]);
                        preferness[j] = 0;
                    }
                }
            }
            return nannies;
        }
        List<Child> IBL.LonleyChildren()
        {
            List<Child> children = new List<Child>();
            bool flag;
            foreach (Child child in DataSource.listChild)
            {
                flag = false;
                foreach (Contract contract in DataSource.listContract)
                {
                    if (child.Id == contract.ChildId)
                        flag = true;
                }
                if (!flag)
                    children.Add(child);
            }
            return children;
        }
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
        IEnumerable<IGrouping<int, Nanny>> GroupNanny(bool ifMinMax, bool isSorted = false)
        {
            List<Nanny> list = DataSource.listNanny;
            if (isSorted)
            {
                list.Sort();
            }
            IEnumerable<IGrouping<int, Nanny>> result;
            if (ifMinMax)
            {
                result = from nanny in list
                         group nanny by nanny.MaxAge;

            }
            else
            {
                result = from nanny in list
                         group nanny by nanny.MinAge;
            }
            return result;
        }
        public int DistanceByContract(BE.Contract contract)
        {
            int distance;
            bool validId = false;
            string motherAddres = "";
            string nannyAddres = "";
            foreach (Mother mo in DataSource.listMother)
            {
                if (mo.Id == contract.MotherId)
                {
                    motherAddres = mo.SearchingArea;
                    validId = true;
                    break;
                }
            }
            if (!validId)
                throw new Exception("invalid ID");
            validId = false;
            foreach (Nanny na in DataSource.listNanny)
            {
                if (na.Id == contract.NannyId)
                {
                    nannyAddres = na.Address;
                    validId = true;
                    break;
                }
            }
            if (!validId)
                throw new Exception("invalid ID");
            distance = CalculateDistance(nannyAddres, motherAddres);
            return distance;
        }
        public IEnumerable<IGrouping<int, Contract>> ContractByDistance(bool sorted)
        {
            IEnumerable<IGrouping<int, Contract>> results;

            if (sorted)
                results = from Contract c in DataSource.listContract
                          orderby c
                          group c by DistanceByContract(c) / 5;
            else
                results = from Contract c in DataSource.listContract
                          group c by DistanceByContract(c) / 5;
            return results;
        }
        public double MonthlyPayment(Contract contract)
        {
            if (contract.PerWhat)
                return contract.PayForMonth;
            double weeklyHours = 0;
            Nanny nanny = GetNanny(contract.NannyId);
            Mother mother = GetMother(contract.MotherId);
            for (int i = 0; i < 6; i++)
            {
                weeklyHours += DailyWork(nanny, mother, i);
            }
            return 4 * contract.PayForHour * weeklyHours;
        }
        double DailyWork(Nanny nanny, Mother mother, int day)
        {
            double begin = 0, end = 0;
            if (nanny.IsWorking[day] && mother.NeedsNanny[day])
            {
                if (nanny.WorkHours[day, 0] > mother.NeedsNannyHours[day, 0])
                {
                    begin = nanny.WorkHours[day, 0].Hours;
                    begin += nanny.WorkHours[day, 0].Minutes / 60;
                }
                else
                {
                    begin = mother.NeedsNannyHours[day, 0].Hours;
                    begin += mother.NeedsNannyHours[day, 0].Minutes / 60;
                }
                if (nanny.WorkHours[day, 1] > mother.NeedsNannyHours[day, 1])
                {
                    end = mother.NeedsNannyHours[day, 1].Hours;
                    end += mother.NeedsNannyHours[day, 1].Minutes / 60;
                }
                else
                {
                    end = nanny.WorkHours[day, 1].Hours;
                    end += nanny.WorkHours[day, 1].Minutes / 60;
                }
            }
            return end - begin;
        }
        List<Contract> ContractCondition(Func<Contract, bool> condition)
        {
            List<Contract> contracts = DataSource.listContract.FindAll(item => condition(item));
            return contracts;
        }
        List<int> NumberContractCondition(Func<Contract, bool> condition)
        {
            List<Contract> list = ContractCondition(condition);
            List<int> numbers = null;
            foreach (Contract contract in list)
                numbers.Add(contract.Number);
            return numbers;
        }
    }
}
