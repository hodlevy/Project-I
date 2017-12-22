﻿using System;
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
        void AddNanny(Nanny nanny);
        void DeleteNanny(Nanny nanny);
        void UpdateNanny(Nanny nanny);
        #endregion
        #region Mother
        void AddMother(Mother mother);
        void DeleteMother(Mother mother);
        void UpdateMother(Mother mother);
        #endregion
        #region Child
        void AddChild(Child child);
        void DeleteChild(Child child);
        void UpdateChild(Child child);
        #endregion
        #region Contract
        void AddContract(Contract contract);
        void DeleteContract(Contract contract);
        void UpdateContract(Contract contract);
        #endregion
        List<Nanny> AllNannys();
        List<Mother> AllMothers();
        List<Child> AllChildren();
        List<Contract> AllContracts();
    }
}
