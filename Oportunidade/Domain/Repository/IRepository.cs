using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Repository
{
    public interface IRepository
    {
        RssEntity ProcessRssFeed();
    }
}
