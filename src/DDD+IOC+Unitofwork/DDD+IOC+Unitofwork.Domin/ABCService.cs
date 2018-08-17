using DDD_IOC_Unitofwork.Domin.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD_IOC_Unitofwork.Domin
{
    public class ABCService
    {
        IARepository aRepository;
        IBRepository bRepository;
        public ABCService(IARepository aRepository, IBRepository bRepository)
        {
            this.aRepository = aRepository;
            this.bRepository = bRepository;
        }

        public bool IsSame()
        {
            return this.aRepository.GetHashCode() == this.bRepository.GetHashCode();
        }
    }
}
