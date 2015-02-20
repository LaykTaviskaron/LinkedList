using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCollections;

namespace MyCollectionsTests
{
	[TestClass]
	public class IEnumerableExtensionsTest
	{
		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void ToMyLinkedList_NullGiven_ArgumentNullExceptionThrown()
		{
			IEnumerableExtensions.ToMyLinkedList<string>(null);
		}

		[TestMethod]
		public void ToMyLinkedList_ValidInputGiven_NoExceptionThrown()
		{
			string[] input = { "AAA", "BBB", "CCC" };
			MyLinkedList<string> list = IEnumerableExtensions.ToMyLinkedList<string>(input);

			Assert.AreEqual(list.First.Value, input[0]);
			Assert.AreEqual(list.First.Next.Value, input[1]);
			Assert.AreEqual(list.Last.Value, input[2]);
		}
	}
}
