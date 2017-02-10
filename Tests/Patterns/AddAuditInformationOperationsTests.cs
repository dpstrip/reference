using System;
using System.Security.Principal;
using System.Threading;
using NUnit.Framework;
using UMV.Reference.Patterns.Base.Enums;
using UMV.Reference.Patterns.Base.Models;
using UMV.Reference.Patterns.Operations;

namespace UMV.Reference.Tests.Patterns
{
    [TestFixture]
    public class AddAuditInformationOperationsTests
    {
        private string _testUser = "Test User";
        private AuditableTest _auditable;
        private AddAuditInformation<AuditableTest> _addAuditInformationOperation;

        [SetUp]
        public void Setup()
        {
            _auditable = new AuditableTest();
            _addAuditInformationOperation = new AddAuditInformation<AuditableTest>();
            Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(_testUser), new[] { "Administrator" });
        }

        [Test]
        public void AddAuditInformation_IdIsZero_SetsObectStateCreateDateAndUser()
        {
            // Arrange
            // Assumption New Object

            //Act
            _auditable = _addAuditInformationOperation.Execute(_auditable);

            //Assert
            Assert.IsTrue(_auditable.Id == 0);
            Assert.IsTrue(_auditable.UpdateDate == null);
            Assert.IsTrue(_auditable.CreateDate != DateTime.MinValue);
            Assert.IsTrue(string.IsNullOrEmpty(_auditable.UpdateUser));
            Assert.IsTrue(_auditable.CreateUser == _testUser);
            Assert.IsTrue(_auditable.ObjectState == ObjectState.New);
        }


        [Test]
        public void AddAuditInformation_IdIsNotZero_SetsObectStateUpdateDateAndUser()
        {
            // Arrange
            _auditable.Id = 1;

            //Act
            _auditable = _addAuditInformationOperation.Execute(_auditable);

            //Assert
            Assert.IsTrue(_auditable.Id == 1);
            Assert.IsTrue(_auditable.UpdateDate != null);
            Assert.IsTrue(_auditable.CreateDate == DateTime.MinValue);
            Assert.IsTrue(_auditable.UpdateUser == _testUser);
            Assert.IsTrue(string.IsNullOrEmpty(_auditable.CreateUser));
            Assert.IsTrue(_auditable.ObjectState == ObjectState.None);
        }

        [Test]
        public void AddAuditInformation_IdIsNotZeroAndMarkdFromDatabase_SetsUpdateDateAndUser()
        {
            // Arrange
            _auditable.Id = 1;
            _auditable.ObjectState = ObjectState.FromDatabase;

            //Act
            _auditable = _addAuditInformationOperation.Execute(_auditable);

            //Assert
            Assert.IsTrue(_auditable.Id == 1);
            Assert.IsTrue(_auditable.UpdateDate != null);
            Assert.IsTrue(_auditable.CreateDate == DateTime.MinValue);
            Assert.IsTrue(_auditable.UpdateUser == _testUser);
            Assert.IsTrue(string.IsNullOrEmpty(_auditable.CreateUser));
            Assert.IsTrue(_auditable.ObjectState == ObjectState.FromDatabase);
        }
    }

    public class AuditableTest : Auditible
    { }
}
