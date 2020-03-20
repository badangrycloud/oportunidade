using System;
using Presentation.Modules;
using Domain.UseCases;
using Ninject;

namespace Presentation
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel(new RssModule());
            var useCase = kernel.Get<GetRssInteractor>();
            var rssFeed = useCase.Handle(null);

            System.Console.WriteLine($"Blog Information: { rssFeed.Title }");
            System.Console.WriteLine($"Last Alteration: { rssFeed.LastBuildDate }");
            Console.WriteLine();

            foreach (var item in rssFeed.Items)
            {
                System.Console.WriteLine($"Blog Title: { item.Title }");
                System.Console.WriteLine($"Created by: { item.Creator }");
                System.Console.WriteLine($"Publish Date: { item.PubDate }");
                Console.WriteLine();

                Console.WriteLine("The 10 principal words of this topic are:");
                var index = 1;
                foreach (var word in item.Words)
                {
                    Console.WriteLine($"{ index }ª) { word.Word.ToUpper() }, apeears { word.TotalTimesUsed } times");
                    index++;
                }

                Console.WriteLine();

                Console.WriteLine($"Total words used in this post { item.TotalWordsBlog }");

                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
