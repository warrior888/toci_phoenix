using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using Microsoft.Owin;
using Microsoft.Owin.Helpers;
using Microsoft.Owin.Logging;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Infrastructure;


namespace Toci.Client.OauthProvider
{
    public class VazcoAuthenticationHandler : AuthenticationHandler<VazcoAuthenticationOptions>
    {
        private readonly HttpClient _httpClient;

        public VazcoAuthenticationHandler(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        protected override async Task<AuthenticationTicket> AuthenticateCoreAsync()
        {
            //z jakiegoś powodu gdy klikamy "Vazco" na stronie
            //ten kod się nie wykonuje mimo iż przechodzi konstruktor
            /*
            Wedle fidlera i httpRequestera gdy pukniemy do vazco poniższym getem to przeniesie nas na ich stronę aby się zalogować,
            a gdy jesteśmy zalogowani to poprosi o kliknięcie "use that account" - gdy klikniemy to serwer vazco to on w nasz redirect_uri pyka z kodem autoryzacyjnym
            np GET /_oauth/vazco?code=d656e81af3cb37b23e9bb0bfa8b272fba5cfad12 <<taka ścieżka dlatego, że to jest ten demonstracyjny link
            więc aby odebrać ten kod należało by ustawić sobie kontroler na httpGET i w nim odebrać kod(sądziłem że ten janusz
            autentykacji sobie sam z tym poradzi i bedzie to zbędne).
            Miałem nadzieję, że jakoś uda się odpalić taką wersję, jeszcze trochę będe 
            pisał - może zrobię to w ten sposób.
            mimo to poniższy kod na 99% jest dobry - pukamy po kod, a z kodem pukamy po token, gdy mamy token to wysyłamy request z tokenem 
            i claimsami - w odpowiedzi otrzymujemy te claimsy i możemy ich użyć
            do dalszego obrabiania - czy to zapisania użytkownika(chyba najlepsza opcja) czy czegokolwiek innego.
            */
            //pukamy do serwera w GECIE po to aby dostać kod autoryzacyjny
            HttpResponseMessage responseCode = await _httpClient.GetAsync(String.Format("{0}?response_type=code&client_id={1}&redirect_uri={2}",Options.AuthorizationEndpoint, Options.AppId,Options.CallBack));
                string responseText =await responseCode.Content.ReadAsStringAsync();
            //i tutajIFormCollection form = WebHelpers.ParseForm(text); pytanie w jaki sposób jest przysyłany do nas ten kod 
                 IFormCollection response = WebHelpers.ParseForm(responseText);
                
                string code = response["code"];

    
          
                //tutaj musimy złożyć zapytanie do serwera
                
                string redirectUri = Options.CallBack;
                string tokenRequest = "grant_type=authorization_code" +
                    "&code=" + Uri.EscapeDataString(code) +
                    "&client_id=" + Uri.EscapeDataString(Options.AppId) +
                    "&client_secret=" + Uri.EscapeDataString(Options.AppSecret)+
                    "&redirect_uri=" + Uri.EscapeDataString(redirectUri);
                //Złożyliśmy uri z zapytaniem - poniżej napierdzielamy do serwera       

                //w dokmumentacji vazco pisze, że parametry powinny przejść w takiej kolejności
                //ale w poście, nie w gecie, i z nagłówkiem  application/xwwwformurlencoded 
                StringContent tokenString = new StringContent(tokenRequest);
                tokenString.Headers.Add("Conent-Type", "application/x-www-form-urlencoded");
           
                HttpResponseMessage tokenResponse = await _httpClient.PostAsync(Options.TokenEndpoint, tokenString);
                tokenResponse.EnsureSuccessStatusCode();
                string text = await tokenResponse.Content.ReadAsStringAsync();
                IFormCollection form = WebHelpers.ParseForm(text);
                string accessToken = form["access_token"];
                string refreshToken = form["refresh"];
                string expires = form["expires"];
            //^^mamy odpowiedź! teraz wystarczy zapukać do serwera z access_tokenem po informacje o użytkowniku wooohooo

            /*TUTAJ MUSI BY PUKANIE PO CLAIMSY UŻYTKOWNIKA pod adres Options.UserInformationEndpoint*/
            return null; //<tutaj zwracamy authentication ticket zawierający claimsy pobrane z serwera
        }
    }
}