namespace PVT.Q1._2017.Shop.Tests
{
    using System;
    using global::Moq;
    using global::Shop.BLL.Services;
    using global::Shop.BLL.Services.Infrastructure;
    using global::Shop.Common.Models;
    using global::Shop.DAL.Infrastruture;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using System.Linq.Expressions;
    using global::Shop.BLL.Exceptions;
    using System.Collections.Generic;
    using global::Shop.Infrastructure.Models;

    [TestClass]
    public class UserServiceTests
    {
        private readonly IRepositoryFactory _factory;

        private readonly IUserService _service;

        public UserServiceTests()
        {
            _factory = new RepositoryFactoryMoq();

            _service = new UserService(_factory);

            using (var repository = _factory.GetCurrencyRepository())
            {
                repository.AddOrUpdate(new Currency { Id = 1, ShortName = "USD", Code = 840 });
                repository.SaveChanges();
            }

            using (var repository = _factory.GetPriceLevelRepository())
            {
                repository.AddOrUpdate(new PriceLevel { Id = 1, Name = "Default Price Level" });
                repository.SaveChanges();
            }
        }

        [TestMethod]
        public void RegisterUser_UserInput_ReturnTrue()
        {
            User user = new User
            {
                FirstName = "Abziz",
                LastName = "Anand",
                Login = "OilMagnat",
                Sex = "W",
                Email = "blablabla@gmail.com",
                Password = "12345",
                BirthDate = DateTime.Now.AddYears(-30),
                PhoneNumber = "+37529 123-56-78",
                CountryId = 1
            };

            var registered = _service.RegisterUser(user);
            Assert.IsTrue(registered);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), AllowDerivedTypes = true)]
        public void RegisterUser_NullInput()
        {
            _service.RegisterUser(null);
        }

        [TestMethod]
        public void IsUserUnique_NullOrEmptyInput()
        {
            var resultNull = _service.IsUserExist(null);
            var resultEmpty = _service.IsUserExist("");

            Assert.IsFalse(resultNull);
            Assert.IsFalse(resultEmpty);
        }

        [TestMethod]
        public void IsUserUnique_EmailExist_ReturnTrue()
        {
            string email = "test@gmail.com";
            Mock.Get(_factory.GetUserRepository()).Setup(m => m.Exist(It.IsAny<Expression<Func<User, bool>>>())).Returns(true);

            var result = _service.IsUserExist(email);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsUserUnique_LoginExist_ReturnTrue()
        {
            string login = "Test";
            Mock.Get(_factory.GetUserRepository()).Setup(m => m.Exist(It.IsAny<Expression<Func<User, bool>>>())).Returns(true);

            var result = _service.IsUserExist(login);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsUserUnique_EmailAndLoginNotExist_ReturnFalse()
        {
            string email = "test@gmail.com";
            string login = "Test";

            Mock.Get(_factory.GetUserRepository())
                .Setup(m => m.FirstOrDefault(It.IsAny<Expression<Func<User, bool>>>())).Returns((User)null);

            var resultEmail = _service.IsUserExist(email);
            var resultLogin = _service.IsUserExist(login);

            Assert.IsFalse(resultEmail);
            Assert.IsFalse(resultLogin);

        }

        [TestMethod]
        [ExpectedException(typeof(UserValidationException))]
        public void GetEmailByUserIdentity_NullInput()
        {
            _service.GetEmailByUserIdentity(null);
        }

        [TestMethod]
        public void GetEmailByUserIdentity_RealInput()
        {
            string email = "test@gmail.com";
            string login = "test";

            Mock.Get(_factory.GetUserRepository())
                .Setup(m => m.FirstOrDefault(It.IsAny<Expression<Func<User, bool>>>()))
                .Returns(new User { Email = email, Login = login });

            var resultEmail = _service.GetEmailByUserIdentity(email);
            var resultLogin = _service.GetEmailByUserIdentity(login);

            Assert.IsTrue(resultEmail.Equals(email, StringComparison.OrdinalIgnoreCase));
            Assert.IsTrue(resultLogin.Equals(email, StringComparison.OrdinalIgnoreCase));
        }

        [TestMethod]
        [ExpectedException(typeof(UserValidationException))]
        public void GetIdOfLogin_NullInput()
        {
            _service.GetIdOflogin(null);
        }

        [TestMethod]
        public void GetIdOfLogin_RealInput()
        {
            string email = "test@gmail.com";
            string login = "test";
            int id = 1;

            Mock.Get(_factory.GetUserRepository())
                .Setup(m => m.FirstOrDefault(It.IsAny<Expression<Func<User, bool>>>()))
                .Returns(new User { Email = email, Login = login, Id = id });

            var loginId = _service.GetIdOflogin(login);
            var emailId = _service.GetIdOflogin(email);

            Assert.IsTrue(id == loginId);
            Assert.IsTrue(id == emailId);
        }


        [TestMethod]
        [ExpectedException(typeof(UserValidationException))]
        public void GetIdOfLogin_LoginAndEmailNotExist()
        {
            string email = "test@gmail.com";
            string login = "test";

            Mock.Get(_factory.GetUserRepository())
                .Setup(m => m.FirstOrDefault(It.IsAny<Expression<Func<User, bool>>>()))
                .Returns((User)null);

            var loginId = _service.GetIdOflogin(login);
            var emailId = _service.GetIdOflogin(email);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UpdatePersonal_UserNullInput()
        {
            _service.UpdatePersonal(null, 1);
        }

        [TestMethod]
        public void UpdatePersonal_UserRealInput()
        {
            var newUser = new User
            {
                FirstName = "Ivan",
                LastName = "Ivanov",
                Sex = "M",
                BirthDate = DateTime.Now,
                CountryId = 1,
                PhoneNumber = "+37529 123-56-78"
            };

            var user = new User
            {
                FirstName = "Abziz",
                LastName = "Anand",
                Sex = "W",
                BirthDate = DateTime.Now.AddYears(-30),
                PhoneNumber = "+37529 123-56-78",
                CountryId = 1
            };

            Mock.Get(_factory.GetUserRepository())
               .Setup(m => m.GetById(It.IsAny<int>()))
               .Returns(user);

            var result = _service.UpdatePersonal(newUser, 1);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void UpdatePassword_NullOrEmpryPassword()
        {
            var nullResult = _service.UpdatePassword(1, null);
            var emptyResult = _service.UpdatePassword(1, string.Empty);

            Assert.IsFalse(nullResult);
            Assert.IsFalse(emptyResult);
        }

        [TestMethod]
        public void UpdatePassword_RealPasswordInput()
        {
            var user = new User
            {
                Id=1,
                Password = "testuser1!",
            };
            var newPassword = "1!testuser";

            Mock.Get(_factory.GetUserRepository())
                .Setup(m => m.GetById(It.IsAny<int>()))
                .Returns(user);

            var result = _service.UpdatePassword(1, newPassword);

            Assert.IsTrue(result);

        }

        [TestMethod]
        public void UpdatePassword_NewOrOldPasswordIsNullOrEmpty()
        {
            string password = "testpassword1!";

            var reultNewNull = _service.UpdatePassword(1, null, password);
            var resultNewEmpty = _service.UpdatePassword(1, string.Empty, password);
            var resultOldNull = _service.UpdatePassword(1, password, null);
            var resultOldEmpty = _service.UpdatePassword(1, password, string.Empty);

            Assert.IsFalse(reultNewNull);
            Assert.IsFalse(resultNewEmpty);
            Assert.IsFalse(resultOldNull);
            Assert.IsFalse(resultOldEmpty);
        }

        [TestMethod]
        [ExpectedException(typeof(UserValidationException))]
        public void UpdatePassword_PasswordNotConfirm()
        {
            var oldPassword = "testpass1!";
            var newPassword = "1!testpass";
            var currentPassword = "userpass1!";

            var user = new User
            {
                Password = currentPassword
            };

            Mock.Get(_factory.GetUserRepository())
               .Setup(m => m.GetById(It.IsAny<int>()))
               .Returns(user);

            _service.UpdatePassword(1, newPassword, oldPassword);
        }

        [TestMethod]
        [ExpectedException(typeof(UserValidationException))]
        public void UpdatePassword_PasswordConfirm()
        {
            var oldPassword = "userpass1!";
            var newPassword = "1!testpass";
            var currentPassword = "userpass1!";

            var user = new User
            {
                Password = currentPassword
            };

            Mock.Get(_factory.GetUserRepository())
               .Setup(m => m.GetById(It.IsAny<int>()))
               .Returns(user);

            var result = _service.UpdatePassword(1, newPassword, oldPassword);

            Assert.IsTrue(result);

        }

        [TestMethod]
        public void UpdateLogin_UserIdentityOrNewLoginNullOrEmptyInput()
        {
            string newLogin = "login";
            string userIdentity = "test@mail.com";

            var reultUserNull = _service.UpdateLogin(null, newLogin);
            var resultUserEmpty = _service.UpdateLogin(string.Empty, newLogin);
            var resultLoginNull = _service.UpdateLogin(userIdentity, null);
            var resultLoginEmpty = _service.UpdateLogin(userIdentity, string.Empty);

            Assert.IsFalse(reultUserNull);
            Assert.IsFalse(resultUserEmpty);
            Assert.IsFalse(resultLoginNull);
            Assert.IsFalse(resultLoginEmpty);
        }

        [TestMethod]
        public void UpdateLogin_RealInput()
        {
            string newLogin = "login";
            string userIdentity = "test@mail.com";
            var user = new User
            {
                Login = "login89"
            };

            Mock.Get(_factory.GetUserRepository())
                 .Setup(m => m.FirstOrDefault(It.IsAny<Expression<Func<User, bool>>>()))
                .Returns(user);

            var result = _service.UpdateLogin(userIdentity, newLogin);

            Assert.IsTrue(result);

        }

        [TestMethod]
        public void SoftDeleted_UserNotFound()
        {
            Mock.Get(_factory.GetUserRepository())
            .Setup(m => m.GetById(It.IsAny<int>()))
            .Returns((User)null);

            var result = _service.SoftDelete(1);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void SoftDeleted_UserIsFound()
        {
            Mock.Get(_factory.GetUserRepository())
                .Setup(m => m.GetById(It.IsAny<int>()))
                .Returns(new User());

            var result = _service.SoftDelete(1);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetLastNameMatchingData_NullOrEmptyInput()
        {
            var usersList = new List<User> {
                new User { LastName = "Stalone"},
                new User { LastName = "Statham"},
                new User { LastName = "Johnson"},
                new User { LastName = "Nolan"} };

            Mock.Get(_factory.GetUserRepository())
                .Setup(m => m.GetAll())
                .Returns(usersList);

            var nullResult = _service.GetLastNameMatchingData(null);
            var emptyResult = _service.GetLastNameMatchingData(string.Empty);

            Assert.IsNull(nullResult);
            Assert.IsNull(emptyResult);
        }

        [TestMethod]
        public void GetLastNameMatchingData_RealInput()
        {
            var usersList = new List<User>
            {
                new User { LastName = "Stalone"},
                new User { LastName = "Statham"},
                new User { LastName = "Johnson"},
                new User { LastName = "Nolan"}
            };

            var expected = new List<User>
            {
                new User { LastName = "Stalone"},
                new User { LastName = "Statham"}

            };

            string pattern = "sta";

            Mock.Get(_factory.GetUserRepository())
                .Setup(m => m.GetAll())
                .Returns(usersList);

            var result = _service.GetLastNameMatchingData(pattern);

            CollectionAssert.Equals(result, expected);
        }

        [TestMethod]
        public void GetUsersCount_RealCountExpected()
        {
            int count = 5;
            Mock.Get(_factory.GetUserRepository())
              .Setup(m => m.Count(null))
              .Returns(count);

            var result = _service.GetUsersCount();

            Assert.IsTrue(result.Equals(count));
        }

        [TestMethod]
        public void GetDataPerPage_RealInput_CountEquals()
        {
            var usersList = new List<User>
            {
                new User { LastName = "Stalone"},
                new User { LastName = "Statham"},
                new User { LastName = "Johnson"},
                new User { LastName = "Nolan"},
                new User { LastName = "Smith"},
                new User { LastName = "Williams"},
                new User { LastName = "Brown"},
                new User { LastName = "Davis"},
                new User { LastName = "Miller" },
                new User { LastName = "Wilson"},
                new User { LastName = "Moore"}
            };

            int page = 2, count = 4;

            Mock.Get(_factory.GetUserRepository())
                .Setup(m => m.GetAll(It.IsAny<int>(), It.IsNotNull<int>(), u => u.Country))
                .Returns(() => new PagedResult<User>(usersList.GetRange(0, count), count, page, usersList.Count));

            var result = _service.GetDataPerPage(page, count);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Items.Count.Equals(count));
        }

        [TestMethod]
        public void GetDataPerPage_RealInput_CollectionEquals()
        {
            var usersList = new List<User>
            {
                new User { LastName = "Stalone"},
                new User { LastName = "Statham"},
                new User { LastName = "Johnson"},
                new User { LastName = "Nolan"},
                new User { LastName = "Smith"},
                new User { LastName = "Williams"},
                new User { LastName = "Brown"},
                new User { LastName = "Davis"},
                new User { LastName = "Miller" },
                new User { LastName = "Wilson"},
                new User { LastName = "Moore"}
            };

            int page = 2, count = 4;

            var expected = new List<User>
            {
                new User { LastName = "Smith"},
                new User { LastName = "Williams"},
                new User { LastName = "Brown"},
                new User { LastName = "Davis"}
            };

            Mock.Get(_factory.GetUserRepository())
             .Setup(m => m.GetAll(It.IsAny<int>(), It.IsNotNull<int>(), u => u.Country))
             .Returns(() => new PagedResult<User>(expected, count, page, usersList.Count));

            var result = _service.GetDataPerPage(page, count);
            
            Assert.IsNotNull(result);
            CollectionAssert.Equals(result.Items, expected);
        }
    }
}
