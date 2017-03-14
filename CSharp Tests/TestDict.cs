using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_Tests
{
	[TestClass]
	public class TestDict
	{
		[TestMethod]
		public void DictContainsWords()
		{
			Assert.IsTrue(Dict.EN.Contains("cat"));
			Assert.IsFalse(Dict.EN.Contains("blorffle"));
			Assert.IsFalse(Dict.EN.Contains("1"));
			Assert.IsTrue(Dict.EN.Contains("catamaran"));
			Assert.AreEqual(109582, Dict.EN.Count);
		}

		[TestMethod]
		public void DictPrefixes()
		{
			Assert.IsTrue(Dict.EN.LeadsToWord("c"), "'c' must be allowed");
			Assert.IsTrue(Dict.EN.LeadsToWord("ca"), "'ca' is not a word but should be found");
			Assert.IsTrue(Dict.EN.LeadsToWord("cat"), "'cat's are important");
			Assert.IsTrue(Dict.EN.LeadsToWord("catamaran"), "'catamaran' is a long word");
			Assert.IsFalse(Dict.EN.LeadsToWord("blor"), "'blor' is nonsense");
		}

		[TestMethod]
		public void DictWordCount()
		{
			Assert.AreEqual(0, new Dict.EN(0).SubCount);
			Assert.AreEqual(1, new Dict.EN(1).SubCount);
			Assert.AreEqual(140, new Dict.EN(2).SubCount);
			Assert.AreEqual(853, new Dict.EN(3).SubCount);
			Assert.AreEqual(3130, new Dict.EN(4).SubCount);
			Assert.AreEqual(6919, new Dict.EN(5).SubCount);
			Assert.AreEqual(11492, new Dict.EN(6).SubCount);
			Assert.AreEqual(16882, new Dict.EN(7).SubCount);
			Assert.AreEqual(19461, new Dict.EN(8).SubCount);
			Assert.AreEqual(16693, new Dict.EN(9).SubCount);
			Assert.AreEqual(11882, new Dict.EN(10).SubCount);
			Assert.AreEqual(8374, new Dict.EN(11).SubCount);
			Assert.AreEqual(5812, new Dict.EN(12).SubCount);
			Assert.AreEqual(3676, new Dict.EN(13).SubCount);
			Assert.AreEqual(2102, new Dict.EN(14).SubCount);
			Assert.AreEqual(1159, new Dict.EN(15).SubCount);
			Assert.AreEqual(583, new Dict.EN(16).SubCount);
			Assert.AreEqual(229, new Dict.EN(17).SubCount);
			Assert.AreEqual(107, new Dict.EN(18).SubCount);
			Assert.AreEqual(39, new Dict.EN(19).SubCount);
			Assert.AreEqual(29, new Dict.EN(20).SubCount);
		}

		[TestMethod]
		public void DictSubContains()
		{
			Assert.IsTrue(new Dict.EN(9).SubDictContains("catamaran"));
			Assert.IsFalse(new Dict.EN(10).SubDictContains("catamaran"));
		}

		[TestMethod]
		public void DictSubPrefix()
		{
			var nineDict = new Dict.EN(9);
			Assert.IsTrue(nineDict.SubDictLeadsToWord("catamara"), "minus 1 must exist");
			Assert.IsFalse(nineDict.SubDictLeadsToWord("catamaran"), "word leads to no word");
			var tenDict = new Dict.EN(10);
			Assert.IsTrue(tenDict.SubDictLeadsToWord("catamaran"), "catamaran leads to catamarans");
			Assert.IsFalse(tenDict.SubDictLeadsToWord("catamarans"), "catamarans leads nowhere");
			var elevenDict = new Dict.EN(11);
			Assert.IsFalse(elevenDict.SubDictLeadsToWord("catamaran"), "word9 leads to no word");
			Assert.IsFalse(elevenDict.SubDictLeadsToWord("catamarans"), "word10 leads to no word");
			var twelveDict = new Dict.EN(12);
			Assert.IsFalse(twelveDict.SubDictLeadsToWord("catamaran"), "catamaran leads to no word");


		}
	}
}
