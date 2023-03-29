using BusinessLogic.LogicBusiness.User;
using DataAccess.Models;
using DataAccess.Repositories;
using DataAccess.Repositories.User;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace IntegerTestsBusinessLogic.UserTests
{
    [TestClass]
    public class UserLogicTests
    {
        UserLogic uLogic;
        string connectionString = ConnectionString.connectionStringFake;

        [TestInitialize]
        public void Initialize()
        {
            uLogic = new UserLogic(new UserRepository(connectionString));
        }

        [TestMethod]
        public void AddUserTest()
        {
            long result = uLogic.AddUser("TestUser", "1111", "testRole");
            long expected = uLogic.GetUser(result).ID;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void DeleteUserTest()
        {
            long id = uLogic.AddUser("TestUser", "1111", "testRole");
            uLogic.DeleteUser(id);

            Assert.IsNull(uLogic.GetUser(id));
        }

        [TestMethod]
        public void UpdateUserTest()
        {
            long id = uLogic.AddUser("TestUser", "1111", "testRole");
            UserModel expected = new UserModel(id, "Puziks", "123321", "Admin");
            uLogic.UpdateUser(expected);
            UserModel result = uLogic.GetUser(id);

            Assert.AreEqual(expected.ID, result.ID);
            Assert.AreEqual(expected.Login, result.Login);
            Assert.AreEqual(expected.Password, result.Password);
            Assert.AreEqual(expected.Role, result.Role);
        }

        [TestMethod]
        public void GetUsersTest()
        {
            List<UserModel> expected = uLogic.GetUsers();
            expected.Add(uLogic.GetUser(uLogic.AddUser("Vasja", "54", "User")));

            List<UserModel> result = uLogic.GetUsers();

            for (int i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(expected[i].ID, result[i].ID);
                Assert.AreEqual(expected[i].Login, result[i].Login);
                Assert.AreEqual(expected[i].Password, result[i].Password);
                Assert.AreEqual(expected[i].Role, result[i].Role);
            }
        }

        [TestMethod]
        public void GetUserTest()
        {
            long id = uLogic.AddUser("TestUser", "1111", "testRole");
            UserModel expected = new UserModel(id, "TestUser", "1111", "testRole");
            UserModel result = uLogic.GetUser(id);

            Assert.AreEqual(expected.ID, result.ID);
            Assert.AreEqual(expected.Login, result.Login);
            Assert.AreEqual(expected.Password, result.Password);
            Assert.AreEqual(expected.Role, result.Role);
        }
    }
}
