using DDD_IOC_Unitofwork.Domin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD_IOC_Unitofwork.Application
{
    public class ABCApp
    {
        ABCService abcService;
        public ABCApp(ABCService abcService) 
        {
            this.abcService = abcService;
        }

        public bool IsSame()
        {
            return abcService.IsSame();
        }
    }
}
