using AutoMapper;
using Data.Api;
using Data.Mappers;
using Domain.Entities;
using Domain.Helpers;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repository
{
    public class RssRepository : IRepository
    {
        private readonly IApi _api;
        private readonly IMapper _mapper;

        public RssRepository(IApi api)
        {
            _api = api ?? throw new ArgumentNullException(nameof(api));
            var mapperConfiguration = AutoMapperConfig.RegisterMappings();
            _mapper = mapperConfiguration.CreateMapper();           
        }

        public RssEntity ProcessRssFeed()
        {
            try
            {
                var feed = _api.GetRssData();
                var feedMatch = _mapper.Map<RssEntity>(feed.Channel);
                feedMatch.Items = _mapper.Map<List<ItemEntity>>(feed.Channel.Item);

                foreach(var item in feedMatch.Items)
                {
                    string text = CleanText(item);

                    item.TotalWordsBlog = item.TotalWords(text);
                    item.Words = item.GetRepeatedWords(text);
                }

                return feedMatch;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static string CleanText(ItemEntity item)
        {
            try
            {
                string text = string.Concat(item.Title, " ", item.Description, " ", item.Encoded);
                text = TextHelper.RemoveTagsHtml(text);
                text = TextHelper.RemovePunctuation(text);
                text = text.ToLower();
                text = TextHelper.RemoveArticlePrepostions(text);
                text = TextHelper.RemoveSpaces(text);
                return text;

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
