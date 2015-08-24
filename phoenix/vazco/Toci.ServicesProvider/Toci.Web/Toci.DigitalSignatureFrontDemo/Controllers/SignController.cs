using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Toci.DigitalSignatureFrontDemo.Models;

namespace Toci.DigitalSignatureFrontDemo.Controllers
{
    public class SignController : Controller
    {
 
        // GET: Sign
        public ActionResult Index()
        {
            return View();
        }

        
        [HttpPost]
        public async Task<RedirectToRouteResult> Upload(HttpPostedFileBase file,string textToSign)
        {//tutaj nie działa przekazywanie 2 parametrów ;_;
            
            try
            {
                if (file.ContentLength > 0)
                {
                    var buffer = new byte[file.InputStream.Length];
                    await file.InputStream.ReadAsync(buffer, 0, (int)file.InputStream.Length); //tutaj mamy wczytany buffer z certyfikatem, trzeba go zabaseować i wysłać do api
                }
                ViewBag.Message = "Upload successful";
                return RedirectToAction("Sign");
            }
            catch
            {
                ViewBag.Message = "Upload failed";
                return RedirectToAction("UploadError");
            } 
        }

        public ViewResult UploadError()
        {
            return View();
        }

        public ActionResult Sign()
        {
            //podpisywanie cyfrowe... no własnie jeszcze nie zrobione :) . 
            HttpClient connectToSignApi = new HttpClient();
           // StringContent content = new StringContent((""));
           // connectToSignApi.PostAsync("http://localhost:14611/", )
            SignedModel signedModel = new SignedModel();;

            return View(signedModel);
        }
    }
}