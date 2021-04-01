using Common.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Tests.ApplicationServicesTests
{
    [TestClass]
    public class UserIdentificationValidationHelperTests
    {
        [TestInitialize]
        public void Setup()
        {
        }

        [TestCleanup()]
        public async Task Cleanup()
        {
        }
        [TestMethod]
        public async Task MaturityUserIdentificationTest1()
        {
            //Arrange
            
            //Act
            bool isOver18 = UserIdentificationValidationHelper.MaturityValidateIdentificationNumberTest("1606000120092", new DateTime(2018,06,15));
            //Assert
            Assert.AreEqual(isOver18, false, "Not valid date");
        }
        
        [TestMethod]
        public async Task MaturityUserIdentificationTest2()
        {
            //Arrange

            //Act
            bool isOver18 = UserIdentificationValidationHelper.MaturityValidateIdentificationNumberTest("0207011120092", new DateTime(2029, 04, 12));
            //Assert
            Assert.AreEqual(isOver18, false, "Not valid date");
        }

        [TestMethod]
        public async Task MaturityUserIdentificationTest3()
        {
            //Arrange

            //Act
            bool isOver18 = UserIdentificationValidationHelper.MaturityValidateIdentificationNumberTest("2902004120092", new DateTime(2022, 02, 28));
            //Assert
            Assert.AreEqual(isOver18, true, "Not valid date");
        }

        [TestMethod]
        public async Task MaturityUserIdentificationTest4()
        {
            //Arrange

            //Act
            bool isOver18 = UserIdentificationValidationHelper.MaturityValidateIdentificationNumberTest("2902004120092", new DateTime(2022, 02, 27));
            //Assert
            Assert.AreEqual(isOver18, false, "Not valid date");
        }

    }
}
