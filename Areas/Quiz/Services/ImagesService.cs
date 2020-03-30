using System.Linq;
using PersonalBlog.Models;
using PersonalBlog.Quizbee.Models;

namespace PersonalBlog.Quizbee.Services
{
    public class ImagesService
    {
        #region Define as Singleton
        private static ImagesService _Instance;

        public static ImagesService Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ImagesService();
                }

                return (_Instance);
            }
        }

        private ImagesService()
        {
        }
        #endregion
        
        public bool SaveNewImage(Image image)
        {
            using (var context = new MyDbContext())
            {
                context.Images.Add(image);

                return context.SaveChanges() > 0;
            }
        }

        public Image GetImage(int ID)
        {
            using (var context = new MyDbContext())
            {
                return context.Images
                                    .Where(q => q.ID == ID)
                                    .FirstOrDefault();
            }                        
        }
    }
}