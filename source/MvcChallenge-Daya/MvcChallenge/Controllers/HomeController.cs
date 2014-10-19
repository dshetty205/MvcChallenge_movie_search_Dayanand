using System;
using System.Collections.Generic;
using System.Runtime.Caching;
using System.Web.Mvc;
using Core;
using Core.Model;
using Core.Repositories;


namespace MvcChallenge.Controllers
{
    public class HomeController : Controller
    {
        #region Fields
        /// <summary>
        /// Static memoery cache object
        /// </summary>
        private static readonly MemoryCache CacheTitlesData = MemoryCache.Default;

        /// <summary>
        /// Repository static object thru Core project
        /// </summary>
        private static readonly ITitleRepository _repository =
            IoCContainerFactory.Current.GetInstance<ITitleRepository>();
        #endregion

        #region Actions
        /// <summary>
        /// Default page with titles search panel
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            if (!CacheTitlesData.Contains("ListTitles"))
                RefreshListAgency();

            return View();
        }
        
        /// <summary>
        /// jquery typeahead ajax call
        /// </summary>
        /// <returns></returns>
        public JsonResult TitlesLookup()
        {
           return Json(ListAgency, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// Partial view to display title details
        /// </summary>
        /// <param name="titleId"></param>
        /// <returns></returns>
        public ActionResult ShowTitleDetails(int titleId)
        {
            var rm = _repository.GetTitleDetails(titleId);
           
            return PartialView(rm);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Load or Get Cache data
        /// </summary>
        private static List<TitleSearch> ListAgency
        {
            get
            {
                if (!CacheTitlesData.Contains("ListTitles"))
                    RefreshListAgency();
                return CacheTitlesData.Get("ListTitles") as List<TitleSearch>;
            }
        }

        /// <summary>
        /// Get Cache data
        /// </summary>
        private static void RefreshListAgency()
        {
            var listTitles = _repository.GetTitlesData();

            var cacheItemPolicy = new CacheItemPolicy { AbsoluteExpiration = DateTime.Now.AddDays(1) };

            CacheTitlesData.Add("ListTitles", listTitles, cacheItemPolicy);
        }

        #endregion

        #region Other Actions
        /// <summary>
        /// About Menu page
        /// </summary>
        /// <returns></returns>
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        /// <summary>
        /// Contact Page
        /// </summary>
        /// <returns></returns>
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        #endregion 
    }
}
