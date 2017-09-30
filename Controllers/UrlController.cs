
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EncurtadorURL.Controllers
{
  [Produces("application/json")]
  [Route("api/[Controller]")]
  public class UrlController : Controller
  {
    [HttpGet]
    public IActionResult Greetings(string url)
    {
       try
        {                
            string urlMigreMe = string.Format("http://tinyurl.com/api-create.php?url={0}", url);

            var client = new WebClient();

            string response = client.DownloadString(urlMigreMe);

            client.Dispose();

            return Ok(response);
        }
        catch (WebException ex)
        {
            return Ok("Erro ao encurtar a URL: ("+url+")" + ex.Message);
        }
    }
  }
}
