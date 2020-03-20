using Data.Api;
using Data.Repository;
using Domain.Repository;
using Domain.UseCases;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Presentation.Modules
{
    public class RssModule : NinjectModule
    {
        public override void Load()
        {
            var rssUrl = ConfigurationManager.AppSettings["Rss"];
            Bind<IApi>().To<GetRssApi>().WithConstructorArgument("url", rssUrl);
            Bind<IRepository>().To<RssRepository>();
            Bind<GetRssInteractor>().ToSelf().InSingletonScope();
        }
    }
}
