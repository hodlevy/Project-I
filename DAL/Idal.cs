using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public interface Idal
    {
        #region Nanny
        void AddNanny(BE.Nanny nanny);
        void DeleteNanny(BE.Nanny nanny);
        void UpdateNanny(BE.Nanny nanny);
        #endregion
        #region Mother
        void AddMother(BE.Mother mother);
        void DeleteMother(BE.Mother mother);
        void UpdateMother(BE.Mother mother);
        #endregion
        #region Child
        void AddChild(BE.Child child);
        void DeleteChild(BE.Child child);
        void UpdateChild(BE.Child child);
        #endregion
        #region Contract
        void AddContract(BE.Contract contract);
        void DeleteContract(BE.Contract contract);
        void UpdateContract(BE.Contract contract);
        #endregion
        List<Nanny> AllNannys();
        List<Mother> AllMothers();
        List<Child> AllChildren();
        List<Contract> AllContracts();
    }
}
