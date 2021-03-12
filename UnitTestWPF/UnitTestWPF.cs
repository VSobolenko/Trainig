using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using External_training_WPF;
using Moq;
using System.Text;

namespace UnitTestWPF
{
    [TestClass]
    public class UnitTestWPF
    {
        [TestMethod]
        public void TestOpenFile()
        {
            MainWindow mainWindow = new MainWindow();
            try
            {
                mainWindow.OpenFile();
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void TestSaveFile()
        {
            MainWindow mainWindow = new MainWindow();
            try
            {
                mainWindow.SaveFile();
            }
            catch
            {
                Assert.Fail();
            }
        }
    }
}
