using System;
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
        /// 
        ///
        /// </summary>
        /// <returns></returns>        
        public ActionResult Index()
        {
            //ShowAddress();
            return View(GetMonthes());
        }
        public List<Addresses> GetMonthes()
        {
            string str = HttpClientHelper.Sender("get", "api/ScenicAreas", null);
            var item = JsonConvert.DeserializeObject<List<Addresses>>(str);
            return item;
        }
        public JsonResult Ajax(int id)
        {
            string str = HttpClientHelper.Sender("get", "api/ShowAddress?id=" + id, null);
            var item = JsonConvert.DeserializeObject<List<Addresses>>(str);
            return Json(item, JsonRequestBehavior.AllowGet);
        }
        //绑定月份
        public JsonResult AjaxMonth()
        {
            string str = HttpClientHelper.Sender("get", "api/ShowMonth", null);
            var item = JsonConvert.DeserializeObject<List<Monthes>>(str);
            return Json(item, JsonRequestBehavior.AllowGet);
        }
        ////Json格式
        //public string Ajax(int fid)
        //{
        //    string str = HttpClientHelper.Sender("get", "api/ShowAddress?id=" + fid, null);
        //    var ai = JsonConvert.SerializeObject(str);
        //    return ai;
        //}      
        /// <summary>
        /// 结果列表
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Result_List(string countyId = null, string addressId = null, string monthsId = null, int pageIndex = 1)
        {
            Cookies();
            var str = HttpClientHelper.Sender("get", "api/ScenicAreas?countyId=" + countyId + "&addressId=" + addressId + "&monthsId=" + monthsId, null);
            var list = JsonConvert.DeserializeObject<List<ScenicArea>>(str);
            IPagedList<ScenicArea> pageList = list.ToPagedList<ScenicArea>(pageIndex, 8);
            return View(pageList);
        }
        /// <summary>
        /// 结果列表
        /// </summary>
        /// <returns></returns>
        public ActionResult Result_Grid(string countyId = null, string addressId = null, string monthsId = null, int pageIndex = 1)
        {
            Cookies();
            var str = HttpClientHelper.Sender("get", "api/ScenicAreas?countyId=" + countyId + "&addressId="+ addressId+ "&monthsId="+ monthsId,null);
            var list = JsonConvert.DeserializeObject<List<ScenicArea>>(str);
            IPagedList<ScenicArea> pageList = list.ToPagedList<ScenicArea>(pageIndex, 15);
            return View(pageList);
        }
        /// <summary>
        /// 常见问题页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Faq()
        {
            Cookies();
            return View();
        }
        /// <summary>
        /// 静态页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Static_Page()
        {
            Cookies();
            return View();
        }
        public ActionResult About()
        {
            Cookies();
            return View();
        }
        /// <summary>
        /// 博客
        /// </summary>
        /// <returns></returns>
        public ActionResult Blog(int pageIndex = 1)
        {
            Cookies();
            int pageSize = 2;
            string result = HttpClientHelper.Sender("get", "api/Blogs?id=0", null);
            List<Blogs> str = JsonConvert.DeserializeObject<List<Blogs>>(result);
            IPagedList<Blogs> list = str.ToPagedList<Blogs>(pageIndex, pageSize);
            return View(list);
        }
        /// <summary>
        /// 博客查看更多详情1
        /// </summary>
        /// <returns></returns>
      
        public ActionResult Blog_Single(int id)
        {
            Cookies();
            ViewBag.id = id;
            return View();
        }
        //添加评论
        public int AddComment(Comment com)
        {
            string str = JsonConvert.SerializeObject(com);
            string result = HttpClientHelper.Sender("post", "api/Comment", str);
            return Convert.ToInt32(result);
        }
        public ActionResult Payment()
        {
            Cookies();
            return View();
        }
        /// <summary>
        /// 预定成功页面
        /// </summary>
        /// <returns></returns>
        /// //jj
        public ActionResult Confirmation()
        {
            Cookies();
            return View();
        }
        //得到所有的问题和回答
        public JsonResult GetQue()
        {
            string res = HttpClientHelper.Sender("get", "api/QuesApi", null);

            return Json(res, JsonRequestBehavior.AllowGet);
        }
        //通过用户名查询
        public JsonResult GetStatu(string userName)
        {
            string res = HttpClientHelper.Sender("get", "api/LoginApi?userName=" + userName, null);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        //注册
        public JsonResult CheckUser(string userName, string userPwd, string phone, string trueName)
        {
            UserLogin u = new UserLogin();
            u.TrueName = trueName;
            u.UserPwd = userPwd;
            u.UserName = userName;
            u.UserPhone = phone;
            string str = JsonConvert.SerializeObject(u);
            string res = HttpClientHelper.Sender("post", "api/LoginApi", str);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        //登陆
        public JsonResult CheckLogin(string userName, string userPwd)
        {
            string res = HttpClientHelper.Sender("get", "api/LoginApi?userName=" + userName + "&userPwd=" + userPwd, null);
            var list = JsonConvert.DeserializeObject<List<UserLogin>>(res);
            if (list.Count > 0)
            {
                HttpCookie cook = new HttpCookie("userName", HttpUtility.UrlEncode(list[0].TrueName, System.Text.Encoding.GetEncoding("UTF-8")));
                cook.Expires = DateTime.Now.AddMinutes(2);
                Response.AppendCookie(cook);
            }

            var result = list.Count > 0 ? "1" : "0";
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        public void Cookies()
        {
            HttpCookie cook = Request.Cookies["userName"];
            if (cook != null)
            {
                ViewBag.userName = HttpUtility.UrlDecode(cook.Value, System.Text.Encoding.GetEncoding("UTF-8"));

            }
            else
            {
                ViewBag.userName = "";
            }
        }
        //465
    }
}