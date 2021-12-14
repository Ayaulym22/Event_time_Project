using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Event_time_Project.Tests.Controllers;
using System.Web.Mvc;
using Event_time_Project.Controllers;

namespace Event_time_Project.Tests.Controllers
{
    [TestClass]
    public class StoreControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
      
        [TestMethod]
        public void CalendarIndex() {
            // Arrange
            CalendarsController controller = new CalendarsController();

            // Act
            ViewResult result = controller.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void CategoryTaskIndex() {
            // Arrange
            Category_TaskController controller = new Category_TaskController();

            // Act
            ViewResult result = controller.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void EventsIndex() {

            // Arrange
            EventsController controller = new EventsController();

            // Act
            ViewResult result = controller.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void NotificationsIndex() {

            // Arrange
            NotificationsController controller = new NotificationsController();

            // Act
            ViewResult result = controller.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void OrganizationsIndex() {
            // Arrange
            OrganizationsController controller = new OrganizationsController();

            // Act
            ViewResult result = controller.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void UsersIndex() {
            // Arrange
            UsersController controller = new UsersController();
            
            // Act
            ViewResult result = controller.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

    }
}

