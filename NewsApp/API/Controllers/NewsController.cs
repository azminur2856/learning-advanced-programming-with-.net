using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    [RoutePrefix("api/news")]
    public class NewsController : ApiController
    {
        [HttpGet]
        [Route("all")]
        public HttpResponseMessage Get()
        {
            var data = NewsService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage Get(int id)
        {
            var data = NewsService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpPost]
        [Route("create")]
        public HttpResponseMessage Create(NewsDTO news)
        {
            var data = NewsService.Create(news);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpPost]
        [Route("update")]
        public HttpResponseMessage Update(NewsDTO news)
        {
            var data = NewsService.Update(news);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            var data = NewsService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("category/{category}")]
        public HttpResponseMessage GetByCategory(string category)
        {
            var data = NewsService.GetByCategory(category);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("date/{date}")]
        public HttpResponseMessage GetByDate(string date)
        {
            if (!DateTime.TryParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture,
                                        DateTimeStyles.None, out DateTime dt))
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid date format. Use yyyy-MM-dd.");
            }

            try
            {
                var data = NewsService.GetByDate(date);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("category/{category}/date/{date}")]
        public HttpResponseMessage GetByCategoryAndDate(string category, string date)
        {
            if (!DateTime.TryParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture,
                                        DateTimeStyles.None, out DateTime dt))
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid date format. Use yyyy-MM-dd.");
            }

            try
            {
                var data = NewsService.GetByCategoryAndDate(category, date);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

    }
}
