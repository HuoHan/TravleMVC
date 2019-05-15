﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using WebMvcTravel.Models;
using PagedList;
using PagedList.Mvc;

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
        public ActionResult Blog(int pageIndex=1)
        {
            int pageSize = 2;
            string result = HttpClientHelper.Sender("get", "api/Blogs", null);
            List<Blogs> str = JsonConvert.DeserializeObject<List<Blogs>>(result);
            IPagedList<Blogs> list = str.ToPagedList<Blogs>(pageIndex,pageSize);
            return View(list);
        }
        /// <summary>
        /// 博客查看更多详情1
        /// </summary>
        /// <returns></returns>
        public ActionResult Blog_Single(int id=0)
        {
            string result = HttpClientHelper.Sender("get", "api/Blogs", null);
            List<Blogs> str = JsonConvert.DeserializeObject<List<Blogs>>(result);
            return View(str.Where(m=>m.BlogsId==id).ToList());
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
        //得到所有的问题和回答
        public JsonResult GetQue()
        {
            string res = HttpClientHelper.Sender("get", "api/QuesApi", null);

            return Json(res, JsonRequestBehavior.AllowGet);
        }
    }
}