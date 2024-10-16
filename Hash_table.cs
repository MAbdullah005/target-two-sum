using System;
using System.Collections;
public class Hashtable<T>
{
    List<LinkedList<T>> value = new List<LinkedList<T>>();
    int[] key = new int[10];

    public Hashtable(int size)
    {
        for (int count = 0; count < size; count++)
        {
            value.Add(new LinkedList<T>());
        }
    }
    private int hash(int i)
    {
        return i % key.Length;
    }
    public void put(int key1, T value1)
    {
        key1 = hash(key1);
        if (value[key1].Contains(value1))
        {
            return;
        }
        value[key1].AddLast(value1);
    }
    public LinkedList<T> get(int key1)
    {
        key1 = hash(key1);
        return value[key1];
    }
    public void revmove(int key)
    {
        if (full(key) || value[key].Count == 0)
        {
            Console.WriteLine("no element to remove");
            return;
        }
        value[key].RemoveFirst();
    }
    private bool full(int key1)
    {
        return (key1 >= key.Length || key1 < 0);
    }
}
public class Program
{
    static void Main()
    {
        int[] array = new int[10];
        Hashtable<int> hashtable=new Hashtable<int>();
        for(int count=0;count < array.Length; count++)
        {
            array[count]=count; 
        }
        Console.WriteLine("entre a number to find two sum ");
        int target = Convert.ToInt32(Console.ReadLine());
        twosum(array,target,hashtable);
        foreach(var item in hashtable)
        {
            Console.WriteLine(item);
        }
    }
    
static void twosum(int[] array, int target, Hashtable<int> abd)
{
    for (int i = 0; i < array.Length; i++)
    {
        for (int count = i + 1; count < array.Length; count++)
        {
            if (Math.Abs(array[i] + array[count]) == target)
            {
                abd.put(i, i);
                abd.put(i, count);
            }
        }
    }
}

}