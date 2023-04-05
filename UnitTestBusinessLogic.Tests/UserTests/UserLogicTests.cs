using BusinessLogic.LogicBusiness.User;
using DataAccess.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using UnitTestBusinessLogic.Tests.PlaceSessionTests.SubObjects;
using UnitTestBusinessLogic.Tests.PlaceTests.SubObjects;
using UnitTestBusinessLogic.Tests.UserTests.SubObjects;

namespace UnitTestBusinessLogic.Tests.UserTests
{
    [TestClass]
    public class UserLogicTests
    {
        UserLogic userLogic;

        [TestInitialize]
        public void Initialize()
        {
            List<UserModel> users = new List<UserModel>
            {
                new UserModel(0,"Ivan", "LOX", "Admin"),
                new UserModel(1,"Igor", "Fox", "User"),
                new UserModel(2,"Igor_92", "Password", "Admin"),
                new UserModel(3,"Oleg", "OlegRULIT", "User"),
                new UserModel(4,"Maksim", "12345", "user")
            };

            userLogic = new UserLogic(new SubUserRepository(users),new SubPlaceSessionLogic());
        }

        [TestMethod]
        public void GetUserTest()
        {
            //Arrange
            UserModel expected = new UserModel(1, "Igor", "Fox", "User");

            //Act
            UserModel result = userLogic.GetUser(1);

            //Assert
            Assert.AreEqual(expected.Id, result.Id);
            Assert.AreEqual(expected.Login, result.Login);
            Assert.AreEqual(expected.Password, result.Password);
            Assert.AreEqual(expected.Role, result.Role);
        }


        [TestMethod]
        public void AddUserTest() => Assert.AreEqual(5, userLogic.AddUser("NewUser", "Password123", "User"));

        [TestMethod]
        public void DeleteUserTest()
        {
            //Arrange
            UserModel result = null;
            long id = 2;

            //Act
            List<UserModel> users = userLogic.GetUsers();
            userLogic.DeleteUser(id);
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Id == id)
                {
                    result = users[i];
                    break;
                }
            }

            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetUsersTest()
        {
            //Arrange
            List<UserModel> expected = new List<UserModel>
            {
                new UserModel(0,"Ivan", "LOX", "Admin"),
                new UserModel(1,"Igor", "Fox", "User"),
                new UserModel(2,"Igor_92", "Password", "Admin"),
                new UserModel(3,"Oleg", "OlegRULIT", "User"),
                new UserModel(4,"Maksim", "12345", "user")
            };

            //Act
            List<UserModel> result = userLogic.GetUsers();

            //Assert
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, result[i].Id);
                Assert.AreEqual(expected[i].Login, result[i].Login);
                Assert.AreEqual(expected[i].Password, result[i].Password);
                Assert.AreEqual(expected[i].Role, result[i].Role);
            }
        }

        [TestMethod]
        public void UpdateUserTest()
        {
            //Arrange
            UserModel expected = new UserModel(1, "Igor231", "Fox123", "Admin");

            //Act
            userLogic.UpdateUser(expected);
            List<UserModel> users = userLogic.GetUsers();

            //Assert
            Assert.AreEqual(expected.Id, users[1].Id);
            Assert.AreEqual(expected.Login, users[1].Login);
            Assert.AreEqual(expected.Password, users[1].Password);
            Assert.AreEqual(expected.Role, users[1].Role);
        }
    }
}
