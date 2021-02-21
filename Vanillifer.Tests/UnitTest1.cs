using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Vanillifer.Core;
using Vanillifer.Core.Skins;

namespace Vanillifer.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestSkins_Create()
        {
            var helper = new SkinsHelper(VanilliferCore.DefaultGamePath);
            Assert.IsNotNull(helper);
        }

        [TestMethod]
        public void TestSkins_List()
        {
            var helper = new SkinsHelper(VanilliferCore.DefaultGamePath);
            var list = helper.GetSkins();
            Assert.IsNotNull(list);
            Assert.AreNotEqual(list.Count, 0);

            Assert.IsTrue(list.TrueForAll(i => i.Picture != null));
        }

        [TestMethod]
        public void TestSkins_RemoveAllSkin()
        {
            var helper = new SkinsHelper(VanilliferCore.DefaultGamePath);
            var list = helper.GetSkins();

            foreach(var skin in list)
            {
                helper.RemoveSkin(skin);
            }

            var path = @"C:\games\World_of_Tanks\res_mods\1.11.1.3\scripts\item_defs\customization\styles\list.xml";
            var xml = helper.ToXml();

            System.IO.File.WriteAllText(path, xml);
        }
    }
}
