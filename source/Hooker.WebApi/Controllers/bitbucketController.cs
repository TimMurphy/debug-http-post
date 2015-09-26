using System.Web.Http;
using Anotar.NLog;

namespace Hooker.WebApi.Controllers
{
    // ReSharper disable once InconsistentNaming
    public class bitbucketController : ApiController
    {
        // POST api/bitbucket
        public void Post([FromBody]string value)
        {
            LogTo.Debug(() => $"{nameof(bitbucketController)}.{nameof(Post)}({nameof(value)}: {value})");
        }
    }
}
