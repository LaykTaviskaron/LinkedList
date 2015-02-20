using System;
using System.Collections.Generic;
using System.Collections;

namespace MyCollections
{
	public class MyLinkedList<T> : IMyLinkedList<T>
	{
		public MyLinkedListNode<T> First { get; private set; }

		public MyLinkedListNode<T> Last { get; private set; }

		public int Count { get; private set; }

		public bool IsReadOnly
		{
			get 
			{
				return false; 
			}
		}

		public void AddFirst(T item)
		{
			if (IsReadOnly)
			{
				throw new NotSupportedException("Collection is read-only");
			}

			if (item == null)
			{
				throw new ArgumentNullException("item");
			}

			if (Count == 0)
			{
				First = new MyLinkedListNode<T>();
				Last = First;
				First.Value = item;
				Last.Value = item;
				First.Next = null;
				Last.Next = null;
				First.Previous = null;
				Last.Previous = null;
			}
			else
			{
				MyLinkedListNode<T> newNode = new MyLinkedListNode<T>();
				newNode.Value = item;
				newNode.Next = First;
				newNode.Previous = null;
				First.Previous = newNode;
				First = newNode;
			}

			Count++;
		}

		public void AddLast(T item)
		{
			if (IsReadOnly)
			{
				throw new NotSupportedException("Collection is read-only");
			}

			if (item == null)
			{
				throw new ArgumentNullException("item");
			}

			if (Count == 0)
			{
				Last = new MyLinkedListNode<T>();
				First = Last;
				First.Value = item;
				Last.Value = item;
				First.Next = null;
				Last.Next = null;
				First.Previous = null;
				Last.Previous = null;
			}
			else
			{
				MyLinkedListNode<T> newNode = new MyLinkedListNode<T>();
				newNode.Value = item;
				newNode.Next = null;
				newNode.Previous = Last;
				Last.Next = newNode;
				Last = newNode;
			}

			Count++;
		}

		public void Clear()
		{
			if (IsReadOnly)
			{
				throw new NotSupportedException("Collection is read-only");
			}

			First = null;
			Last = null;
			Count = 0;
		}

		public bool Contains(T item)
		{
			MyLinkedListNode<T> current = First;
			while (current != null)
			{
				if (Object.Equals(current.Value, item))
				{
					return true;
				}
				current = current.Next;
			}
			return false;
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}

			if (arrayIndex < 0)
			{
				throw new IndexOutOfRangeException("arrayIndex");
			}

			if ((array.Length - arrayIndex) < Count)
			{
				throw new ArgumentException("The number of elements in the source MyLinkedList<T>" 
					+ " is greater than the available space from index to the end of the destination array.");
			}

			MyLinkedListNode<T> current = First;
			
			for (int i = arrayIndex; i < Count; i++)
			{
				array[i] = current.Value;
				current = current.Next;
			}

		}

		public bool Remove(T item)
		{
			if (IsReadOnly)
			{
				throw new NotSupportedException("Collection is read-only");
			}

			if (Count == 0)
			{
				return false;
			}

			if (Object.Equals(First.Value, item))
			{
				RemoveFirst();
				return true;
			}

			if (Object.Equals(Last.Value, item))
			{
				RemoveLast();
				return true;
			}

			MyLinkedListNode<T> temp = First.Next;
			
			while (temp.Next != null)
			{
				if (Object.Equals(temp.Value, item))
				{
					MyLinkedListNode<T> previousNode = temp.Previous;
					MyLinkedListNode<T> nextNode = temp.Next;
					previousNode.Next = nextNode;
					nextNode.Previous = previousNode;
					
					temp.Next = null;
					temp.Previous = null;

					Count--;
					return true;
				}
				temp = temp.Next;
			}

			return false;
		}

		public void RemoveFirst()
		{
			if (IsReadOnly)
			{
				throw new NotSupportedException("Collection is read-only");
			}

			if (Count == 0)
			{
				return;
			}

			if (Count == 1)
			{
				First = null;
				Last = null;
				Count--;
				return;
			}

			MyLinkedListNode<T> temp = First.Next;

			temp.Previous = null;
			First.Next = null;
			First = temp;

			Count--;
		}

		public void RemoveLast()
		{
			if (IsReadOnly)
			{
				throw new NotSupportedException("Collection is read-only");
			}

			if (Count == 0)
			{
				return;
			}

			if (Count == 1)
			{
				First = null;
				Last = null;
				Count--;
				return;
			}

			MyLinkedListNode<T> temp = Last.Previous;

			temp.Next = null;
			Last.Previous = null;
			Last = temp;

			Count--;
		}

		public MyLinkedListNode<T> Find(T value)
		{
			MyLinkedListNode<T> current = First;

			while (current != null)
			{
				if (Object.Equals(current.Value, value))
				{
					return current;
				}
				current = current.Next;
			}

			return null;
		}

		public MyLinkedListNode<T> FindLast(T value)
		{
			MyLinkedListNode<T> current = Last;

			while (current != null)
			{
				if (Object.Equals(current.Value, value))
				{
					return current;
				}
				current = current.Previous;
			}

			return null;
		}
		
		void ICollection<T>.Add(T item)
		{
			AddLast(item);
		}

		public IEnumerator<T> GetEnumerator()
		{
			var current = First;
			while (current != null)
			{
				yield return current.Value;
				current = current.Next;
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		public void AddFirst(MyLinkedListNode<T> item)
		{
			if (IsReadOnly)
			{
				throw new NotSupportedException("Collection is read-only");
			}

			if (item == null)
			{
				throw new ArgumentNullException("item");
			}

			if (Count == 0)
			{
				First = item;
				Last = item;
				First.Previous = null;
				Last.Next = null;
			}
			else
			{
				item.Previous = null;
				item.Next = First;
				First.Previous = item;
				First = item;
			}

			Count++;
		}

		public void AddLast(MyLinkedListNode<T> item)
		{
			if (IsReadOnly)
			{
				throw new NotSupportedException("Collection is read-only");
			}

			if (item == null)
			{
				throw new ArgumentNullException("item");
			}

			if (Count == 0)
			{
				First = item;
				Last = item;
				First.Previous = null;
				Last.Next = null;
			}
			else
			{
				item.Next = null;
				item.Previous = Last;
				Last.Next = item;
				Last = item;
			}

			Count++;
		}

		public void Remove(MyLinkedListNode<T> item)
		{
			if (IsReadOnly)
			{
				throw new NotSupportedException("Collection is read-only");
			}

			if (item == null)
			{
				throw new ArgumentNullException("item");
			}

			if (Count == 0)
			{
				throw new InvalidOperationException("There is no such item");
			}

			if (First.Equals(item))
			{
				RemoveFirst();
				return;
			}

			if (Last.Equals(item))
			{
				RemoveLast();
				return;
			}

			MyLinkedListNode<T> temp = First.Next;

			while (temp.Next != null)
			{
				if (temp.Equals(item))
				{
					MyLinkedListNode<T> prev = temp.Previous;
					MyLinkedListNode<T> next = temp.Next;
					prev.Next = next;
					next.Previous = prev;

					temp.Next = null;
					temp.Previous = null;

					Count--;
					return;
				}
				temp = temp.Next;
			}

			throw new InvalidOperationException("There is no such item");
		}
	}
}
