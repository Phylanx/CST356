
using FakeItEasy;
using Lab5_v3.Data.Entities;
using Lab5_v3.Models;
using Lab5_v3.Repositories;
using Lab5_v3.Services;
using NUnit.Framework;
using System.Collections.Generic;

namespace Lab5_v3.UnitTests
{
    [TestFixture]
    public class UnitTest_PCService
    {
        private IPCRepository _pcRep;


        [SetUp]
        public void TestMethod1()
        {
            _pcRep = A.Fake<IPCRepository>();
        }

        [Test]
        public void TotalStorage_0_Users()
        {
            A.CallTo(() => _pcRep.GetAllUserPCs(A<int>.Ignored)).Returns(
                new List<PC> ()
            );

            var pcService = new PCService(_pcRep);

            Assert.AreEqual(0, pcService.GetTotalStorage(1));
        }

        [Test]
        public void TotalStorage_1_User_0_GB()
        {
            var userPcs = new List<PC>();
            userPcs.Add(new PC { GB_Storage = 0 });

            A.CallTo(() => _pcRep.GetAllUserPCs(A<int>.Ignored)).Returns(
                userPcs
            );

            var pcService = new PCService(_pcRep);

            Assert.AreEqual(0, pcService.GetTotalStorage(1));
        }

        [Test]
        public void TotalStorage_1_User_100_GB()
        {
            var userPcs = new List<PC>();
            userPcs.Add(new PC { GB_Storage = 100 });

            A.CallTo(() => _pcRep.GetAllUserPCs(A<int>.Ignored)).Returns(
                userPcs
            );

            var pcService = new PCService(_pcRep);

            Assert.AreEqual(100, pcService.GetTotalStorage(1));
        }

        [Test]
        public void TotalStorage_2_Users_0_GB()
        {
            var userPcs = new List<PC>();
            userPcs.Add(new PC { GB_Storage = 0 });
            userPcs.Add(new PC { GB_Storage = 0 });

            A.CallTo(() => _pcRep.GetAllUserPCs(A<int>.Ignored)).Returns(
                userPcs
            );

            var pcService = new PCService(_pcRep);

            Assert.AreEqual(0, pcService.GetTotalStorage(1));
        }

        [Test]
        public void TotalStorage_2_Users_500_and_500_GB()
        {
            var userPcs = new List<PC>();
            userPcs.Add(new PC { GB_Storage = 500 });
            userPcs.Add(new PC { GB_Storage = 500 });

            A.CallTo(() => _pcRep.GetAllUserPCs(A<int>.Ignored)).Returns(
                userPcs
            );

            var pcService = new PCService(_pcRep);

            Assert.AreEqual(1000, pcService.GetTotalStorage(1));
        }

        [Test]
        public void TotalStorage_2_Users_50_and_5000_GB()
        {
            var userPcs = new List<PC>();
            userPcs.Add(new PC { GB_Storage = 50 });
            userPcs.Add(new PC { GB_Storage = 5000 });

            A.CallTo(() => _pcRep.GetAllUserPCs(A<int>.Ignored)).Returns(
                userPcs
            );

            var pcService = new PCService(_pcRep);

            Assert.AreEqual(5050, pcService.GetTotalStorage(1));
        }






    }
}
