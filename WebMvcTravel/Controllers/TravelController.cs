using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

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
        public ActionResult Result_List()
        {
            return View();
        }
        /// <summary>
        /// 结果列表
        /// </summary>
        /// <returns></returns>
        public ActionResult Result_Grid()
        {
            return View();
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
        public ActionResult Blog()
        {
            return View();
        }
        /// <summary>
        /// 博客查看更多详情1
        /// </summary>
        /// <returns></returns>
        public ActionResult Blog_Single()
        {
            return View();
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