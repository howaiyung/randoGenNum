using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using randoGenNum.ViewModels;

namespace Tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void PosInt()
        {
            var glm = new RandomNumberViewModel();
            glm.RandNum1 = "4";
            glm.RandNum2 = "20";

            glm.CreateNumListCommand.Execute(null);

            Assert.IsTrue(glm.StringNumList != "", "This test should have generated the list");

        }
    }
}
