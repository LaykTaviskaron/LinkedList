using System;
using System.Collections.Generic;

namespace MyCollections
{
	public static class MyLinkedListExtensions
	{
		public static IEnumerable<T> TakeWhile<T>(this IMyLinkedList<T> list, Predicate<T> predicate)
		{
			if (list == null)
			{
				throw new ArgumentNullException("list");
			}

			if (predicate == null)
			{
				throw new ArgumentNullException("predicate");
			}

			return TakeWhileIterator<T>(list, predicate);
		}

		public static IEnumerable<T> SkipWhile<T>(this IMyLinkedList<T> list, Predicate<T> predicate)
		{
			if (list == null)
			{
				throw new ArgumentNullException("list");
			}

			if (predicate == null)
			{
				throw new ArgumentNullException("predicate");
			}

			return SkipWhileIterator<T>(list, predicate);
		}

		public static IEnumerable<TResult> Select<TSource, TResult>(this IMyLinkedList<TSource> source, Func<TSource, TResult> selector)
		{
			if (source == null)
			{
				throw new ArgumentNullException("list");
			}

			if (selector == null)
			{
				throw new ArgumentNullException("predicate");
			}

			return SelectIterator<TSource, TResult>(source, selector);
		}

		public static IEnumerable<T> Reverse<T>(this IMyLinkedList<T> list)
		{
			if (list == null)
			{
				throw new ArgumentNullException("list");
			}

			return ReverseIterator<T>(list);
		}

		public static IEnumerable<T> Where<T>(this IMyLinkedList<T> list, Predicate<T> predicate)
		{
			if (list == null)
			{
				throw new ArgumentNullException("list");
			}

			if (predicate == null)
			{
				throw new ArgumentNullException("predicate");
			}

			return WhereIterator<T>(list, predicate);
		}

		public static IEnumerable<T> Concat<T>(this IMyLinkedList<T> first, IMyLinkedList<T> second)
		{
			if (first == null)
			{
				throw new ArgumentNullException("first");
			}

			if (second == null)
			{
				throw new ArgumentNullException("first");
			}

			return ConcatIterator<T>(first, second);
		}

		public static IEnumerable<T> Union<T>(this IMyLinkedList<T> first, IMyLinkedList<T> second)
		{
			if (first == null)
			{
				throw new ArgumentNullException("first");
			}

			if (second == null)
			{
				throw new ArgumentNullException("first");
			}

			MyLinkedList<T> result = new MyLinkedList<T>();

			foreach (var item in first)
			{
				if (result.Contains(item))
				{
					continue;
				}

				result.AddLast(item);
			}

			foreach (var item in second)
			{
				if (result.Contains(item))
				{
					continue;
				}

				result.AddLast(item);
			}

			return result;
		}

		public static T First<T>(this IMyLinkedList<T> list, Predicate<T> predicate)
		{
			if (list == null)
			{
				throw new ArgumentNullException("list");
			}

			if (predicate == null)
			{
				throw new ArgumentNullException("predicate");
			}

			if (list.Count == 0)
			{
				throw new InvalidOperationException("list is empty");
			}

			foreach (var item in list)
			{
				if (predicate(item))
				{
					return item;
				}
			}

			throw new InvalidOperationException("There is no such entity");
		}

		public static T FirstOrDefault<T>(this IMyLinkedList<T> list, Predicate<T> predicate)
		{
			if (list == null)
			{
				throw new ArgumentNullException("list");
			}

			if (predicate == null)
			{
				throw new ArgumentNullException("predicate");
			}

			foreach (var item in list)
			{
				if (predicate(item))
				{
					return item;
				}
			}

			return default(T);
		}

		public static T Single<T>(this IMyLinkedList<T> list, Predicate<T> predicate)
		{
			if (list == null)
			{
				throw new ArgumentNullException("list");
			}

			if (predicate == null)
			{
				throw new ArgumentNullException("predicate");
			}

			if (list.Count == 0)
			{
				throw new InvalidOperationException("list is empty");
			}

			IMyLinkedList<T> resultList = new MyLinkedList<T>();

			foreach (var item in list)
			{
				if (predicate(item))
				{
					resultList.Add(item);
				}
			}

			if (resultList.Count > 1)
			{
				throw new InvalidOperationException("list contains more than 1 element");
			}

			return resultList.First.Value;
		}

