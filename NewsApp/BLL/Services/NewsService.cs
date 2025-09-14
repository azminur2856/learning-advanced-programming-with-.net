using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class NewsService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<News, NewsDTO>().ReverseMap();
                cfg.CreateMap<News, NewsCategortDTO>().ReverseMap();
                cfg.CreateMap<Category, CategoryDTO>().ReverseMap();
                cfg.CreateMap<Category, CategoryNewsDTO>().ReverseMap();
            });
            return new Mapper(config);
        }

        public static List<NewsDTO> Get()
        {
            var data = DataAccessFactory.NewsData().Get();
            return GetMapper().Map<List<NewsDTO>>(data);
        }

        public static NewsDTO Get(int id)
        {
            var data = DataAccessFactory.NewsData().Get(id);
            return GetMapper().Map<NewsDTO>(data);
        }

        public static bool Create(NewsDTO news)
        {
            var n = GetMapper().Map<News>(news);
            return DataAccessFactory.NewsData().Create(n);
        }

        public static bool Update(NewsDTO news)
        {
            var n = GetMapper().Map<News>(news);
            return DataAccessFactory.NewsData().Update(n);
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.NewsData().Delete(id);
        }
        public static List<NewsCategortDTO> GetByCategory(string category)
        {
            var data = DataAccessFactory.NewsFeaturesData().GetByCategory(category);
            return GetMapper().Map<List<NewsCategortDTO>>(data);
        }
        public static List<NewsCategortDTO> GetByCategoryAndDate(string category, string date)
        {
            var data = DataAccessFactory.NewsFeaturesData().GetByCategoryAndDate(category, date);
            return GetMapper().Map<List<NewsCategortDTO>>(data);
        }
        public static List<NewsDTO> GetByDate(string date)
        {
            var data = DataAccessFactory.NewsFeaturesData().GetByDate(date);
            return GetMapper().Map<List<NewsDTO>>(data);
        }
    }
}
