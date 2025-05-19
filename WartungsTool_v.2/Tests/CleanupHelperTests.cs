using Microsoft.VisualStudio.TestTools.UnitTesting;
using WartungsTool_v._2.Model;
using WartungsTool_v._2.Services;
using WartungsTool_v._2.ViewModel;

[TestClass]
public class CleanupHelperTests
{
    [TestMethod]
    public void CleanPath_InvalidPath_ReturnsEmptyList()
    {
        var result = CleanupHelper.CleanPath("C:\\Invalid\\Path");
        Assert.AreEqual(0, result.Count);
    }
}

[TestClass]
public class MainViewModelTests
{
    [TestMethod]
    public void AddPath_AddsUniquePath()
    {
        var vm = new MainViewModel();
        var originalCount = vm.PathsToClean.Count;
        vm.PathsToClean.Add(new PathEntry { Path = "C:\\Temp" });
        Assert.IsTrue(vm.PathsToClean.Count > originalCount);
    }
}