using Domain.Repository;
using Domain.UseCases;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    public class UseCaseTests
    {
        private GetRssInteractor _interactor;

        [OneTimeSetUp]
        public void SetUp()
        {
            var mock = new Mock<IRepository>();
            mock.Setup(repo => repo.ProcessRssFeed()).Returns(TestUtils.TestRssEntity);
            _interactor = new GetRssInteractor(mock.Object);
        }

        [Test]
        public void TestGetRss_Null()
        {
            Assert.Throws<ArgumentNullException>(() => _interactor.Handle(null));
        }


        [Test]
        public void TestGetRss()
        {
            var result = _interactor.Handle(null);
            Assert.NotNull(result);
            Assert.AreEqual(TestUtils.TestRssEntity.Title, result.Title);
            Assert.AreEqual(TestUtils.TestRssEntity.Description, result.Description);
        }
    }
}
