using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCollections;
using System.Collections.Generic;
using System.Collections;

namespace MyCollectionsTests
{
	[TestClass]
	public class MyLinkedListTest
	{
		[TestMethod]
		public void MyLinkedList_ThrowsNoException()
		{
			MyLinkedList<string> list = new MyLinkedList<string>();
			
			Assert.AreEqual(list.Count, 0);
			Assert.IsNull(list.First);
			Assert.IsNull(list.Last);
			Assert.IsFalse(list.IsReadOnly);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void AddFirst_NullGiven_ArgumentNullExceptionThrown()
		{
			MyLinkedList<string> list = new MyLinkedList<string>();
			string input = null;
			list.AddFirst(input);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void AddLast_NullGiven_ArgumentNullExceptionThrown()
		{
			MyLinkedList<string> list = new MyLinkedList<string>();
			string input = null;
			list.AddLast(input);
		}

		[TestMethod]
		public void AddFirst_ValidDataGiven_NoExceptionThrown()
		{
			MyLinkedList<string> list = new MyLinkedList<string>();
			string input = "kokoko";
			list.AddFirst(input);

			Assert.AreEqual(list.Count, 1);
			Assert.IsNotNull(list.First);
			Assert.IsNotNull(list.Last);
			Assert.IsFalse(list.IsReadOnly);
			Assert.AreEqual(list.First, list.Last);

			Assert.AreEqual(list.First.Value, input);
		}

		[TestMethod]
		public void AddLast_ValidDataGiven_NoExceptionThrown()
		{
			MyLinkedList<string> list = new MyLinkedList<string>();
			string input = "kokoko";
			list.AddLast(input);

			Assert.AreEqual(list.Count, 1);
			Assert.IsNotNull(list.First);
			Assert.IsNotNull(list.Last);
			Assert.IsFalse(list.IsReadOnly);
			Assert.AreEqual(list.First, list.Last);

			Assert.AreEqual(list.First.Value, input);
		}

		[TestMethod]
		public void Add_ValidDataGiven_NoExceptionThrown()
		{
			ICollection<string> list = new MyLinkedList<string>();
			string input = "kokoko";
			list.Add(input);

			MyLinkedList<string> result = (MyLinkedList<string>)list;


			Assert.AreEqual(result.Count, 1);
			Assert.IsNotNull(result.First);
			Assert.IsNotNull(result.Last);
			Assert.IsFalse(result.IsReadOnly);
			Assert.AreEqual(result.First, result.Last);

			Assert.AreEqual(result.First.Value, input);
		}

		[TestMethod]
		public void AddFirst_AddingSecondItem_NoExceptionThrown()
		{
			MyLinkedList<string> list = new MyLinkedList<string>();
			string input = "kokoko";
			list.AddFirst(input);
			list.AddFirst(input);

			Assert.AreEqual(list.Count, 2);
			Assert.IsNotNull(list.First);
			Assert.IsNotNull(list.Last);
			Assert.IsFalse(list.IsReadOnly);
			Assert.AreEqual(list.First.Value, list.Last.Value);
			Assert.AreNotEqual(list.First, list.Last);

			Assert.AreEqual(list.First.Value, input);
		}

		[TestMethod]
		public void AddLast_AddingSecondItem_NoExceptionThrown()
		{
			MyLinkedList<string> list = new MyLinkedList<string>();
			string input = "kokoko";
			list.AddLast(input);
			list.AddLast(input);

			Assert.AreEqual(list.Count, 2);
			Assert.IsNotNull(list.First);
			Assert.IsNotNull(list.Last);
			Assert.IsFalse(list.IsReadOnly);
			Assert.AreEqual(list.First.Value, list.Last.Value);
			Assert.AreNotEqual(list.First, list.Last);

			Assert.AreEqual(list.First.Value, input);
		}

		[TestMethod]
		public void Contains_ExistingItemGiven_NoExceptionThrown()
		{
			MyLinkedList<string> list = new MyLinkedList<string>();
			string input = "kokoko"; 
			list.AddLast(input + "anotherdata"); 
			list.AddLast(input);

			Assert.IsTrue(list.Contains(input));
		}

		[TestMethod]
		public void Contains_NotExistingItemGiven_NoExceptionThrown()
		{
			MyLinkedList<string> list = new MyLinkedList<string>();
			string input = "kokoko";
			list.AddLast(input);

			Assert.IsFalse(list.Contains(input + "smth else"));
		}

		[TestMethod]
		public void RemoveFirst_EmptyListGiven_NoExceptionThrown()
		{
			MyLinkedList<string> list = new MyLinkedList<string>();
			list.RemoveFirst();
		}

		[TestMethod]
		public void RemoveFirst_OneItemGiven_NoExceptionThrown()
		{
			MyLinkedList<string> list = new MyLinkedList<string>();
			string input = "kokoko";
			list.AddFirst(input);
			list.RemoveFirst();
		}

		[TestMethod]
		public void RemoveFirst_ManyItemsGiven_NoExceptionThrown()
		{
			MyLinkedList<string> list = new MyLinkedList<string>();
			string input = "kokoko";
			list.AddFirst(input);
			list.AddFirst(input);
			list.AddFirst(input);
			list.RemoveFirst();
		}

		[TestMethod]
		public void RemoveLast_EmptyListGiven_NoExceptionThrown()
		{
			MyLinkedList<string> list = new MyLinkedList<string>();
			list.RemoveLast();
		}

		[TestMethod]
		public void RemoveLast_OneItemGiven_NoExceptionThrown()
		{
			MyLinkedList<string> list = new MyLinkedList<string>();
			string input = "kokoko";
			list.AddLast(input);
			list.RemoveLast();
		}

		[TestMethod]
		public void RemoveLast_ManyItemsGiven_NoExceptionThrown()
		{
			MyLinkedList<string> list = new MyLinkedList<string>();
			string input = "kokoko";
			list.AddLast(input);
			list.AddLast(input);
			list.AddLast(input);
			list.RemoveLast();
		}

		[TestMethod]
		public void Clear_EmptyListGiven_NoExceptionThrown()
		{
			MyLinkedList<string> list = new MyLinkedList<string>();
			list.Clear();
		}

		[TestMethod]
		public void Clear_NotEmptyListGiven_NoExceptionThrown()
		{
			MyLinkedList<string> list = new MyLinkedList<string>();
			string input = "kokoko";
			list.AddLast(input);
			list.AddLast(input);
			list.AddLast(input);
			list.Clear();
		}

		[TestMethod]
		public void Remove_EmptyListGiven_NoExceptionThrown()
		{
			MyLinkedList<string> list = new MyLinkedList<string>();
			string input = "kokoko";
			list.Remove(input);
		}

		[TestMethod]
		public void Remove_NotEmptyListGiven_LastItemIsDeleted()
		{
			MyLinkedList<string> list = new MyLinkedList<string>();
			string input = "kokoko";
			list.AddLast(input);
			list.AddLast(input);
			list.AddLast(input + "some data");
			list.Remove(input + "some data");
		}

		[TestMethod]
		public void Remove_NotEmptyListGiven_FirstItemIsDeleted()
		{
			MyLinkedList<string> list = new MyLinkedList<string>();
			string input = "kokoko";
			list.AddLast(input);
			list.AddLast(input);
			list.AddLast(input);
			list.Remove(input);
		}

		[TestMethod]
		public void Remove_NotEmptyListGiven_ItemInTheMiddleIsDeleted()
		{
			MyLinkedList<string> list = new MyLinkedList<string>();
			string input = "kokoko";
			list.AddLast(input + "some data");
			list.AddLast(input + "some data");
			list.AddLast(input);
			list.AddLast(input + "some data");
			list.Remove(input);
		}

		[TestMethod]
		public void Remove_NotEmptyListGiven_NoItemFound()
		{
			MyLinkedList<string> list = new MyLinkedList<string>();
			string input = "kokoko";
			list.AddLast(input + "some data");
			list.AddLast(input + "some data");
			list.AddLast(input);
			list.AddLast(input + "some data");

			list.Remove(input + "Another data");
		}

		[TestMethod]
		public void CopyTo_EmptyListGiven_NoExceptionThrown()
		{
			MyLinkedList<string> list = new MyLinkedList<string>();
			string[] array = new string[10];

			list.CopyTo(array,0);
		}

		[TestMethod]
		public void CopyTo_NotEmptyListGiven_NoExceptionThrown()
		{
			MyLinkedList<string> list = new MyLinkedList<string>();
			string[] array = new string[4];
			string input = "kokoko";
			list.AddLast(input + "some data");
			list.AddLast(input + "some data");
			list.AddLast(input);
			list.AddLast(input + "some data");

			list.CopyTo(array, 0);

			Assert.AreEqual(list.First.Value, array[0]);
		}

		[TestMethod]
		[ExpectedException(typeof(IndexOutOfRangeException))]
		public void CopyTo_ArrayIndexIsLessThanZero_IndexOutOfRangeExceptionThrown()
		{
			(new MyLinkedList<int>()).CopyTo(new int[5], -100);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void CopyTo_IndexIsMoreThenArraySize_ArgumentExceptionThrown()
		{
			(new MyLinkedList<int>()).CopyTo(new int[5], 6);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void CopyTo_NullArrayGiven_ArgumentNullExceptionThrown()
		{
			(new MyLinkedList<int>()).CopyTo(null, 6);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void CopyTo_ArrayIsSmallerThenList_ArgumentExceptionThrown()
		{
			MyLinkedList<int> list = new MyLinkedList<int>();

			list.AddLast(1);
			list.AddLast(2);
			list.AddLast(3);
			list.AddLast(4);
			list.AddLast(5);

			list.CopyTo(new int[3], 0);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void Find_NullFiven_ArgumentNullExceptionThrown()
		{
			(new MyLinkedList<string>()).Find(null);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void FindLast_NullFiven_ArgumentNullExceptionThrown()
		{
			(new MyLinkedList<string>()).FindLast(null);
		}

		[TestMethod]
		public void Find_ValidDataGiven_NoExceptionThrown()
		{
			MyLinkedList<int> list = new MyLinkedList<int>();

			list.AddLast(1);
			list.AddLast(2);
			list.AddLast(3);
			list.AddLast(3);
			list.AddLast(5);

			var result = list.Find(3);

			Assert.AreEqual(result.Value, 3);
			Assert.AreEqual(result.Next.Value, 3);
			Assert.AreEqual(result.Previous.Value, 2);
		}

		[TestMethod]
		public void FindLast_ValidDataGiven_NoExceptionThrown()
		{
			MyLinkedList<int> list = new MyLinkedList<int>();

			list.AddLast(1);
			list.AddLast(2);
			list.AddLast(3);
			list.AddLast(3);
			list.AddLast(5);

			var result = list.FindLast(3);

			Assert.AreEqual(result.Value, 3);
			Assert.AreEqual(result.Next.Value, 5);
			Assert.AreEqual(result.Previous.Value, 3);
		}

		[TestMethod]
		public void Find_InvalidDataGiven_NoExceptionThrown()
		{
			MyLinkedList<int> list = new MyLinkedList<int>();

			list.AddLast(1);
			list.AddLast(2);
			list.AddLast(3);
			list.AddLast(3);
			list.AddLast(5);

			var result = list.Find(100);

			Assert.IsNull(result);
		}

		[TestMethod]
		public void FindLast_InvalidDataGiven_NoExceptionThrown()
		{
			MyLinkedList<int> list = new MyLinkedList<int>();

			list.AddLast(1);
			list.AddLast(2);
			list.AddLast(3);
			list.AddLast(3);
			list.AddLast(5);

			var result = list.FindLast(100);

			Assert.IsNull(result);
		}

		[TestMethod]
		public void GetEnumenator()
		{
			MyLinkedList<int> list = new MyLinkedList<int>();

			list.AddLast(1);
			list.AddLast(2);
			list.AddLast(3);
			list.AddLast(3);
			list.AddLast(5);

			IEnumerable first = list;

			MyLinkedList<int> second = new MyLinkedList<int>();


			foreach (var item in first)
			{
				second.AddLast((int)item);
			}

			Assert.AreEqual(list.Count, second.Count);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void AddFirst_NullNodeGiven_ArgumentNullExceptionThrown()
		{
			MyLinkedList<string> list = new MyLinkedList<string>();
			MyLinkedListNode<string> input = null;
			list.AddFirst(input);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void AddLast_NullNodeGiven_ArgumentNullExceptionThrown()
		{
			MyLinkedList<string> list = new MyLinkedList<string>();
			MyLinkedListNode<string> input = null;
			list.AddLast(input);
		}

		[TestMethod]
		public void AddFirst_ValidNodeDataGiven_NoExceptionThrown()
		{
			MyLinkedList<string> list = new MyLinkedList<string>();
			MyLinkedListNode<string> input = new MyLinkedListNode<string>() { Value = "kokoko" };
			list.AddFirst(input);

			Assert.AreEqual(list.Count, 1);
			Assert.IsNotNull(list.First);
			Assert.IsNotNull(list.Last);
			Assert.IsFalse(list.IsReadOnly);
			Assert.AreEqual(list.First, list.Last);

			Assert.AreEqual(list.First.Value, input.Value);
		}

		[TestMethod]
		public void AddLast_ValidNodeDataGiven_NoExceptionThrown()
		{
			MyLinkedList<string> list = new MyLinkedList<string>();
			MyLinkedListNode<string> input = new MyLinkedListNode<string>() { Value = "kokoko" };
			list.AddLast(input);

			Assert.AreEqual(list.Count, 1);
			Assert.IsNotNull(list.First);
			Assert.IsNotNull(list.Last);
			Assert.IsFalse(list.IsReadOnly);
			Assert.AreEqual(list.First, list.Last);

			Assert.AreEqual(list.First.Value, input.Value);
		}

		[TestMethod]
		public void AddFirst_AddingSecondNode_NoExceptionThrown()
		{
			MyLinkedList<string> list = new MyLinkedList<string>();
			MyLinkedListNode<string> input1 = new MyLinkedListNode<string>() { Value = "kokoko" };
			MyLinkedListNode<string> input2 = new MyLinkedListNode<string>() { Value = "kokoko" };
			
			list.AddFirst(input1);
			list.AddFirst(input2);

			Assert.AreEqual(list.Count, 2);
			Assert.IsNotNull(list.First);
			Assert.IsNotNull(list.Last);
			Assert.IsFalse(list.IsReadOnly);
			Assert.AreEqual(list.First.Value, list.Last.Value);
			Assert.AreNotEqual(list.First, list.Last);

			Assert.AreEqual(list.First.Value, input2.Value);
		}

		[TestMethod]
		public void AddLast_AddingSecondNode_NoExceptionThrown()
		{
			MyLinkedList<string> list = new MyLinkedList<string>();
			MyLinkedListNode<string> input1 = new MyLinkedListNode<string>() { Value = "kokoko" };
			MyLinkedListNode<string> input2 = new MyLinkedListNode<string>() { Value = "kokoko" };

			list.AddLast(input1);
			list.AddLast(input2);

			Assert.AreEqual(list.Count, 2);
			Assert.IsNotNull(list.First);
			Assert.IsNotNull(list.Last);
			Assert.IsFalse(list.IsReadOnly);
			Assert.AreEqual(list.First.Value, list.Last.Value);
			Assert.AreNotEqual(list.First, list.Last);

			Assert.AreEqual(list.First.Value, input2.Value);
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void RemoveNode_EmptyListGiven_InvalidOperationExceptionThrown()
		{
			MyLinkedList<string> list = new MyLinkedList<string>();
			MyLinkedListNode<string> input = new MyLinkedListNode<string>() { Value = "kokoko" };
			list.Remove(input);
		}

		[TestMethod]
		public void RemoveNode_NotEmptyListGiven_LastItemIsDeleted()
		{
			MyLinkedList<string> list = new MyLinkedList<string>();
			
			MyLinkedListNode<string> input1 = new MyLinkedListNode<string>() { Value = "kokoko" };
			MyLinkedListNode<string> input2 = new MyLinkedListNode<string>() { Value = "kokoko" };
			MyLinkedListNode<string> input3 = new MyLinkedListNode<string>() { Value = "kokoko" };

			list.AddLast(input1);
			list.AddLast(input2);
			list.AddLast(input3);

			list.Remove(input3);

			Assert.AreEqual(list.Count, 2);
			Assert.AreEqual(list.First, input1);
			Assert.AreEqual(list.Last, input2);
		}

		[TestMethod]
		public void RemoveNode_NotEmptyListGiven_FirstItemIsDeleted()
		{
			MyLinkedList<string> list = new MyLinkedList<string>();
			MyLinkedListNode<string> input1 = new MyLinkedListNode<string>() { Value = "kokoko" };
			MyLinkedListNode<string> input2 = new MyLinkedListNode<string>() { Value = "kokoko" };
			MyLinkedListNode<string> input3 = new MyLinkedListNode<string>() { Value = "kokoko" };

			list.AddLast(input1);
			list.AddLast(input2);
			list.AddLast(input3);

			list.Remove(input1);

			Assert.AreEqual(list.Count, 2);
			Assert.AreEqual(list.First, input2);
			Assert.AreEqual(list.Last, input3);
		}

		[TestMethod]
		public void RemoveNode_NotEmptyListGiven_NodeInTheMiddleIsDeleted()
		{
			MyLinkedList<string> list = new MyLinkedList<string>();
			MyLinkedListNode<string> input1 = new MyLinkedListNode<string>() { Value = "kokoko" };
			MyLinkedListNode<string> input2 = new MyLinkedListNode<string>() { Value = "kokoko" };
			MyLinkedListNode<string> input3 = new MyLinkedListNode<string>() { Value = "kokoko" };
			MyLinkedListNode<string> input4 = new MyLinkedListNode<string>() { Value = "kokoko" };

			list.AddLast(input1);
			list.AddLast(input2);
			list.AddLast(input3);
			list.AddLast(input4);

			list.Remove(input3);

			Assert.AreEqual(list.Count, 3);
			Assert.AreEqual(list.First, input1);
			Assert.AreEqual(list.Last, input4);
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void RemoveNode_NotEmptyListGiven_InvalidOperationExceptionThrown()
		{
			MyLinkedList<string> list = new MyLinkedList<string>();
			MyLinkedListNode<string> input1 = new MyLinkedListNode<string>() { Value = "kokoko" };
			MyLinkedListNode<string> input2 = new MyLinkedListNode<string>() { Value = "kokoko" };
			MyLinkedListNode<string> input3 = new MyLinkedListNode<string>() { Value = "kokoko" };

			list.AddLast(input1);
			list.AddLast(input2);

			list.Remove(input3);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void RemoveNode_NullGiven_ArgumentNullExceptionThrown()
		{
			MyLinkedList<string> list = new MyLinkedList<string>();
			MyLinkedListNode<string> input = null;
			list.Remove(input);
		}
	}
}
