using DDD_IOC_Unitofwork.Domin.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD_IOC_Unitofwork.Infrastructure.Repository
{
    public class BRepository: IBRepository
    {
        IUnitofwork unitofwork;
        public BRepository(IUnitofwork unitofwork)
        {
            this.unitofwork = unitofwork;
        }

        public override int GetHashCode()
        {
            return unitofwork.GetHashCode();
        }
    }
}
