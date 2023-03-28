using System;
using System.Drawing;

class Vector
{
    //Поля
    private double[] arr;
    private int size;
    private int capacity = 10;
    
    public int get_size() { return size; }
    public int get_capacity() { return capacity; }

    //Индексатор
    public double this[int index]
    {
        get { return arr[index]; }
        set { arr[index] = value; }
    }
    //Конструкторы
    public Vector()
    {
        size = 3;
        arr = new double[3] { 0, 0, 0 };
    }
    public Vector(double[] Array)
    {
        if (capacity < Array.Length)
            capacity = Array.Length;
        this.arr = (double[])Array.Clone();
        size = Array.Length;
    }

    //Проверка на переполненность
    public bool equals_sc()
    {
        if (size == capacity)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //Метод ввода
    public void input()
    {
        Console.Write("Введите размерность вектора: ");
        size = Convert.ToInt32(Console.ReadLine());
        capacity = size;
        arr = new double[capacity];
        Console.WriteLine("Введите элемнеты вектора:");
        string[] s = Console.ReadLine().Split(" ");
        for (int i = 0; i < size; i++)
        {
            arr[i] = Convert.ToDouble(s[i]);
        }
    }

    //Метод ToString
    public override string ToString()
    {
        string answer = "";
        for (int i = 0; i < size; i++)
        {
            answer += arr[i].ToString() + " ";
        }
        return answer;
    }

    //Добавление элемента в конец массива
    public void append(double new_elem)
    {
        if (equals_sc())
        {
            capacity = (int)(capacity * 1.5);
            Array.Resize(ref arr, capacity);
        }
        arr[size] = new_elem;
        size++;
    }

    //Удаление элемента из конца массива
    public void remove()
    {
        arr[size - 1] = 0;
        size--;
    }

    //Вставка элемента по индексу
    public void insert(double new_elem, int index)
    {
        if (equals_sc())
        {
            capacity = (int)(capacity * 1.5);
            Array.Resize(ref arr, capacity);
        }
        for (int i = size; i > index; i--)
        {
            arr[i] = arr[i - 1];
        }
        arr[index] = new_elem;
        size++;
    }

    //Удаление элемента по индексу
    public void pop(int index)
    {
        for (int i = index; i < size - 1; i++)
        {
            arr[i] = arr[i + 1];
        }
        arr[size - 1] = 0;
        size--;
    }

    //Удаление элемента по значению
    public void delete(double elem)
    {
        int i = lin_search(elem);
        while (i != -1)
        {
            pop(i);
            i = lin_search(elem);
        }
    }

    //Возврат индекса максимального элемента
    public int max_elem_index()
    {
        int index = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] > arr[index])
            {
                index = i;
            }
        }
        return index;
    }


    //Метод для линейного поиска элемента в массиве
    public int lin_search(double elem)
    {
        return Array.IndexOf(arr, elem);
    }
}