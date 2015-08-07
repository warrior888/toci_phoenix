using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Toci.AlternativeClient.Controllers
{
    public class OauthController : Controller
    {
        // GET: Oauth
        public ActionResult Index()
        {
            string requestString =
    string.Format(
        "{0}?response_type={1}&client_id={2}&redirect_uri={3}",
        "https://localhost:44300/oauth/authorize", "code", "1", "http://localhost:38617/oauth/code"); //wypieprza się jako bed request - zła kolejność argumentów?(patrz niżej)
            return Redirect(requestString);

            /*dublujemy sprawę z vazco - zwykły get pod adres autoryzacji naszego "serwera"*/
            /*
            Rozmówka serwera z CodeAuthorizationClientem z tego projektu asp.net 
           Do servera GET /OAuth/Authorize?client_id=123456&redirect_uri=http%3A%2F%2Flocalhost%3A38500%2F&state=_Kpj_WQUiSUZLWve2ehg1w&scope=bio%20notes&response_type=code
           SERVER GET /Account/Login?ReturnUrl=%2FOAuth%2FAuthorize%3Fclient_id%3D123456%26redirect_uri%3Dhttp%253A%252F%252Flocalhost%253A38500%252F%26state%3D_Kpj_WQUiSUZLWve2ehg1w%26scope%3Dbio%2520notes%26response_type%3Dcode
           SERVER POST /Account/Login?ReturnUrl=%2FOAuth%2FAuthorize%3Fclient_id%3D123456%26redirect_uri%3Dhttp%253A%252F%252Flocalhost%253A38500%252F%26state%3D_Kpj_WQUiSUZLWve2ehg1w%26scope%3Dbio%2520notes%26response_type%3Dcod
                    BODY username=adam0309&password=Adam0809&submit.Signin=Sign+In
           SERVER GET /OAuth/Authorize?client_id=123456&redirect_uri=http%3A%2F%2Flocalhost%3A38500%2F&state=_Kpj_WQUiSUZLWve2ehg1w&scope=bio%20notes&response_type=code
           SERVER POST /OAuth/Authorize?client_id=123456&redirect_uri=http%3A%2F%2Flocalhost%3A38500%2F&state=_Kpj_WQUiSUZLWve2ehg1w&scope=bio%20notes&response_type=code
                    BODY submit.Grant=Grant
            Od servera GET /?code=4c93b11a6e56475595cd34654d8f456ec3e06c7d8dfc4dcab03567f86383f8a2&state=_Kpj_WQUiSUZLWve2ehg1w
            
            -----------------
            tutaj nas przenosi nas z powrotem na przeglądarkę, my mamy już wpisanego tokena i refresh tokena - którędy skubaniec poszedł?
            http://puu.sh/jt2BM/e5a97d1a3b.png <- cała wymiana pakietów
            http://puu.sh/jt2QP/dea22a49fe.png <- może tutaj dostajemy ten token, ale to bez sensu...

            pytanie dnia - jak to działa? 
            */
        }

        public ActionResult code(string code)
        {

            /*Tutaj odbierzemy kod, ubierzemy w kolejnego requesta i wyślemy z prośbą o access token - podejrzewam że odpowiedź wtedy byśmy otrzymali bardziej jawną
            gdyby byśmy zapytali o niego ręcznie... tylko że w tamtej wymianie pakietów nie widać, żeby klient wysyłał swój kod do serwera*/
            return null;
        }
    }
}