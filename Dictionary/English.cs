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
						wordSet.Add(word.ToLowerInvariant());
				}
				return wordSet;
			}
		}

		static TrieNode leadsTo = null;
		static TrieNode LeadsTo {
			get {
				if (leadsTo == null)
				{
					leadsTo = new TrieNode();
					foreach (var word in WordSet)
					{
						leadsTo.Add(word);
					}
				}
				return leadsTo;
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
			return WordSet.Contains(word.ToLowerInvariant());
		}

		public static bool LeadsToWord(string prefix)
		{
			return LeadsTo.Contains(prefix);
		}
	}

	class TrieNode
	{
		public static char EndValue = '\0';
		IDictionary<char, TrieNode> children = new Dictionary<char, TrieNode>();
		internal void Add(string suffix)
		{
			string firstString = null;
			if (string.IsNullOrWhiteSpace(suffix)) {
				children.Add(EndValue, new TrieNode());
				return;
			}
			firstString = suffix?.Substring(0, 1);
			if (string.IsNullOrWhiteSpace(firstString)){ 
				children.Add(EndValue, new TrieNode());
				return;
			}

			TrieNode next;
			var firstChar = firstString.ToCharArray()[0];
			if (children.ContainsKey(firstChar))
				next = children[firstChar];
			else {
				next = new TrieNode();
				children.Add(firstChar, next);
			}
			if (suffix.Length > 1)
				next.Add(suffix.Substring(1));
		}

		internal bool Contains(string prefix)
		{
			var firstString = prefix?.Substring(0, 1);
			if (string.IsNullOrEmpty(prefix) || string.IsNullOrWhiteSpace(firstString))
				return children.ContainsKey(EndValue);

			var firstChar = firstString.ToCharArray()[0];
			var canProceed = children.ContainsKey(firstChar);
			if (canProceed && prefix.Length > 1)
				return children[firstChar].Contains(prefix.Substring(1));
			return canProceed;
		}
	}
}
