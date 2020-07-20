using NUnit.Framework;
using Vintri.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Vintri.Repositories;
using Moq;
using Vintri.Models.Factories;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using Vintri.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Vintri.Controllers.Tests
{
    [TestFixture()]
    public class VintriControllerTests
    {

        private Mock<IBeerRepository> _beerRepository;
        private Mock<BaseClassDataBaseRepository> _dataBaseRepository;
        private Mock<IUserResponseFactory> _userResponseFactory;

        [OneTimeSetUp]
        public void SetUp()
        {
            _beerRepository = new Mock<IBeerRepository>();
            _dataBaseRepository = new Mock<BaseClassDataBaseRepository>();
            _userResponseFactory = new Mock<IUserResponseFactory>();
        }

        [Test()]
        public async Task PostNotFoundTest()
        {
            //Assign
            var beerId = 11;
            var userName = "unitTest@email.com";
            var rating = Rating.Great;

            var controller = new VintriController(_beerRepository.Object, _dataBaseRepository.Object, _userResponseFactory.Object);
            var userRating = new UserJson
            {
                UserName = userName,
                Rating = rating,
                Comments = null
            };

            //Act
            var actual = await controller.Post(beerId, userRating);

            //Assert
            Assert.That(actual, Is.Not.Null);
            Assert.That(actual, Is.InstanceOf(typeof(NotFoundObjectResult)));
        }
    }
}