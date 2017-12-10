using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface Idal
    {
        void AddNanny(BE.Nanny nanny);
        void DeleteNanny(BE.Nanny nanny);
        void UpdateNanny(BE.Nanny nanny);
        void AddMother(BE.Mother mother);
        void DeleteMother(BE.Mother mother);
        void UpdateMother(BE.Mother mother);
        void AddChild(BE.Child child);
        void DeleteChild(BE.Child child);
        void UpdateChild(BE.Child child);
        void AddContract(BE.Contract contract);
        void DeleteContract(BE.Contract contract);
        void UpdateContract(BE.Contract contract);
        List<BE.Nanny> AllNannys();
        List<BE.Mother> AllMothers();
        List<BE.Child> AllChildren();
        List<BE.Contract> AllContracts();
    }
}
