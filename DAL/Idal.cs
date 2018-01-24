using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    /// <summary>
    /// interface for DAL layer
    /// </summary>
    public interface Idal
    {
        #region Nanny
        void AddNanny(Nanny nanny);
        void DeleteNanny(string ID);
        void UpdateNanny(Nanny nanny);
        #endregion
        #region Mother
        void AddMother(Mother mother);
        void DeleteMother(string ID);
        void UpdateMother(Mother mother);
        #endregion
        #region Child
        void AddChild(Child child);
        void DeleteChild(string ID);
        void UpdateChild(Child child);
        #endregion
        #region Contract
        void AddContract(Contract contract);
        void DeleteContract(int number);
        void UpdateContract(Contract contract);
        #endregion
        #region Lists
        List<Nanny> AllNannys();
        List<Mother> AllMothers();
        List<Child> AllChildren();
        List<Contract> AllContracts();
        #endregion
        #region Get
        Nanny GetNanny(string nannyID);
        Mother GetMother(string motherID);
        Child GetChild(string childID);
        Contract GetContract(int number);
        Contract GetContractByID(string ID);
        List<Contract> GetContractsByID(string ID);
        #endregion
        void Reset();
    }
}
