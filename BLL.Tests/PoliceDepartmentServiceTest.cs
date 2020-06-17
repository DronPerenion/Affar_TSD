using System;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Services;
using BLL.Services.Interfaces;
using CCL.Security;
using CCL.Security.Identity;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using DAL.UnitOfWork.Interfaces;
using Moq;
using NUnit.Framework;

namespace BLL.Tests
{
    public class PoliceDepartmentServiceTest
    {
        private Mock<IUnitOfWork> _mockUnitOfWork;

        [SetUp]
        public void Setup()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
        }

        [Test]
        public void PoliceDepartmentServiceCtor_NullConstructionParams_ExceptionThrows()
        {
            // Arrange

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => new PoliceDepartmentService(null));
        }

        [Test]
        public void PoliceDepartmentServiceRemoveRegion_UserIsUser_ThrowMethodAccessException()
        {
            // Arrange
            var user = new User(Guid.NewGuid(), Guid.NewGuid().ToString());
            Authorization.SetUser(user);

            IPoliceDepartmentService policeDepartmentService = new PoliceDepartmentService(_mockUnitOfWork.Object);

            // Act

            // Assert
            Assert.ThrowsAsync<MethodAccessException>(() => policeDepartmentService.RemovePoliceDepartmentAsync(Guid.NewGuid()));
        }

        [Test]
        public async Task GetPoliceDepartment_PoliceDepartmentFromDAL_CorrectMappingToPoliceDepartmentDTO()
        {
            // Arrange
            var user = new Administrator(Guid.NewGuid(), Guid.NewGuid().ToString());
            Authorization.SetUser(user);

            var itemId = Guid.NewGuid();
            var policeDepartmentService = GetPoliceDepartmentService(itemId);

            // Act
            var policeDepartment = await policeDepartmentService.GetPoliceDepartmentAsync(itemId);

            // Assert
            Assert.True(
                policeDepartment.Id == itemId
                && policeDepartment.Name == "testName"
                && policeDepartment.Employees == 10
            );
        }

        private IPoliceDepartmentService GetPoliceDepartmentService(Guid itemId)
        {
            var mockContext = new Mock<IUnitOfWork>();
            var expectedPoliceDepartment = new PoliceDepartment()
            {
                Id = itemId,
                Name = "testName",
                Employees = 10
            };
            var mockDbSet = new Mock<IRepository<PoliceDepartment>>();

            mockDbSet.Setup(mock => mock.GetByIdAsync(itemId)).ReturnsAsync(expectedPoliceDepartment);

            mockContext
                .Setup(context =>
                    context.Repository<PoliceDepartment>())
                .Returns(mockDbSet.Object);
            mockContext.Setup(mock => mock.GetByIdAsync<PoliceDepartment>(itemId)).ReturnsAsync(expectedPoliceDepartment);

            IPoliceDepartmentService policeDepartmentService = new PoliceDepartmentService(mockContext.Object);

            return policeDepartmentService;
        }

    }
}