namespace TMP_46
{
  class Stack
  {
    private int[] _stack = new int[0]; // Стек

    public Stack()
		{

		}

    public Stack(Stack _oldStack) // Копируем стек в наш стек
    {
      int size = _oldStack.Size;
      Stack temp = new Stack();
      for (int i = 0; i < size; ++i)
      {
        int newNum = _oldStack.Pop;
        temp.Push(newNum);
      }

      size = temp.Size;
      for (int i = 0; i < size; ++i)
      {
        int newNum = temp.Pop;
        this.Push(newNum);
        _oldStack.Push(newNum);
      }
    }

    public int Size // Размер стека
    {
      get
      {
        int size = 0;

        foreach (int o in _stack) // Прибавляем 1 к размеру за каждый элемент в массифе
        {
          ++size;
        }

        return size;
      }
    }

    public void Push(int newElement) // Добавление элемента в конец стека
    {
      int[] temp = _stack; // Сохраняем элементы во временный стек

      _stack = new int[Size + 1]; // Делаем наш массив на 1 больше
      _stack[0] = newElement;

      for (int i = 1; i < Size; ++i) // Переписываем элементы обратно
        _stack[i] = temp[i - 1];
    }

    public int Pop // Вывод и удаление последнего элемента
    {
      get
      {
        int popped = _stack[0]; // Сохраняем значение, которое будем выводить
        int[] temp = _stack; // Сохраняем элементы во временный стек       

        _stack = new int[Size - 1]; // Уменьшаем размер стека на 1 

        for (int i = 0; i < Size; ++i) // Переписываем элементы обратно
          _stack[i] = temp[i + 1];

        return popped; // Возвращаем сохранённое значение
      }
    }

    public int Back // Вывод последнего элемента
    {
      get
      {
        return _stack[0];
      }
    }

    public void Clear() // Очищаем стек
    {
      _stack = new int[0];
    }
  }
}
