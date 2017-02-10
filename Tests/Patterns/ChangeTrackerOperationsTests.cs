using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Threading;
using NUnit.Framework;
using UMV.Reference.Patterns.Base.Models;
using UMV.Reference.Patterns.Operations;
using UMV.Reference.Patterns.Repositories.Interfaces;
using Moq;
using UMV.Reference.Patterns.Base.Enums;
using UMV.Reference.Patterns.Base.Interfaces;

namespace UMV.Reference.Tests.Patterns
{
    [TestFixture]
    public class ChangeTrackerOperationsTests
    {
        private string _testUser = "Test User";
        private Mock<ITrackChanges> _trackChangeMock;
        private Mock<IAuditRepository> _auditRepositoryMock;

        [SetUp]
        public void Setup()
        {
            _trackChangeMock = new Mock<ITrackChanges>();
            _auditRepositoryMock = new Mock<IAuditRepository>();
            Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(_testUser), new[] { "Administrator" });
        }

        [Test]
        public void ChangeTracker_OneOrMorePropertiesChanged_SetsObectStateUpdateDateAndUser()
        {
            // Arrange
            _auditRepositoryMock.Setup(x => x.Save(It.IsAny<ChangeState>()));
            _trackChangeMock.Setup(x => x.GetChangeState()).Returns(new ChangeState { ChangedProperties = new List<ChangedProperty> { new ChangedProperty() } });

            var changeTracker = new ChangeTracker<ITrackChanges>(_auditRepositoryMock.Object);

            //Act
            var result = changeTracker.Execute(_trackChangeMock.Object);

            //Assert
            Assert.IsNotNull(result);
            _trackChangeMock.VerifySet(x => x.ObjectState = ObjectState.Changed);
            _trackChangeMock.VerifySet(x => x.UpdateUser = _testUser);
            _trackChangeMock.VerifySet(x => x.UpdateDate = It.IsAny<DateTime>());
            _auditRepositoryMock.Verify(x => x.Save(It.IsAny<ChangeState>()), Times.Once);
        }

        [Test]
        public void ChangeTracker_NoPropertiesChangedNew_SetsObectStateUpdateDateAndUser()
        {
            // Arrange
            _auditRepositoryMock.Setup(x => x.Save(It.IsAny<ChangeState>()));
            _trackChangeMock.Setup(x => x.GetChangeState()).Returns(new ChangeState { ChangedProperties = new List<ChangedProperty>() });
            _trackChangeMock.Setup(x => x.ObjectState).Returns(ObjectState.FromDatabase);

            var changeTracker = new ChangeTracker<ITrackChanges>(_auditRepositoryMock.Object);

            //Act
            var result = changeTracker.Execute(_trackChangeMock.Object);

            //Assert
            Assert.IsNotNull(result);
            _trackChangeMock.VerifySet(x => x.ObjectState = ObjectState.NoChange);
            _auditRepositoryMock.Verify(x => x.Save(It.IsAny<ChangeState>()), Times.Once);
        }
    }
}
