using System;


namespace MyCollections
{
	class Program
	{
		static void Main(string[] args)
		{
			MyLinkedList<int> first = new MyLinkedList<int>();
			
			first.AddLast(1);
			first.AddLast(2);
			first.AddLast(2);
			first.AddLast(3);
			first.AddLast(3);

			MyLinkedList<int> second = new MyLinkedList<int>();
			
			second.AddLast(1);
			second.AddLast(2);
			second.AddLast(2);
			second.AddLast(3);
			second.AddLast(4);
			second.AddLast(5);
			second.AddLast(3);
			second.AddLast(5);

			MyLinkedList<int> result = first.Union(second).ToMyLinkedList();

			Console.WriteLine("Union: ");
			foreach (var item in result)
			{
				Console.WriteLine(item);
			}

			Console.WriteLine();
			
			Console.WriteLine("Skip While < 3: ");
			foreach (var item in result.SkipWhile(x => x < 3))
			{
				Console.WriteLine(item);
			}

			Console.ReadLine();
		}
	}
}
