using CafeGBC;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MenuTests
{
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddingToDirectoryTest()
        {
            Menu item = new Menu();
            item.Name = "Tofu";
            item.ItemNumber = 2;
            item.Description = "soy bean";
            item.Ingredients = "soy bean";
            item.Price = 3.21;

            MenuRepository repo = new MenuRepository();
            bool wasAdded = repo.AddItemToDirecotry(item);
            Assert.IsTrue(wasAdded);

        }
    }
}
