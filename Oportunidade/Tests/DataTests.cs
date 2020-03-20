using Data.Api;
using Data.Repository;
using Domain.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Tests
{
    public class Tests
    {
        IRepository _repository;

        [SetUp]
        public void Setup()
        {
            var mockApi = new Mock<IApi>();
            mockApi.Setup(api => api.GetRssData()).Returns(TestUtils.TestRssData);
            _repository = new RssRepository(mockApi.Object);
        }

        [Test]
        public void GetData()
        {
            var resutl = _repository.ProcessRssFeed();
            Assert.NotNull(resutl);
            Assert.AreEqual(TestUtils.TestRssEntity.Description, resutl.Description);
            Assert.AreEqual(TestUtils.TestRssEntity.Title, resutl.Title);
        }

        [Test]
        [TestCaseSource(nameof(GetInvalidData))]
        public void GetRss_InvalidData()
        {
            Assert.Throws<ArgumentNullException>(() => _repository.ProcessRssFeed());
        }

        public static IEnumerable<string> GetInvalidData()
        {
            yield return "";
            yield return null;
        }
    }
}