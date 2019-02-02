using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using randoGenNum.ViewModels;

namespace randoGenNum.UnitTest
{
    [TestClass]
    public class RandomNumberUnitTest
    {
        [TestMethod]
        public void RandNumListTest()
        {
            var vm = new RandomNumberViewModel();
            vm.RandNum1 = "4";
            vm.RandNum2 = "20";

            vm.CreateNumListCommand.Execute(null);

            Assert.IsTrue(vm.StringNumList != "","This should have generated a string integer list");
        }
    }
}
