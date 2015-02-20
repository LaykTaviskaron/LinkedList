using System;
using System.Collections.Generic;

namespace MyCollections
{
	public static class IEnumerableExtensions
	{
		public static MyLinkedList<T> ToMyLinkedList<T>(this IEnumerable<T> source)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}

			MyLinkedList<T> list = new MyLinkedList<T>();

			foreach (var item in source)
			{
				list.AddLast(item);
			}

			return list;
		}
	}
}
