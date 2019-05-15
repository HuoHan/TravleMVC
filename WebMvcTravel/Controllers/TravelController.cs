using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMvcTravel.Models;
using Newtonsoft.Json;
using PagedList.Mvc;
using PagedList;

namespace WebMvcTravel.Controllers
{
    public class TravelController : Controller
    {
        // GET: Travel
        /// <summary>
        /// 主页面
        /// </summary>
        /// <returns></returns>        
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 结果列表
        /// </summary>
        /// <returns></returns>
        public ActionResult Result_List(int pageIndex=1)
        {
            int pageSize = 2;
            string result = HttpClientHelper.Sender("get", "api/Result_List", null);
            List<Routese> list = JsonConvert.DeserializeObject<List<Routese>>(result);
            IPagedList<Routese> list1 = list.ToPagedList<Routese>(pageIndex, pageSize);
            return View(list1);
        }
        /// <summary>
        /// 结果列表
        /// </summary>
        /// <returns></returns>
        public ActionResult Result_Grid(int pageIndex = 1)
        {
            int pageSize = 2;
            string result = HttpClientHelper.Sender("get", "api/Result_Grid", null);
            List<Routese> list = JsonConvert.DeserializeObject<List<Routese>>(result);
            IPagedList<Routese> list1 = list.ToPagedList<Routese>(pageIndex, pageSize);
            return View(list1);
        }
        /// <summary>
        /// 常见问题页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Faq()
        {
            return View();
        }
        /// <summary>
        /// 静态页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Static_Page()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        /// <summary>
        /// 博客
        /// </summary>
        /// <returns></returns>
        public ActionResult Blog(int pageIndex=1)
        {
            int pageSize = 2;
            string result = HttpClientHelper.Sender("get","api/Blogs", null);
            List<Blogs> list = JsonConvert.DeserializeObject<List<Blogs>>(result);
            IPagedList<Blogs> list1 = list.ToPagedList<Blogs>(pageIndex,pageSize);
            return View(list1);            
        }
        /// <summary>
        /// 博客查看更多详情
        /// </summary>
        /// <returns></returns>
        public ActionResult Blog_Single(int id=0)
        {
            string result = HttpClientHelper.Sender("get", "api/Blogs", null);
            List<Blogs> list = JsonConvert.DeserializeObject<List<Blogs>>(result);
            return View(list.Where(m =>m.BlogsId==id).ToList());
        }
        public ActionResult Payment()
        {
            return View();
        }
        /// <summary>
        /// 预定成功页面
        /// </summary>
        /// <returns></returns>
        /// //jj
        public ActionResult Confirmation()
        {
            return View();
        }
    }
}