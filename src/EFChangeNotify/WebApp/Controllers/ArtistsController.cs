using EFChangeNotify;
using Microsoft.AspNet.SignalR;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Http;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ArtistsController : ApiController
    {
        private ChinookContext _db;
        private static readonly EntityChangeNotifier<Artist, ChinookContext> Notifier;

        static ArtistsController()
        {
            Notifier = new EntityChangeNotifier<Artist, ChinookContext>(a => a.ArtistId > 0);
            Notifier.Error += (sender, e) => Debug.WriteLine("[{0}, {1}, {2}]:\n{3}", e.Reason.Info, e.Reason.Source, e.Reason.Type, e.Sql);
            Notifier.Changed += notifier_Changed;
        }

        public IEnumerable<Artist> Get()
        {
            _db = new ChinookContext();
            var artists = from a in _db.Artists
                          select a;

            return artists;
        }

        private static void notifier_Changed(object sender, EntityChangeEventArgs<Artist> e)
        {            
            var context = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
            context.Clients.All.refresh();
        }

        protected override void Dispose(bool disposing)
        {            
            if (_db != null)
                _db.Dispose();

            base.Dispose(disposing);
        }
    }
}
