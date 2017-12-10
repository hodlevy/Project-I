using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace BL
{
    public interface IBL
    {
        void AddNanny(Nanny nanny);
        void DeleteNanny(Nanny nanny);
        void UpdateNanny(Nanny nanny);
        void AddMother(Mother mother);
        void DeleteMother(Mother mother);
        void UpdateMother(Mother mother);
        void AddChild(Child child);
        void DeleteChild(Child child);
        void UpdateChild(Child child);
        void AddContract(Contract contract);
        void DeleteContract(Contract contract);
        void UpdateContract(Contract contract);
        List<Nanny> AllNannys();
        List<Mother> AllMothers();
        List<Child> AllChildren();
        List<Contract> AllContracts();
    }
}
