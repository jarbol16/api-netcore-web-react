using Aranda.ComponenteAutorizacion.Api.Controllers;
using Aranda.ComponenteAutorizacion.Entities;
using BusinessRules;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using Utilities;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        private readonly  Mock<MainContext> mockDbContext;
        private readonly Mock<IUserBusiness> mockUserBusiness;
        private readonly Mock<IRepository> mockRepository;
        public UnitTest1()
        {
            mockDbContext = new Mock<MainContext>();
            mockUserBusiness = new Mock<IUserBusiness>();
            mockRepository = new Mock<IRepository>();
        }

        [TestMethod]
        public void GetUsersTest()
        {
            List<Usuario> users = new List<Usuario>
            {
                new Usuario
                {
                    Id=1,
                    Nombre="admon",
                    Contrasena ="123"
                },
                new Usuario
                {
                    Id=2,
                    Nombre="dev",
                    Contrasena="456"
                }
            };
            mockDbContext.Setup(x => x.Usuarios).Returns(BaseTest.GetQueryableMockDbSet<Usuario>(users));


            var service = new Repository(mockDbContext.Object);
            var response = service.GetList();

            Assert.AreEqual(users.Count, response.Count);
        }


        [TestMethod]
        public void ValidateUserControllerTest()
        {
            Usuario user = new Usuario
            {
                Id = 1,
                Nombre = "admon",
                Persona = new Persona
                {
                    Nombre="Daniel"
                }
            };

            UserCredentials credentials = new UserCredentials
            {
                UserName = "admon",
                Password = "123"
            };

            mockUserBusiness.Setup(x => x.ValidateLogin(credentials)).Returns(user);

            UserController userController = new UserController(mockUserBusiness.Object);
            var response =  userController.UserValidate(credentials);
            var objResult = response as ObjectResult;
            var objResult2 = objResult.Value;

            Assert.AreEqual(user, objResult2);

        }


    }
}
