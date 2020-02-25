using System.Collections.Generic;

namespace PersonalBlog.ViewModels
{
    public class DeleteUnusedImagesResuleViewModel 
    {
        public List<string> obsoleteImageList { get; set; }
        public List<string> missingImageList { get; set; }
    }
}