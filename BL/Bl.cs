using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;
//using GoogleMapsApi;

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

            //כאן נאתחל כמה מופעים להרצה הראשונה
        }
        #region Nanny
        void AddNanny(Nanny nanny)
        {
            int nannyAge = DateTime.Now.Year - nanny.BirthDate.Year;
            if (nannyAge < 18)
                throw new Exception("Nanny is too young!");
            MyDal.AddNanny(nanny);
        }
        void DeleteNanny(Nanny nanny)
        {
            MyDal.DeleteNanny(nanny);
        }
        void UpdateNanny(Nanny nanny)
        {
            MyDal.UpdateNanny(nanny);
        }
        #endregion
        #region Mother
        void AddMother(Mother mother)
        {
            MyDal.AddMother(mother);
        }
        void DeleteMother(Mother mother)
        {
            MyDal.DeleteMother(mother);
        }
        void UpdateMother(Mother mother)
        {
            MyDal.UpdateMother(mother);
        }
        #endregion
        #region Child
        void AddChild(Child child)
        {
            int month = DateTime.Now.Month - child.BirthDate.Month;
            int year = DateTime.Now.Year - child.BirthDate.Year;
            if (month >= 3 || year > 0)
                MyDal.AddChild(child);
            else
                throw new Exception("The child is too young!");
        }
        void DeleteChild(Child child)
        {
            MyDal.DeleteChild(child);
        }
        void UpdateChild(Child child)
        {
            MyDal.UpdateChild(child);
        }
        #endregion
        #region Contract
        void AddContract(Contract contract)
        {
            int children = 0;
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

            foreach (Contract contr in DataSource.listContract)
            {
                if (id == contr.NannyId)
                    children++;
            }
            foreach (Nanny nan in DataSource.listNanny)
            {
                if (nan.Id == id)
                    if (children > nan.MaxChildren)
                        throw new Exception("The nanny has no place for the child");
            }
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
            MyDal.DeleteContract(contract);
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
        #endregion
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
    //public static int CalculateDistance(string source, string dest)
    //{
    //    var drivingDirectionRequest = new GoogleMapsApi.Entities.Directions.Request.DirectionsRequest
    //    {
    //        TravelMode = GoogleMapsApi.Entities.Directions.Request.TravelMode.Walking,
    //        Origin = source,
    //        Destination = dest,
    //    };
    //    GoogleMapsApi.Entities.Directions.Response.DirectionsResponse drivingDirections = GoogleMaps.Directions.Query(drivingDirectionRequest);
    //    GoogleMapsApi.Entities.Directions.Response.Route route = drivingDirections.Routes.First();
    //    GoogleMapsApi.Entities.Directions.Response.Leg leg = route.Legs.First();
    //    return leg.Distance.Value;
    //}
}
