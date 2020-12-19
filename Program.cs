using System;

namespace TMP_46
{
  class Program
	{ 
		static Stack FlipStack(ref Stack stackToFlip) // Переворачиваем стек
		{
			Stack reversedStack = new Stack();
			while (stackToFlip.Size > 0)
				reversedStack.Push(stackToFlip.Pop);
			return reversedStack;
		}

		static void NaturalMerge(ref Stack stackToSort)
		{
			Stack sorted = new Stack(); // Сюда мы будем записывать часть стека, которая уже отсортирована			
			int pop = stackToSort.Pop;
			sorted.Push(pop);
			while(stackToSort.Size > 0)
			{
				if (sorted.Back < stackToSort.Back)
				{					
					pop = stackToSort.Pop;
					sorted.Push(pop);					
				}
				else
					break;
			}
			
			Stack toSort = new Stack(stackToSort);
			if (toSort.Size > 0)
			{
				NaturalMerge(ref toSort); // Рекурсивно разбиваем на сортированные отрезки оставшуюся часть стека				
			}
			
			sorted = FlipStack(ref sorted);
			
			stackToSort.Clear(); // Очищаем стек, чтобы записать в него сортированные данные
			
			while (sorted.Size > 0 && toSort.Size > 0) // Заносим, параллельно сортируя, элементы обратно в основной стек
			{				
				if (sorted.Back < toSort.Back)
					stackToSort.Push(sorted.Pop);
				else
					stackToSort.Push(toSort.Pop);						
			}
			while (sorted.Size > 0)
				stackToSort.Push(sorted.Pop);
			while (toSort.Size > 0)
				stackToSort.Push(toSort.Pop);
			stackToSort = FlipStack(ref stackToSort);
		} 

		static void Main()
		{
			Console.WriteLine("Write count of numbers:");
			int countOfNumbers = Convert.ToInt32(Console.ReadLine());
			Random rand = new Random();

			Stack stackToSort = new Stack();

			for (int i = 0; i < countOfNumbers; ++i)
			{
				stackToSort.Push(rand.Next(-50, 100));
			}
			//stackToSort.Push(6); stackToSort.Push(5); stackToSort.Push(3); stackToSort.Push(4);

			Console.WriteLine("Original stack:");

			Stack output = new Stack(stackToSort);
			int size = output.Size;
			for (int i = 0; i < size; ++i)
			{
				Console.Write($"{output.Pop}\t");
			}

			NaturalMerge(ref stackToSort);
			
			Console.WriteLine("\nSorted stack:");

			size = stackToSort.Size;
			for (int i = 0; i < size; ++i)
			{
				Console.Write($"{stackToSort.Pop}\t");
			}
		}
	}
}