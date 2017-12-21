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
            //כאן נאתחל כמה מופעים להרצה הראשונה
        }
        #region Nanny
        void IBL.AddNanny(Nanny nanny)
        {
            int nannyAge = DateTime.Now.Year - nanny.BirthDate.Year;
            if (nannyAge < 18)
                throw new Exception("Nanny is too young!");
            MyDal.AddNanny(nanny);
        }
        void IBL.DeleteNanny(Nanny nanny)
        {
            MyDal.DeleteNanny(nanny);
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
        void IBL.DeleteMother(Mother mother)
        {
            MyDal.DeleteMother(mother);
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
        void IBL.DeleteChild(Child child)
        {
            MyDal.DeleteChild(child);
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
            Mother mother = GetMother(contract.MotherId);
            list = DataSource.listContract.FindAll(item => item.NannyId == nanny.Id && item.MotherId == mother.Id);
            double discount = (list.Count() - 1) * 0.02;


            MyDal.AddContract(contract);
        }
        void IBL.DeleteContract(Contract contract)
        {
            MyDal.DeleteContract(contract);
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
        Nanny GetNanny(string nannyID)
        {
            Nanny nanny = new Nanny();
            //List<Nanny> list = DataSource.listNanny.FindAll(x => x.Id == nannyID);
            var v = from item in DataSource.listNanny
                    where item.Id == nannyID
                    select item;
            nanny = v.First();
            return nanny;
        }
        Mother GetMother(string motherID)
        {
            Mother mother = new Mother();
            //List<Mother> list = DataSource.listMother.FindAll(x => x.Id == motherID);
            var v = from item in DataSource.listMother
                    where item.Id == motherID
                    select item;
            mother = v.First();
            return mother;
        }
        Child GetChild(string childID)
        {
            Child child = new Child();
            //List<Child> list = DataSource.listChild.FindAll(x => x.Id == childID);
            var v = from item in DataSource.listChild
                    where item.Id == childID
                    select item;
            child = v.First();
            return child;
        }
        List<Nanny> VacationCheck_AllNanny()
        {
            List<Nanny> list = DataSource.listNanny.FindAll(x => x.VacationCheck == true);
            return list;
        }
        List<Nanny> PotentiallyNannies(Mother mother)
        {
            List<Nanny> nannies = null;
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
            if (nannies == null)
            {
                //לשים ברשימה את 5 המטפלות הכי קרובות לדרישות
            }
            return nannies;
        }
    }
}
