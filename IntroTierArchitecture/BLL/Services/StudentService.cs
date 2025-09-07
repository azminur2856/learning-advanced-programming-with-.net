using AutoMapper;
using BLL.DTOs;
using DAL.EF.Tables;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class StudentService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Student, StudentDTO>().ReverseMap();
            });
            return new Mapper(config);
        }

        public static List<StudentDTO> Get()
        {
            var data = new StudentRepo().Get();
            return GetMapper().Map<List<StudentDTO>>(data);
        }

        public static bool Create(StudentDTO s)
        {
            var st = GetMapper().Map<Student>(s);
            return new StudentRepo().Create(st);
        }
    }
}
