using Data.Entities;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    public static class TestUtils
    {
        public static Rss TestRssData => new Rss
        {
            Atom= "http://www.w3.org/2005/Atom",
            Content = "http://purl.org/rss/1.0/modules/content/",
            Dc = "http://purl.org/dc/elements/1.1/",
            Slash = "http://purl.org/rss/1.0/modules/slash/",
            Sy= "http://purl.org/rss/1.0/modules/syndication/",
            Version= "2.0",
            Wfw= "http://wellformedweb.org/CommentAPI/",
            Channel = new Channel
            {
                Description = "Aqui no blog da Minuto Seguros você encontra dicas e notícias sobre seguros, carros, casas, eletrônicos, viagens e muito mais. Acesse e confira nosso conteúdo",
                Generator = "https://wordpress.org/?v=5.2.5",
                Language = "pt-BR",
                LastBuildDate = DateTime.Now.ToString(),
                Link = new Link
                {
                    Href = "test",
                    Rel= "test",
                    Type = "test"
                },
                Link2 = "test",
                Title= "Blog Minuto Seguros",
                UpdateFrequency = "\n\t1\t",
                UpdatePeriod = "\n\thourly\t",
                Item = new List<Item>()
                {
                    new Item
                    {
                        Title ="Test",
                        Link2 = "Test",
                        Category = new List<string>()
                        {
                            "Test"
                        },
                        CommentRss= "Test",
                        Comments= new List<string>()
                        {
                            "Test"
                        },
                        Creator= "Test",
                        Description= "Test",
                        Encoded= "Test",
                        Guid= new Data.Entities.Guid
                        {
                            IsPermaLink="false",
                            Text= "Test"
                        },
                        PubDate= DateTime.Now.ToString(),
                    }
                }
            }
        };

        public static RssEntity TestRssEntity => new RssEntity
        {
            Description = "Aqui no blog da Minuto Seguros você encontra dicas e notícias sobre seguros, carros, casas, eletrônicos, viagens e muito mais. Acesse e confira nosso conteúdo",
            LastBuildDate = DateTime.Now,
            Link = "Test2",
            Title = "Blog Minuto Seguros",
            Items = new List<ItemEntity>()
            {
                new ItemEntity()
                {
                    Category = new List<string>()
                    {
                        "Test2"
                    },
                    Creator= "Test2",
                    Description= "Test2",
                    Encoded = "Test2",
                    Link = "Test2",
                    PubDate =DateTime.Now,
                    Title = "Test2",
                    TotalWordsBlog = 1,
                    Words= new List<WordsEntity>()
                    {
                        new WordsEntity()
                        {
                            TotalTimesUsed = 1,
                            Word= "Test"
                        }
                    }
                }
            }
        };
    }
}
