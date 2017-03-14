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
			Dict.EN.file = "wordsEn.txt";
			Assert.IsTrue(Dict.EN.Contains("cat"));
			Assert.IsFalse(Dict.EN.Contains("blorffle"));
			Assert.IsFalse(Dict.EN.Contains("1"));
			Assert.AreEqual(109583, Dict.EN.Count);
		}

		[TestMethod]
		public void DictPrefixes()
		{
			Assert.IsTrue(Dict.EN.LeadsToWord("ca"));
			Assert.IsTrue(Dict.EN.LeadsToWord("cat"));
			Assert.IsFalse(Dict.EN.LeadsToWord("blor"));
		}

		[TestMethod]
		public void DictWordLength()
		{
			Assert.AreEqual(4030, new Dict.EN(4).SubCount);
		}
	}
}
