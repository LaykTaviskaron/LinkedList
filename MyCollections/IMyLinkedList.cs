using System.Collections.Generic;

namespace MyCollections
{
	public interface IMyLinkedList<T> : ICollection<T>
	{
		MyLinkedListNode<T> First { get; }

		MyLinkedListNode<T> Last { get; }

		new int Count { get; }

		new bool IsReadOnly { get; }

		new void Clear();

		new bool Contains(T item);

		new void CopyTo(T[] array, int arrayIndex);

		new bool Remove(T item);

		void AddFirst(T item);

		void AddFirst(MyLinkedListNode<T> item);

		void AddLast(T item);

		void AddLast(MyLinkedListNode<T> item);

		MyLinkedListNode<T> Find(T value);

		MyLinkedListNode<T> FindLast(T value);

		void RemoveFirst();

		void RemoveLast();

		void Remove(MyLinkedListNode<T> item);
	}
}
