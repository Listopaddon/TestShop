using BusinessLogic.LogicBusiness.PlaceSession;
using BusinessLogic.LogicBusiness.User;
using DataAccess.Models;
using DataAccess.Repositories;
using DataAccess.Repositories.PlaceSession;
using DataAccess.Repositories.User;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace IntegerTestsBusinessLogic.UserTests
{
    [TestClass]
    public class UserLogicTests
    {
        UserLogic userLogic;
        PlaceSessionLogic placeSessionLogic;
        string connectionString = ConnectionString.connectionStringFake;
        long idUser ;

        [TestInitialize]
        public void Initialize()
        {
            placeSessionLogic = new PlaceSessionLogic(new PlaceSessionRepository(connectionString));
            userLogic = new UserLogic(new UserRepository(connectionString), placeSessionLogic);
            idUser = userLogic.AddUser("TestUser", "1111", "testRole");
        }

        [TestMethod]
        public void AddUserTest()
        {
            //Act
            long result = userLogic.AddUser("TestUser", "1111", "testRole");
            long expected = userLogic.GetUser(result).Id;

            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void DeleteUserTest()
        {
            //Arrange
            long idUser = userLogic.AddUser("TestUser","Test","Test");

            //Act
            userLogic.DeleteUser(idUser);

            //Assert
            Assert.IsNull(userLogic.GetUser(idUser));
        }

        [TestMethod]
        public void UpdateUserTest()
        {
            //Arrange
            long idUser = userLogic.AddUser("Test","Test","Test");
            UserModel expected = new UserModel(idUser, "Puziks", "123321", "Admin");

            //Act
            userLogic.UpdateUser(expected);
            UserModel result = userLogic.GetUser(idUser);

            //Assert
            Assert.AreEqual(expected.Id, result.Id);
            Assert.AreEqual(expected.Login, result.Login);
            Assert.AreEqual(expected.Password, result.Password);
            Assert.AreEqual(expected.Role, result.Role);
        }

        [TestMethod]
        public void GetUsersTest()
        {
            //Arrange
            List<UserModel> expected = userLogic.GetUsers();
            expected.Add(userLogic.GetUser(userLogic.AddUser("Vasja", "54", "User")));

            //Act
            List<UserModel> result = userLogic.GetUsers();

            //Assert
            for (int i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, result[i].Id);
                Assert.AreEqual(expected[i].Login, result[i].Login);
                Assert.AreEqual(expected[i].Password, result[i].Password);
                Assert.AreEqual(expected[i].Role, result[i].Role);
            }
        }

        [TestMethod]
        public void GetUserTest()
        {
            //Arrange
            long idUser = userLogic.AddUser("TestUser", "1111", "testRole");
            UserModel expected = new UserModel(idUser, "TestUser", "1111", "testRole");

            //Act
            UserModel result = userLogic.GetUser(idUser);

            //Assert
            Assert.AreEqual(expected.Id, result.Id);
            Assert.AreEqual(expected.Login, result.Login);
            Assert.AreEqual(expected.Password, result.Password);
            Assert.AreEqual(expected.Role, result.Role);
        }
    }
}
