using AutoMapper;
using EComm.Auth;
using EComm.DTOs;
using EComm.EF;
using EComm.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EComm.Controllers
{
    public class CustomerController : Controller
    {
        EComm_Sum25_AEntities db = new EComm_Sum25_AEntities();
        // GET: Customer

        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Order, OrderDTO>();
                cfg.CreateMap<Order, OrderProductDTO>();
                cfg.CreateMap<OrderDetail, OrderDetailDTO>();
                cfg.CreateMap<Product, ProductDTO>();
            });
            return new Mapper(config);
        }
        [Logged]
        public ActionResult Index()
        {
            var user = (User)Session["User"];
            var orders = (from o in db.Orders
                          where
                         o.CustomerId == (int)user.CustomerId
                          select o).ToList();
            return View(GetMapper().Map<List<OrderDTO>>(orders));
        }
    }
}