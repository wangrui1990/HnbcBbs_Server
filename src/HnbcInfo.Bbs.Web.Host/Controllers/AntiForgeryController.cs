using Microsoft.AspNetCore.Antiforgery;
using HnbcInfo.Bbs.Controllers;

namespace HnbcInfo.Bbs.Web.Host.Controllers
{
    public class AntiForgeryController : BbsControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
