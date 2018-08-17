using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD_IOC_Unitofwork.Domin.Repository
{
    public interface IUnitofwork
    {
        void Insert<T>(T model);

        void Delete<T>(Func< T,bool> condition);

        void Update<T>(Func<T,bool> condition, Func<T, T> content);

        void BeginTrans();

        void SubmitTrans();
    }
}
