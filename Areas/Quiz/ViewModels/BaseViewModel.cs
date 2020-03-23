using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PersonalBlog.Models;

namespace PersonalBlog.Quizbee.ViewModels
{
    public class BaseViewModel
    {
        public CustomUser User { get; set; }

        /// <summary>
        /// Property for Page Information such as Tab title, Header Title, Breadcrumbs etc
        /// </summary>
        public PageInfo PageInfo { get; set; }        
    }

    /// <summary>
    /// Base View Model for all View Models where we need to show listing
    /// </summary>
    public class ListingBaseViewModel : BaseViewModel
    {
        public int pageNo { get; set; }
        public int pageSize { get; set; }
        public int TotalCount { get; set; }

        public Pager Pager { get; set; }
        public string searchTerm { get; set; }
    }
}