using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace BL
{
    /// <summary>
    /// interface for BL layer
    /// </summary>
    public interface IBL
    {
        void AddNanny(Nanny nanny);
        void DeleteNanny(string ID);
        void UpdateNanny(Nanny nanny);
        void AddMother(Mother mother);
        void DeleteMother(string ID);
        void UpdateMother(Mother mother);
        void AddChild(Child child);
        void DeleteChild(string ID);
        void UpdateChild(Child child);
        void AddContract(Contract contract);
        void DeleteContract(int number);
        void UpdateContract(Contract contract);
        List<Nanny> AllNannys();
        List<Mother> AllMothers();
        List<Child> AllChildren();
        List<Contract> AllContracts();
        List<Child> LonleyChildren();
        List<Nanny> PotentiallyNannies(string motherID);
        List<Nanny> VacationCheck_AllNanny();
        IEnumerable<IGrouping<int, Nanny>> GroupNanny(bool ifMinMax, bool isSorted = false);

    }
}
