using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TDD
{
    internal static class Extension
    {
        internal static IEnumerable<int> SumByGroup<T>(this IEnumerable<T> list,Func<T,int> func ,int count)
        {
            if (count <= 0) throw new ArithmeticException("Can't devid by 0");
            decimal g = 0;
            return from y in (  
                from x in list
                select new
                {
                    item=func(x),
                    order=Math.Floor((g++)/count)
                })
            group y by y.order into gp
            select gp.Sum(t=>t.item); 
        }
    }
}
