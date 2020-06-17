using System;
using Moq;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using DAL.Entities;
using DAL.Repositories;
using DAL.Repositories.Interfaces;

namespace DAL.Tests
{
    [TestFixture]
    public class AffairRepositoryTest
    {
        private IRepository<Affair> _affairRepository;
        private Mock<DbSet<Affair>> _mockDbSet;
        private Mock<DbContext> _mockContext;

        [SetUp]
        public void SetUp()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<DbContext>()
                .Options;
            _mockContext = new Mock<DbContext>(opt);
            _mockDbSet = new Mock<DbSet<Affair>>();

            _mockContext
                .Setup(context =>
                    context.Set<Affair>(
                    ))
                .Returns(_mockDbSet.Object);

            _affairRepository = new Repository<Affair>(_mockContext.Object);
        }

        [Test]
        public void Repository_CalledInsertOneTime_InsertCorrect()
        {
            // Arrange
            var expectedAffair = new Mock<Affair>().Object;

            //Act
            _affairRepository.Insert(expectedAffair);

            // Assert
            _mockDbSet.Verify(
                dbSet => dbSet.Add(
                    expectedAffair
                ), Times.Once());
        }

        [Test]
        public void Repository_CalledRemove_RemovedCorrect()
        {
            // Arrange
            var id = Guid.NewGuid();

            var expectedAffair = new Affair { Id = id };
            _mockDbSet.Setup(mock => mock.Find(expectedAffair.Id)).Returns(expectedAffair);

            // Act

            var foundRegion = _affairRepository.GetById(id);
            _affairRepository.Remove(foundRegion);

            // Assert
            _mockDbSet.Verify(
                dbSet => dbSet.Find(
                    expectedAffair.Id
                ), Times.Once());

            _mockDbSet.Verify(
                dbSet => dbSet.Remove(
                    expectedAffair
                ), Times.Once());
        }
    }
}