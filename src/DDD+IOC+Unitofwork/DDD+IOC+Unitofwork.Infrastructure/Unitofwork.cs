using DDD_IOC_Unitofwork.Domin.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD_IOC_Unitofwork.Infrastructure
{
    public class Unitofwork : IUnitofwork
    {
        public void BeginTrans()
        {
        }

        public void Delete<T>(Func< T,bool> condition)
        {
        }

        public void Insert<T>(T model)
        {
        }

        public void SubmitTrans()
        {
        }

        public void Update<T>(Func<T, bool> condition, Func<T, T> content)
        {
        }
    }
}
