using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface INewsFeatures
    {
        List<News> GetByCategory(string category);
        List<News> GetByDate(string date);
        List<News> GetByCategoryAndDate(string category, string date);
    }
}
