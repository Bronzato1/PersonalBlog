using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PersonalBlog.ViewModels;

namespace PersonalBlog
{
    public class ChatViewComponent : ViewComponent
    {
        private readonly IBlogRepository _blogRepository;

        public ChatViewComponent(IBlogRepository blogRepository)
        {
            // Résolution du service par injection de dépendances
            _blogRepository = blogRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            // Traitement asynchrone pour obtenir les informations de mon évènement
            // Event currentEvent = null;
            // var eventId = GetCurrentEventId();
            // if (eventId.HasValue)
            // {
            //     currentEvent = await _eventService.GetEventAsync(eventId.Value);
            // }

            ChatViewModel vm = new ChatViewModel
            {
                Discussion = "blah blah"
            };

            return View("Default", vm);
        }
    }
}