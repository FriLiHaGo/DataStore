using DataStoreDB.NHibernate.NHRepositories;
using System.Web.Mvc;

namespace WebDataStore.Extensions
{
    public static class DSHelper
    {
        public static MvcHtmlString GetFIO(this HtmlHelper html)
        {
            var userRepository = new NHUserRepository();
            var name = html.ViewContext.HttpContext.User.Identity.Name;
            var user = userRepository.GetByLogin(name);
            return MvcHtmlString.Create($"{user.Name} {user.Sername}");
        }
    }
}