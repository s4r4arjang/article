using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Web.Admin.ViewComponents
{
    public class MenuView2 : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return  View();
        }
    }
    public class MenuView : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
