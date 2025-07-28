using NaturaStore.Web.ViewModels.Favorite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturaStore.Web.ViewModels.Favorite
{
    public class FavoriteListViewModel
    {
        public IEnumerable<FavoriteItemViewModel> Items { get; set; }
            = Enumerable.Empty<FavoriteItemViewModel>();
    }
}