		public static T SingleOrDefault<T>(this IMyLinkedList<T> list, Predicate<T> predicate)
		{
			if (list == null)
			{
				throw new ArgumentNullException("list");
			}

			if (predicate == null)
			{
				throw new ArgumentNullException("predicate");
			}

			if (list.Count == 0)
			{
				throw new InvalidOperationException("list is empty");
			}

			IMyLinkedList<T> resultList = new MyLinkedList<T>();

			foreach (var item in list)
			{
				if (predicate(item))
				{
					resultList.Add(item);
				}
			}

			if (resultList.Count > 1)
			{
				return default(T);
			}

			return resultList.First.Value;
		}
		
		public static int Count<T>(this IMyLinkedList<T> list, Predicate<T> predicate)
		{
			if (list == null)
			{
				throw new ArgumentNullException("list");
			}

			if (predicate == null)
			{
				throw new ArgumentNullException("predicate");
			}

			int count = 0;
			
			foreach (var item in list)
			{
				if (predicate(item))
				{
					count++;
				}
			}

			return count;
		}

		public static bool Any<T>(this IMyLinkedList<T> list, Predicate<T> predicate)
		{
			if (list == null)
			{
				throw new ArgumentNullException("list");
			}

			if (predicate == null)
			{
				throw new ArgumentNullException("predicate");
			}

			foreach (var item in list)
			{
				if (predicate(item))
				{
					return true;
				}
			}

			return false;
		}

		public static bool All<T>(this IMyLinkedList<T> list, Predicate<T> predicate)
		{
			if (list == null)
			{
				throw new ArgumentNullException("list");
			}

			if (predicate == null)
			{
				throw new ArgumentNullException("predicate");
			}

			foreach (var item in list)
			{
				if (!predicate(item))
				{
					return false;
				}
			}

			return true;
		}

		public static void Replace<T>(this IMyLinkedList<T> list, T value, Predicate<T> predicate)
		{
			if (list == null)
			{
				throw new ArgumentNullException("list");
			}

			if (predicate == null)
			{
				throw new ArgumentNullException("predicate");
			}

			MyLinkedListNode<T> current = list.First;

			while (current != null)
			{
				if (predicate(current.Value))
				{
					current.Value = value;
					return;
				}

				current = current.Next;
			}
		}

		public static void ReplaceAll<T>(this IMyLinkedList<T> list, T value, Predicate<T> predicate)
		{
			if (list == null)
			{
				throw new ArgumentNullException("list");
			}

			if (predicate == null)
			{
				throw new ArgumentNullException("predicate");
			}

			MyLinkedListNode<T> current = list.First;

			while (current != null)
			{
				if (predicate(current.Value))
				{
					current.Value = value;
				}

				current = current.Next;
			}
		}

		private static IEnumerable<T> SkipWhileIterator<T>(this IMyLinkedList<T> list, Predicate<T> predicate)
		{
			MyLinkedListNode<T> current = list.First;

			while ((current != null) && (predicate(current.Value)))
			{
				current = current.Next;
			}

			while (current != null)
			{
				yield return current.Value;
				current = current.Next;
			}
		}

		private static IEnumerable<T> TakeWhileIterator<T>(this IMyLinkedList<T> list, Predicate<T> predicate)
		{
			foreach (var item in list)
			{
				if (!predicate(item))
				{
					break;
				}

				yield return item;
			}
		}

		private static IEnumerable<TResult> SelectIterator<TSource, TResult>(this IMyLinkedList<TSource> source, Func<TSource, TResult> selector)
		{
			foreach (var item in source)
			{
				yield return selector(item);
			}
		}

		private static IEnumerable<T> ReverseIterator<T>(this IMyLinkedList<T> list)
		{
			MyLinkedListNode<T> current = list.Last;

			while (current != null)
			{
				yield return current.Value;
				current = current.Previous;
			}
		}

		private static IEnumerable<T> WhereIterator<T>(this IMyLinkedList<T> list, Predicate<T> predicate)
		{
			foreach (var item in list)
			{
				if (predicate(item))
				{
					yield return item;
				}
			}
		}

		private static IEnumerable<T> ConcatIterator<T>(this IMyLinkedList<T> first, IMyLinkedList<T> second)
		{
			foreach (var item in first)
			{
				yield return item;
			}

			foreach (var item in second)
			{
				yield return item;
			}
		}
	}
}