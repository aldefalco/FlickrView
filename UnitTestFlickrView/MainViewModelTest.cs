using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WPFFlickrView.ViewModel;

namespace UnitTestFlickrView
{
    [TestClass]
    public class MainViewModelTest
    {
        [TestMethod]
        public void TestSearchForT1()
        {
            var s = new TestImageService();
            var viewModel = new MainViewModel(s);

            viewModel.TagsFilter = "T1";
            viewModel.Search.Execute(null);

            Assert.AreEqual("A", viewModel.Images[0].Title);
            Assert.AreEqual("C", viewModel.Images[1].Title);
        }

        [TestMethod]
        public void TestSearchForT2()
        {
            var s = new TestImageService();
            var viewModel = new MainViewModel(s);

            viewModel.TagsFilter = "T2";
            viewModel.Search.Execute(null);

            Assert.AreEqual("B", viewModel.Images[0].Title);
            Assert.AreEqual("C", viewModel.Images[1].Title);
        }

        [TestMethod]
        public void TestCurrentAndComments()
        {
            var s = new TestImageService();
            var viewModel = new MainViewModel(s);

            var current = new ImageViewModel();
            current.Id = "101";
            viewModel.ChangeCurrent.Execute(current);

            Assert.AreEqual(current, viewModel.Current);
            Assert.AreEqual("101", viewModel.Current.Comments[0].Id);
        }
    }
}
