using System;
using System.Collections.Generic;
using System.IO;

namespace Dict
{
	public class EN
	{
		public static string file = "ENWords.csv";
		static string[] source = null;
		static string[] Source {
			get {
				if (source == null)
					source = File.ReadAllLines(file);
				return source;
			}
		}

		static HashSet<string> wordSet = null;
		static ISet<string> WordSet {
			get {
				if (wordSet == null)
				{
					wordSet = new HashSet<string>();
					foreach (var word in Source)
						wordSet.Add(word);
				}
				return wordSet;
			}
		}
		public static int Count { get { return WordSet.Count; } }

		public readonly int SubCount;
		public EN(int wordLength)
		{
			throw new NotImplementedException();
		}

		public bool SubDictContains(string word)
		{
			throw new NotImplementedException();
		}

		public bool SubDictLeadsToWord(string prefix)
		{
			throw new NotImplementedException();
		}

		public static bool Contains(string word)
		{
			return WordSet.Contains(word);
		}

		public static bool LeadsToWord(string prefix)
		{
			throw new NotImplementedException();
		}

		
	}
}
