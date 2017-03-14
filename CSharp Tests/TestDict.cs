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
		public void DictWordCount()
		{
			Assert.AreEqual(3130, new Dict.EN(4).SubCount);
		}
	}
}
