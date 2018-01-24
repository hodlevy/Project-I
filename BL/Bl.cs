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
        // the DAL element
        Idal MyDal;
        /// <summary>
        /// default constructor for BL layer
        /// </summary>
        public Bl()
        {
            MyDal = Dal.GetDal();
            //initialization();
        }
        /// <summary>
        /// initialization with 8 elements for the start
        /// </summary>
        void initialization()
        {
            Nanny Ayala_Zehavi = new Nanny
            ("123456782", "Ayala", "Zehavi", new DateTime(1980, 5, 19), "Beit Ha-Defus St 21, Jerusalem", "0508455477", true, 3, 4, 15, 4, 28, true, 30, 5000, true, "", new bool[] { true, true, true, true, true, false },
                new TimeSpan[,]
                {
                    {TimeSpan.FromHours(7.5),TimeSpan.FromHours(15.5) }, {TimeSpan.FromHours(8),TimeSpan.FromHours(15.75) },{TimeSpan.FromHours(9),TimeSpan.FromHours(12) },{TimeSpan.FromHours(7.5),TimeSpan.FromHours(15.5) },{TimeSpan.FromHours(7),TimeSpan.FromHours(16.25) },{TimeSpan.FromHours(0),TimeSpan.FromHours(0) },
                }
                );
            Nanny Moria_Schneider = new Nanny
            ("258746916", "Moria", "Schneider", new DateTime(1992, 4, 9), "Shakhal St 15, Jerusalem", "0523433333", true, 2, 3, 14, 3, 36, true, 30, 5000, false, "", new bool[] { true, true, true, true, true, false },
                new TimeSpan[,]
                {
                    {TimeSpan.FromHours(7),TimeSpan.FromHours(15.5) }, {TimeSpan.FromHours(7),TimeSpan.FromHours(15) },{TimeSpan.FromHours(7),TimeSpan.FromHours(12) },{TimeSpan.FromHours(7),TimeSpan.FromHours(15.5) },{TimeSpan.FromHours(7),TimeSpan.FromHours(16.25) },{TimeSpan.FromHours(0),TimeSpan.FromHours(0) },
                }
                );
            MyDal.AddNanny(Ayala_Zehavi);
            MyDal.AddNanny(Moria_Schneider);
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
            MyDal.AddMother(Ayelt_Shaked);
            MyDal.AddMother(Gilat_Bennet);
            Child Elad = new Child("322690124", "113542872", "Elad", new DateTime(2016, 6, 20), true, "Is STUPID");
            Child Dror = new Child("302302039", "111112223", "Dror", new DateTime(2015, 1, 1), false, "");
            MyDal.AddChild(Elad);
            MyDal.AddChild(Dror);
            Contract contract1 = new Contract("322690124", "123456782", "113542872", true, true, 30, 5000, true, new DateTime(2017, 6, 20), new DateTime(2017, 12, 20));
            Contract contract2 = new Contract("302302039", "258746916", "111112223", true, true, 27, 4800, false, new DateTime(2015, 6, 1), new DateTime(2017, 12, 20));
            contract1.Salary = MonthlyPayment(contract1);
            MyDal.AddContract(contract1);
            contract2.Salary = MonthlyPayment(contract2);
            MyDal.AddContract(contract2);
        }
        #region Nanny
        /// <summary>
        /// add nanny
        /// </summary>
        /// <param name="nanny"></param>
        void IBL.AddNanny(Nanny nanny)
        {
            // if the nanny is younger than 18
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
            for (int i = 0; i < 6; i++)
            {
                if (nanny.WorkHours[i, 0] > nanny.WorkHours[i, 1])
                    throw new Exception("Time isn't make sense!!!");
            }
            if (nanny.MaxAge < nanny.MinAge)
                throw new Exception("Min/Max age doesn't make sense!");
            MyDal.AddNanny(nanny);
        }
        /// <summary>
        /// delete nanny
        /// </summary>
        /// <param name="ID"></param>
        void IBL.DeleteNanny(string ID)
        {
            MyDal.DeleteNanny(ID);
        }
        /// <summary>
        /// update nanny
        /// </summary>
        /// <param name="nanny"></param>
        void IBL.UpdateNanny(Nanny nanny)
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
            for (int i = 0; i < 6; i++)
            {
                if (nanny.WorkHours[i, 0] > nanny.WorkHours[i, 1])
                    throw new Exception("Time isn't make sense!!!");
            }
            if (nanny.MaxAge < nanny.MinAge)
                throw new Exception("Min/Max age doesn't make sense!");
            MyDal.UpdateNanny(nanny);
        }
        #endregion
        #region Mother
        /// <summary>
        /// add mother
        /// </summary>
        /// <param name="mother"></param>
        void IBL.AddMother(Mother mother)
        {
            for (int i = 0; i < 6; i++)
            {
                if (mother.NeedsNannyHours[i, 0] > mother.NeedsNannyHours[i, 1])
                    throw new Exception("Time isn't make sense!!!");
            }
            MyDal.AddMother(mother);
        }
        /// <summary>
        /// delete mother
        /// </summary>
        /// <param name="ID"></param>
        void IBL.DeleteMother(string ID)
        {
            MyDal.DeleteMother(ID);
        }
        /// <summary>
        /// update mother
        /// </summary>
        /// <param name="mother"></param>
        void IBL.UpdateMother(Mother mother)
        {
            for (int i = 0; i < 6; i++)
            {
                if (mother.NeedsNannyHours[i, 0] > mother.NeedsNannyHours[i, 1])
                    throw new Exception("Time isn't make sense!!!");
            }
            MyDal.UpdateMother(mother);
        }
        #endregion
        #region Child
        /// <summary>
        /// add child
        /// </summary>
        /// <param name="child"></param>
        void IBL.AddChild(Child child)
        {
            // if the child hasn't born yet
            if (DateTime.Now < child.BirthDate)
                throw new Exception("The child hasn't born yet!");
            // if the child is younger than 3 monthes
            int month = DateTime.Now.Month - child.BirthDate.Month;
            int year = DateTime.Now.Year - child.BirthDate.Year;
            if (month >= 3 || year > 0)
                MyDal.AddChild(child);
            else
                throw new Exception("The child is too young!");
        }
        /// <summary>
        /// delete child
        /// </summary>
        /// <param name="ID"></param>
        void IBL.DeleteChild(string ID)
        {
            MyDal.DeleteChild(ID);
        }
        /// <summary>
        /// update child
        /// </summary>
        /// <param name="child"></param>
        void IBL.UpdateChild(Child child)
        {
            // if the child hasn't born yet
            if (DateTime.Now < child.BirthDate)
                throw new Exception("The child hasn't born yet!");
            // if the child is younger than 3 monthes
            int month = DateTime.Now.Month - child.BirthDate.Month;
            int year = DateTime.Now.Year - child.BirthDate.Year;
            if (month >= 3 || year > 0)
                MyDal.UpdateChild(child);
            else
                throw new Exception("The child is too young!");
        }
        #endregion
        #region Contract
        /// <summary>
        /// add contract
        /// </summary>
        /// <param name="contract"></param>
        void IBL.AddContract(Contract contract)
        {
            // if it is the max amount of children for nanny
            Nanny nanny = GetNanny(contract.NannyId);
            List<Contract> list = MyDal.AllContracts().FindAll(item => item.NannyId == nanny.Id);
            if (list.Count() == nanny.MaxChildren)
                throw new Exception("This is the maximum number of children!");
            // if the contract already exist (the cild  already has a contract)
            Child child = GetChild(contract.ChildId);
            bool flag = true;
            foreach (Contract contract2 in MyDal.AllContracts())
            {
                if (child.Id == contract2.ChildId)
                    flag = false;
            }
            if (!flag)
                throw new Exception("Contract already exist");
            // if the begin date is after the end date
            if (contract.EndDate < contract.BeginDate)
                throw new Exception("the contract ends before it begins");
            // discount calculate
            Mother mother = GetMother(contract.MotherId);
            list = MyDal.AllContracts().FindAll(item => item.NannyId == nanny.Id && item.MotherId == mother.Id);
            double discount = 0;
            if (list.Count() != 0)
                discount = (list.Count()) * 0.02;
            contract.Salary = MonthlyPayment(contract) * (1 - discount);
            MyDal.AddContract(contract);
        }
        /// <summary>
        /// delete contract
        /// </summary>
        /// <param name="number"></param>
        void IBL.DeleteContract(int number)
        {
            MyDal.DeleteContract(number);
        }
        /// <summary>
        /// update contract
        /// </summary>
        /// <param name="contract"></param>
        void IBL.UpdateContract(Contract contract)
        {
            // discount calculate
            if (contract.EndDate < contract.BeginDate)
                throw new Exception("the contract ends before it begins");
            Nanny nanny = GetNanny(contract.NannyId);
            List<Contract> list = MyDal.AllContracts().FindAll(item => item.NannyId == nanny.Id);
            Mother mother = GetMother(contract.MotherId);
            list = MyDal.AllContracts().FindAll(item => item.NannyId == nanny.Id && item.MotherId == mother.Id);
            double discount = 0;
            if (list.Count() != 0)
                discount = (list.Count() - 1) * 0.02;
            contract.Salary = MonthlyPayment(contract) * (1 - discount);
            MyDal.UpdateContract(contract);
        }
        #endregion
        #region Lists
        /// <summary>
        /// return the nanny's list
        /// </summary>
        /// <returns>nanny's list</returns>
        List<Nanny> IBL.AllNannys()
        {
            return MyDal.AllNannys();
        }
        /// <summary>
        /// return the mother's list
        /// </summary>
        /// <returns>mother's list</returns>
        List<Mother> IBL.AllMothers()
        {
            return MyDal.AllMothers();
        }
        /// <summary>
        /// return the child's list
        /// </summary>
        /// <returns>child's list</returns>
        List<Child> IBL.AllChildren()
        {
            return MyDal.AllChildren();
        }
        /// <summary>
        /// return the contract's list
        /// </summary>
        /// <returns>contract's list</returns>
        List<Contract> IBL.AllContracts()
        {
            return MyDal.AllContracts();
        }
        #endregion
        /// <summary>
        /// google maps function for calculate distances
        /// </summary>
        /// <param name="source"></param>
        /// <param name="dest"></param>
        /// <returns>distance</returns>
        public static int CalculateDistance(string source, string dest)
        {
            var drivingDirectionRequest = new GoogleMapsApi.Entities.Directions.Request.DirectionsRequest
            {
                TravelMode = GoogleMapsApi.Entities.Directions.Request.TravelMode.Walking,
                Origin = source,
                Destination = dest,
            };
            GoogleMapsApi.Entities.Directions.Response.DirectionsResponse drivingDirections = GoogleMaps.Directions.Query(drivingDirectionRequest); ////////////////////////////////
            GoogleMapsApi.Entities.Directions.Response.Route route = drivingDirections.Routes.First();
            GoogleMapsApi.Entities.Directions.Response.Leg leg = route.Legs.First();
            return leg.Distance.Value;
        }
        /// <summary>
        /// returns all the nannies who worked according to the TMT vacations
        /// </summary>
        /// <returns>list</returns>
        List<Nanny> IBL.VacationCheck_AllNanny()
        {
            List<Nanny> list = MyDal.AllNannys().FindAll(x => x.VacationCheck == true);
            return list;
        }
        /// <summary>
        /// Returns the nannies who fitting to the mother request. 
        /// If there is no nanny who fitting the function calculates the best 5 nannies for the mother by few arguments:
        /// overlapping days and hours.
        /// </summary>
        /// <param name="mother"></param>
        /// <returns>list</returns>
        List<Nanny> IBL.PotentiallyNannies(string motherID)
        {
            Mother mother = GetMother(motherID);
            List<Nanny> nannies = new List<Nanny>();
            bool flag;
            foreach (Nanny nanny in MyDal.AllNannys())
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
                int[] preferness = new int[MyDal.AllNannys().Count()];
                int days;
                for (int i = 0; i < MyDal.AllNannys().Count(); i++)
                {
                    preferness[i] = 0;
                    days = 0;
                    for (int j = 0; j < 6; j++)
                    {
                        if (mother.NeedsNanny[j] && MyDal.AllNannys()[i].IsWorking[j])
                        {
                            days++;
                            if ((MyDal.AllNannys()[i].WorkHours[j, 0] <= mother.NeedsNannyHours[j, 0] && MyDal.AllNannys()[i].WorkHours[j, 1] >= mother.NeedsNannyHours[j, 1]))
                                preferness[i] += 2;
                        }
                    }
                    preferness[i] += days;
                    //preferness[i] -= CalculateDistance(mother.SearchingArea, MyDal.AllNannys()[i].Address) / 10;
                }
                int max;
                for (int i = 0; i < 5 && i < MyDal.AllNannys().Count(); i++)
                {
                    max = 0;
                    for (int j = 0; j < MyDal.AllNannys().Count(); j++)
                    {
                        if (max < preferness[j])
                            max = preferness[j];
                    }
                    for (int j = 0; j < MyDal.AllNannys().Count(); j++)
                    {
                        if (preferness[j] == max)
                        {
                            nannies.Add(MyDal.AllNannys()[j]);
                            preferness[j] = 0;
                        }
                    }
                }
            }
            return nannies;
        }
        /// <summary>
        /// return all the children without nanny
        /// </summary>
        /// <returns>list</returns>
        List<Child> IBL.LonleyChildren()
        {
            List<Child> children = new List<Child>();
            bool flag;
            foreach (Child child in MyDal.AllChildren())
            {
                flag = false;
                foreach (Contract contract in MyDal.AllContracts())
                {
                    if (child.Id == contract.ChildId)
                        flag = true;
                }
                if (!flag)
                    children.Add(child);
            }
            return children;
        }
        /// <summary>
        /// Get nanny by Id number
        /// </summary>
        /// <param name="nannyID"></param>
        /// <returns>nanny</returns>
        Nanny GetNanny(string nannyID)
        {
            Nanny nanny = MyDal.GetNanny(nannyID);
            return nanny;
        }
        /// <summary>
        /// Get mother by Id number
        /// </summary>
        /// <param name="motherID"></param>
        /// <returns>mother</returns>
        Mother GetMother(string motherID)
        {
            Mother mother = MyDal.GetMother(motherID);
            return mother;
        }
        /// <summary>
        /// Get child by Id number
        /// </summary>
        /// <param name="childID"></param>
        /// <returns>child</returns>
        Child GetChild(string childID)
        {
            Child child = MyDal.GetChild(childID);
            return child;
        }
        /// <summary>
        /// Group all nannies according to the age of the child (by monthes)
        /// </summary>
        /// <param name="ifMinMax"></param>
        /// <param name="isSorted"></param>
        /// <returns>group list</returns>
        IEnumerable<IGrouping<int, Nanny>> IBL.GroupNanny(bool ifMinMax, bool isSorted = false)
        {
            List<Nanny> list = MyDal.AllNannys();
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
        /// <summary>
        /// Calculates the distance between the nanny and the mother's searching area
        /// </summary>
        /// <param name="contract"></param>
        /// <returns>the distance between the nanny and the mother's searching area</returns>
        public int DistanceByContract(Contract contract)
        {
            int distance;
            bool validId = false;
            string motherAddres = "";
            string nannyAddres = "";
            foreach (Mother mo in MyDal.AllMothers())
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
            foreach (Nanny na in MyDal.AllNannys())
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
        /// <summary>
        /// Group contracts by distance between nanny and mother
        /// </summary>
        /// <param name="sorted"></param>
        /// <returns>group list</returns>
        IEnumerable<IGrouping<int, Contract>> IBL.ContractByDistance(bool sorted = false)
        {
            IEnumerable<IGrouping<int, Contract>> results;

            if (sorted)
                results = from Contract c in MyDal.AllContracts()
                          orderby c
                          group c by DistanceByContract(c) / 5;
            else
                results = from Contract c in MyDal.AllContracts()
                          group c by DistanceByContract(c) / 5;
            return results;
        }
        /// <summary>
        /// calculate the monthly payment
        /// </summary>
        /// <param name="contract"></param>
        /// <returns>salary</returns>
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
        /// <summary>
        /// calculates the sum of the hours that fit to the mother and to the nanny on specific day
        /// </summary>
        /// <param name="nanny"></param>
        /// <param name="mother"></param>
        /// <param name="day"></param>
        /// <returns>nanny's work hours at specific day for specific mother</returns>
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
        /// <summary>
        /// returns all the contract by some function
        /// </summary>
        /// <param name="condition"></param>
        /// <returns>list</returns>
        List<Contract> ContractCondition(Func<Contract, bool> condition)
        {
            List<Contract> contracts = MyDal.AllContracts().FindAll(item => condition(item));
            return contracts;
        }
        /// <summary>
        /// returns all the contracts's numbers by some function
        /// </summary>
        /// <param name="condition"></param>
        /// <returns>list</returns>
        List<int> NumberContractCondition(Func<Contract, bool> condition)
        {
            List<Contract> list = ContractCondition(condition);
            List<int> numbers = null;
            foreach (Contract contract in list)
                numbers.Add(contract.Number);
            return numbers;
        }

        void IBL.Reset()
        {
            MyDal.Reset();
        }
    }
}
