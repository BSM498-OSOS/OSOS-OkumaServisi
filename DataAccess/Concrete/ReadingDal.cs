using DataAccess.Abstract;
using Entity.Concrete;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class ReadingDal : IReadingDal
    {

        public Reading Get(Expression<Func<Reading, bool>> filter)
        {
            using(var context = new ReadingsDbContext())
            {
                var result=context.Collection.Find(filter).FirstOrDefault();
                return result;
            }
        }

        public List<Reading> GetAll(Expression<Func<Reading, bool>> filter = null)
        {
            using (var context = new ReadingsDbContext())
            {
                if(filter != null)
                {
                    var result = context.Collection.Find(filter).ToList();
                    return result;
                }
                else
                {
                    var result = context.Collection.Find(_=>true).ToList();
                    return result;
                }
                   
            }
        }
    }
}
