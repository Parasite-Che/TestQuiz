using System.Collections.Generic;
using System.Linq;

public class ListController
{
    public List<int> RandomValues(int countOfAll, int countOfNeed)
    {
        List<int> numbers = CreateSerialArray(countOfAll);

        System.Random random = new System.Random();

        List<int> shuffledNumbers = numbers.OrderBy(x => random.Next()).ToList();

        return shuffledNumbers.Take(countOfNeed).ToList();
    }

    public List<int> CreateSerialArray(int count) 
    {
        List<int> nums = new List<int>(); // Создаем массив длиной n + 1

        for (int i = 0; i < count; i++)
        {
            nums.Add(i);
        }
        return nums;
    }
}
