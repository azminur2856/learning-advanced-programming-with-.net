using DAL.EF.Tables;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<News, int, bool> NewsData()
        {
            return new Reops.NewsRepo();
        }

        public static IRepo<Category, int, bool> CategoryData()
        {
            return new Reops.CategoryRepo();
        }

        public static INewsFeatures NewsFeaturesData()
        {
            return new Reops.NewsRepo();
        }
    }
}
