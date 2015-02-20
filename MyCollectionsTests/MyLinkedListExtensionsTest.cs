using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCollections;

namespace MyCollectionsTests
{
	[TestClass]
	public class MyLinkedListExtensionsTest
	{
		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void First_ListIsNull_ArgumentNullExceptionThrown()
		{
			MyLinkedListExtensions.First<int>(null, x => x < 2);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void FirstOrDefault_ListIsNull_ArgumentNullExceptionThrown()
		{
			MyLinkedListExtensions.FirstOrDefault<int>(null, x => x < 2);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void Count_ListIsNull_ArgumentNullExceptionThrown()
		{
			MyLinkedListExtensions.Count<int>(null, x => x < 2);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void All_ListIsNull_ArgumentNullExceptionThrown()
		{
			MyLinkedListExtensions.All<int>(null, x => x < 2);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void Any_ListIsNull_ArgumentNullExceptionThrown()
		{
			MyLinkedListExtensions.Any<int>(null, x => x < 2);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void Concat_ListIsNull_ArgumentNullExceptionThrown()
		{
			MyLinkedListExtensions.Concat<int>(null, new MyLinkedList<int>()).ToMyLinkedList();
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void Replace_ListIsNull_ArgumentNullExceptionThrown()
		{
			MyLinkedListExtensions.Replace<int>(null, 0, x => x < 2);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void ReplaceAll_ListIsNull_ArgumentNullExceptionThrown()
		{
			MyLinkedListExtensions.ReplaceAll<int>(null, 0, x => x < 2);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void Reverse_ListIsNull_ArgumentNullExceptionThrown()
		{
			MyLinkedListExtensions.Reverse<int>(null);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void Select_ListIsNull_ArgumentNullExceptionThrown()
		{
			MyLinkedListExtensions.Select<int, int>(null, x => x * 2);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void Single_ListIsNull_ArgumentNullExceptionThrown()
		{
			MyLinkedListExtensions.Single<int>(null, x => x < 2);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void SingleOrDefault_ListIsNull_ArgumentNullExceptionThrown()
		{
			MyLinkedListExtensions.SingleOrDefault<int>(null, x => x < 2);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void SkipWhile_ListIsNull_ArgumentNullExceptionThrown()
		{
			MyLinkedListExtensions.SkipWhile<int>(null, x => x < 2);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void TakeWhile_ListIsNull_ArgumentNullExceptionThrown()
		{
			MyLinkedListExtensions.TakeWhile<int>(null, x => x < 2);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void Union_ListIsNull_ArgumentNullExceptionThrown()
		{
			MyLinkedListExtensions.Union<int>(null, new MyLinkedList<int>());
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void Where_ListIsNull_ArgumentNullExceptionThrown()
		{
			MyLinkedListExtensions.Where<int>(null, x => x < 2);
		}

		[TestMethod]
		public void SkipWhile_ValidDataGiven_NoExceptionThrown()
		{
			MyLinkedList<int> list = new MyLinkedList<int>();
			list.AddLast(1);
			list.AddLast(2);
			list.AddLast(3);
			list.AddLast(4);
			list.AddLast(5);

			var result = list.SkipWhile<int>(x => x < 3).ToMyLinkedList();

			Assert.AreEqual(result.First.Value, 3);
			Assert.AreEqual(result.First.Next.Value, 4);
			Assert.AreEqual(result.Last.Value, 5);
		}

		[TestMethod]
		public void SkipWhile_SkippingAllItems_NoExceptionThrown()
		{
			MyLinkedList<int> list = new MyLinkedList<int>();
			list.AddLast(1);
			list.AddLast(2);
			list.AddLast(3);
			list.AddLast(4);
			list.AddLast(5);

			var result = list.SkipWhile<int>(x => x < 10).ToMyLinkedList();

			Assert.AreEqual(result.Count, 0);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void SkipWhile_PredicateIsNull_ArgumentNullExceptionThrown()
		{
			MyLinkedList<int> list = new MyLinkedList<int>();
			list.SkipWhile<int>(null);
		}

		[TestMethod]
		public void TakeWhile_ValidDataGiven_NoExceptionThrown()
		{
			MyLinkedList<int> list = new MyLinkedList<int>();
			list.AddLast(1);
			list.AddLast(2);
			list.AddLast(3);
			list.AddLast(4);
			list.AddLast(5);

			var result = list.TakeWhile<int>(x => x < 3).ToMyLinkedList();

			Assert.AreEqual(result.First.Value, 1);
			Assert.AreEqual(result.Last.Value, 2);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void TakeWhile_PredicateIsNull_ArgumentNullExceptionThrown()
		{
			MyLinkedList<int> list = new MyLinkedList<int>();
			list.TakeWhile<int>(null);
		}

		[TestMethod]
		public void Union_ValidDataGiven_NoExceptionThrown()
		{
			MyLinkedList<int> list1 = new MyLinkedList<int>();
			list1.AddLast(1);
			list1.AddLast(2);
			list1.AddLast(2);
			list1.AddLast(2);
			list1.AddLast(3);

			MyLinkedList<int> list2 = new MyLinkedList<int>();
			list2.AddLast(1);
			list2.AddLast(3);
			list2.AddLast(3);
			list2.AddLast(4);
			list2.AddLast(5);

			var result = list1.Union<int>(list2).ToMyLinkedList();

			Assert.AreEqual(result.Count, 5);
			Assert.AreEqual(result.First.Value, 1);
			Assert.AreEqual(result.Last.Value, 5);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void Union_SecondListIsNull_ArgumentNullExceptionThrown()
		{
			MyLinkedList<int> list1 = new MyLinkedList<int>();
			list1.Union<int>(null);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void Where_PredicateIsNull_ArgumentNullExceptionThrown()
		{
			MyLinkedList<int> list = new MyLinkedList<int>();
			list.Where<int>(null);
		}

		[TestMethod]
		public void Where_ValidDataGiven_NoExceptionThrown()
		{
			MyLinkedList<int> list = new MyLinkedList<int>();
			list.AddLast(1);
			list.AddLast(2);
			list.AddLast(2);
			list.AddLast(2);
			list.AddLast(3);

			var result = list.Where<int>(x => x > 2).ToMyLinkedList();

			Assert.AreEqual(result.Count, 1);
			Assert.AreEqual(result.First.Value, 3);
			Assert.AreEqual(result.Last.Value, 3);
			Assert.AreEqual(result.Last, result.First);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void Concat_SecondListIsNull_ArgumentNullExceptionThrown()
		{
			MyLinkedList<int> list = new MyLinkedList<int>();
			list.Concat<int>(null);
		}

		[TestMethod]
		public void Concat_ValidDataGiven_NoExceptionThrown()
		{
			MyLinkedList<int> list1 = new MyLinkedList<int>();
			list1.AddLast(1);
			list1.AddLast(2);
			list1.AddLast(2);
			list1.AddLast(2);
			list1.AddLast(3);

			MyLinkedList<int> list2 = new MyLinkedList<int>();
			list2.AddLast(1);
			list2.AddLast(3);
			list2.AddLast(3);
			list2.AddLast(4);
			list2.AddLast(5);

			var result = list1.Concat<int>(list2).ToMyLinkedList();

			Assert.AreEqual(result.Count, 10);
			Assert.AreEqual(result.First.Value, list1.First.Value);
			Assert.AreEqual(result.Last.Value, list2.Last.Value);
		}

		[TestMethod]
		public void Reverse_ValidDataGiven_NoExceptionThrown()
		{
			MyLinkedList<int> list = new MyLinkedList<int>();
			list.AddLast(1);
			list.AddLast(2);
			list.AddLast(3);
			list.AddLast(4);
			list.AddLast(5);

			var result = list.Reverse<int>().ToMyLinkedList();

			Assert.AreEqual(result.Count, 5);
			Assert.AreEqual(result.First.Value, 5);
			Assert.AreEqual(result.Last.Value, 1);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void Select_SelectorIsNull_ArgumentNullExceptionThrown()
		{
			MyLinkedList<int> list = new MyLinkedList<int>();
			list.Select<int, int>(null);
		}

		[TestMethod]
		public void Select_ValidDataGiven_NoExceptionThrown()
		{
			MyLinkedList<int> list = new MyLinkedList<int>();
			list.AddLast(1);
			list.AddLast(2);
			list.AddLast(3);
			list.AddLast(4);
			list.AddLast(5);

			var result = list.Select<int, int>(x => x * 2).ToMyLinkedList();

			Assert.AreEqual(result.Count, 5);
			Assert.AreEqual(result.First.Value, 2);
			Assert.AreEqual(result.Last.Value, 10);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void First_PredicateIsNull_ArgumentNullExceptionThrown()
		{
			MyLinkedList<int> list = new MyLinkedList<int>();
			list.First<int>(null);
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void First_NoItemsMatchPredicate_InvalidOperationExceptionThrown()
		{
			MyLinkedList<int> list = new MyLinkedList<int>();
			list.AddLast(1);
			list.AddLast(2);
			list.AddLast(3);
			list.AddLast(4);
			list.AddLast(5);

			list.First<int>(x => x > 100);
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void First_EmptyListGiven_InvalidOperationExceptionThrown()
		{
			MyLinkedList<int> list = new MyLinkedList<int>();
			list.First<int>(x => x < 2);
		}

		[TestMethod]
		public void First_ValidDataGiven_NoExceptionThrown()
		{
			MyLinkedList<int> list = new MyLinkedList<int>();
			list.AddLast(1);
			list.AddLast(2);
			list.AddLast(3);
			list.AddLast(4);
			list.AddLast(5);

			var result = list.First<int>(x => x > 3);

			Assert.AreEqual(result, 4);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void FirstOrDefault_PredicateIsNull_ArgumentNullExceptionThrown()
		{
			MyLinkedList<int> list = new MyLinkedList<int>();
			list.FirstOrDefault<int>(null);
		}

		[TestMethod]
		public void FirstOrDefault_NoItemsMatchPredicate_NoExceptionThrown()
		{
			MyLinkedList<int> list = new MyLinkedList<int>();
			list.AddLast(1);
			list.AddLast(2);
			list.AddLast(3);
			list.AddLast(4);
			list.AddLast(5);

			var result = list.FirstOrDefault<int>(x => x > 100);

			Assert.AreEqual(result, 0);
		}

		[TestMethod]
		public void FirstOrDefault_EmptyListGiven_NoExceptionThrown()
		{
			MyLinkedList<int> list = new MyLinkedList<int>();

			var result = list.FirstOrDefault<int>(x => x > 100);

			Assert.AreEqual(result, 0);
		}

		[TestMethod]
		public void FirstOrDefault_ValidDataGiven_NoExceptionThrown()
		{
			MyLinkedList<int> list = new MyLinkedList<int>();
			list.AddLast(1);
			list.AddLast(2);
			list.AddLast(3);
			list.AddLast(4);
			list.AddLast(5);

			var result = list.FirstOrDefault<int>(x => x > 3);

			Assert.AreEqual(result, 4);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void Single_PredicateIsNull_ArgumentNullExceptionThrown()
		{
			MyLinkedList<int> list = new MyLinkedList<int>();
			list.Single<int>(null);
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void Single_EmptyListGiven_InvalidOperationExceptionThrown()
		{
			MyLinkedList<int> list = new MyLinkedList<int>();
			list.Single<int>(x => x < 2);
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void Single_InvalidDataGiven_InvalidOperationExceptionThrown()
		{
			MyLinkedList<int> list = new MyLinkedList<int>();

			list.AddLast(1);
			list.AddLast(-2);
			list.AddLast(1);

			list.Single<int>(x => x < 2);
		}

		[TestMethod]
		public void Single_ValidDataGiven_NoExceptionThrown()
		{
			MyLinkedList<int> list = new MyLinkedList<int>();

			list.AddLast(5);
			list.AddLast(4);
			list.AddLast(1);

			var result = list.Single<int>(x => x < 2);

			Assert.AreEqual(result, 1);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void SingleOrDefault_PredicateIsNull_ArgumentNullExceptionThrown()
		{
			MyLinkedList<int> list = new MyLinkedList<int>();
			list.SingleOrDefault<int>(null);
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void SingleOrDefault_EmptyListGiven_InvalidOperationExceptionThrown()
		{
			MyLinkedList<int> list = new MyLinkedList<int>();
			list.SingleOrDefault<int>(x => x < 2);
		}

		[TestMethod]
		public void SingleOrDefault_InvalidDataGiven_NoExceptionThrown()
		{
			MyLinkedList<int> list = new MyLinkedList<int>();

			list.AddLast(1);
			list.AddLast(-2);
			list.AddLast(1);

			var result = list.SingleOrDefault<int>(x => x < 2);

			Assert.AreEqual(result, 0);
		}

		[TestMethod]
		public void SingleOrDefault_ValidDataGiven_NoExceptionThrown()
		{
			MyLinkedList<int> list = new MyLinkedList<int>();

			list.AddLast(5);
			list.AddLast(4);
			list.AddLast(1);

			var result = list.SingleOrDefault<int>(x => x < 2);

			Assert.AreEqual(result, 1);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void Count_PredicateIsNull_ArgumentNullExceptionThrown()
		{
			MyLinkedList<int> list = new MyLinkedList<int>();
			list.Count<int>(null);
		}

		[TestMethod]
		public void Count_ValidDataGiven_NoExceptionThrown()
		{
			MyLinkedList<int> list = new MyLinkedList<int>();

			list.AddLast(5);
			list.AddLast(4);
			list.AddLast(1);

			var result = list.Count<int>(x => x < 5);

			Assert.AreEqual(result, 2);
		}

		[TestMethod]
		public void Count_NoItemsMatchPredicate_NoExceptionThrown()
		{
			MyLinkedList<int> list = new MyLinkedList<int>();

			list.AddLast(5);
			list.AddLast(4);
			list.AddLast(1);

			var result = list.Count<int>(x => x > 100);

			Assert.AreEqual(result, 0);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void Any_PredicateIsNull_ArgumentNullExceptionThrown()
		{
			MyLinkedList<int> list = new MyLinkedList<int>();
			list.Any<int>(null);
		}

		[TestMethod]
		public void Any_ValidDataGiven_NoExceptionThrown()
		{
			MyLinkedList<int> list = new MyLinkedList<int>();

			list.AddLast(5);
			list.AddLast(4);
			list.AddLast(1);

			var result = list.Any<int>(x => x < 5);

			Assert.AreEqual(result, true);
		}

		[TestMethod]
		public void Any_NoItemsMatchPredicate_NoExceptionThrown()
		{
			MyLinkedList<int> list = new MyLinkedList<int>();

			list.AddLast(5);
			list.AddLast(4);
			list.AddLast(1);

			var result = list.Any<int>(x => x > 100);

			Assert.AreEqual(result, false);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void All_PredicateIsNull_ArgumentNullExceptionThrown()
		{
			MyLinkedList<int> list = new MyLinkedList<int>();
			list.All<int>(null);
		}

		[TestMethod]
		public void All_ValidDataGiven_NoExceptionThrown()
		{
			MyLinkedList<int> list = new MyLinkedList<int>();

			list.AddLast(3);
			list.AddLast(4);
			list.AddLast(1);

			var result = list.All<int>(x => x < 5);

			Assert.AreEqual(result, true);
		}

		[TestMethod]
		public void All_NoItemsMatchPredicate_NoExceptionThrown()
		{
			MyLinkedList<int> list = new MyLinkedList<int>();

			list.AddLast(5);
			list.AddLast(4);
			list.AddLast(1);

			var result = list.All<int>(x => x < 5);

			Assert.AreEqual(result, false);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void Replace_PredicateIsNull_ArgumentNullExceptionThrown()
		{
			MyLinkedList<int> list = new MyLinkedList<int>();
			list.Replace<int>(2, null);
		}

		[TestMethod]
		public void Replace_ValidDataGiven_NoExceptionThrown()
		{
			MyLinkedList<int> list = new MyLinkedList<int>();

			list.AddLast(1);
			list.AddLast(2);
			list.AddLast(3);

			list.Replace<int>(2, x => x > 2);

			Assert.AreEqual(list.Last.Value, 2);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void ReplaceAll_PredicateIsNull_ArgumentNullExceptionThrown()
		{
			MyLinkedList<int> list = new MyLinkedList<int>();
			list.ReplaceAll<int>(2, null);
		}

		[TestMethod]
		public void ReplaceAll_ValidDataGiven_NoExceptionThrown()
		{
			MyLinkedList<int> list = new MyLinkedList<int>();

			list.AddLast(1);
			list.AddLast(2);
			list.AddLast(3);

			list.ReplaceAll<int>(2, x => x > 1);

			Assert.AreEqual(list.Last.Value, 2);
			Assert.AreEqual(list.Last.Previous.Value, 2);
		}
	}
}
