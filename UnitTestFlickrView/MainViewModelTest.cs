using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WPFFlickrView.ViewModel;
using WPFFlickrView.Model;

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

            Assert.AreEqual("A", viewModel.Images[0].Model.Title);
            Assert.AreEqual("C", viewModel.Images[1].Model.Title);
        }

        [TestMethod]
        public void TestSearchForT2()
        {
            var s = new TestImageService();
            var viewModel = new MainViewModel(s);

            viewModel.TagsFilter = "T2";
            viewModel.Search.Execute(null);

            Assert.AreEqual("B", viewModel.Images[0].Model.Title);
            Assert.AreEqual("C", viewModel.Images[1].Model.Title);
        }

        [TestMethod]
        public void TestSearchForNoFiltration()
        {
            var s = new TestImageService();
            var viewModel = new MainViewModel(s);

            viewModel.Search.Execute(null);

            Assert.AreEqual("A", viewModel.Images[0].Model.Title);
            Assert.AreEqual("B", viewModel.Images[1].Model.Title);
        }

        [TestMethod]
        public void TestCurrentAndComments()
        {
            var s = new TestImageService();
            var viewModel = new MainViewModel(s);

            var current = new ImageViewModel(new Image { Id = "101" });
            
            viewModel.ChangeCurrent.Execute(current);

            Assert.AreEqual(current, viewModel.Current);
            Assert.AreEqual("101", viewModel.Current.Comments[0].Model.Id);
        }

        [TestMethod]
        public void TestPaging0()
        {
            var s = new TestLotImageService();
            var viewModel = new MainViewModel(s);

            viewModel.PageSize = 8;
            viewModel.Page = 0;

            viewModel.Search.Execute(null);

            Assert.AreEqual("P1", viewModel.Images[0].Model.Title);
            Assert.AreEqual("B", viewModel.Images[1].Model.Title);
            Assert.AreEqual(8, viewModel.Images.Count);
        }

        [TestMethod]
        public void TestPaging1()
        {
            var s = new TestLotImageService();
            var viewModel = new MainViewModel(s);

            viewModel.PageSize = 8;
            viewModel.Page = 1;

            viewModel.Search.Execute(null);

            Assert.AreEqual("P2", viewModel.Images[0].Model.Title);
            Assert.AreEqual("BB", viewModel.Images[1].Model.Title);
            Assert.AreEqual(6, viewModel.Images.Count);
        }
    }
}
