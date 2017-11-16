using System;
using System.Collections.Generic;
using System.Linq;

class ArrayManipulator
{
    static void Main()
    {
        var nums = Console.ReadLine().Split().Select(int.Parse).ToList();

        while (true)
        {
            var commands = Console.ReadLine().Split().ToList();

            if (commands[0] == "print")
            {
                break;
            }
            else if (commands[0] == "add")
            {
                AddValueInPosition(nums, commands);

            }
            else if (commands[0] == "addMany")
            {
                AddManyValues(nums, commands);
            }
            else if (commands[0] == "contains")
            {
                ListContains(nums, commands);
            }
            else if (commands[0] == "remove")
            {
                RemoveItem(nums, commands);
            }
            else if (commands[0] == "shift")
            {
                ShiftPosition(nums, commands);
            }
            else if (commands[0] == "sumPairs")
            {
                nums=SumPairs(nums, commands);                
            }
        }
        Console.WriteLine("[" + string.Join(", ", nums) + "]");
    }

    static List<int> SumPairs(List<int> nums, List<string> commands)
    {
        List<int> sum = new List<int>();
        while (nums.Count >= 2)
        {
            sum.Add(nums[0] + nums[1]);
            nums.RemoveAt(0);
            nums.RemoveAt(0);
        }
        if (nums.Count == 1)
        {
            sum.Add(nums[0]);
        }
        nums = sum;
        return nums;
    }

    static List<int> ShiftPosition(List<int> nums, List<string> commands)
    {
        var position = int.Parse(commands[1]);
        while (position > 0)
        {
            int first = nums[0];
            nums.RemoveAt(0);
            nums.Add(first);
            position--;
        }
        return nums;
    }

    static List<int> RemoveItem(List<int> nums, List<string> commands)
    {
        var index = int.Parse(commands[1]);
        nums.RemoveAt(index);
        return nums;
    }

    static void ListContains(List<int> nums, List<string> commands)
    {
        var element = int.Parse(commands[1]);
        if (nums.Contains(element))
        {
            Console.WriteLine(nums.IndexOf(element));
        }
        else
        {
            Console.WriteLine(-1);
        }
    }

    static List<int> AddManyValues(List<int> nums, List<string> commands)
    {
        var index = int.Parse(commands[1]);
        for (int i = commands.Count - 1; i >= 2; i--)
        {
            int element = int.Parse(commands[i]);
            nums.Insert(index, element);
        }
        return nums;
    }

    static List<int> AddValueInPosition(List<int> nums, List<string> commands)
    {
        var index = int.Parse(commands[1]);
        var element = int.Parse(commands[2]);
        nums.Insert(index, element);
        return nums;
    }
}