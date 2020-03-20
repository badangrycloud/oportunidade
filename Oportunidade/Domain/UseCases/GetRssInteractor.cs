using Domain.Entities;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.UseCases
{
    public class GetRssInteractor : IRequestHandler<string?, RssEntity>
    {
        private readonly IRepository _repository;

        public GetRssInteractor(IRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public RssEntity Handle(string data)
        {
            return _repository.ProcessRssFeed();
        }
    }
}
