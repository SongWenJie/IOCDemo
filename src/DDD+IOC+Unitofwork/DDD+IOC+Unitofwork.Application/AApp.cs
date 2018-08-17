using DDD_IOC_Unitofwork.Domin;
using DDD_IOC_Unitofwork.Domin.Repository;
using DDD_IOC_Unitofwork.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD_IOC_Unitofwork.Application
{
    public class AApp
    {
        IUnitofwork unitofwork;
        public AApp(IUnitofwork unitofwork)
        {
            this.unitofwork = unitofwork;
        }

        public void Oprate()
        {
            unitofwork.BeginTrans();

            unitofwork.Insert(new A());
            unitofwork.Update<B>(
                m=>m.ID==1,
                m=> {
                    m.ID = 2;
                    return m;
                });
            unitofwork.Delete<C>(c => c.ID == 1);

            unitofwork.SubmitTrans();
        }
    }
}
