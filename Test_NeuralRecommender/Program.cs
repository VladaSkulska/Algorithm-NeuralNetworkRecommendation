using System;
public class Program
{
    public static void Main(string[] args)
    {
        var testData = new TestData();

        testData.Test_1();
        testData.Test_2();
        testData.Test_3();
        testData.Test_4();
        testData.Test_5();
        testData.Test_6();
    }
}

public class Al
{
    public static int Recommend(int[][] nodes)
    {
        if (nodes == null || nodes.Length == 0)
        {
            return 0;
        }

        int layers = nodes.Length;
        int maxSum = 0;

        Stack<(int, int, int)> stack = new Stack<(int, int, int)>();

        stack.Push((0, 0, nodes[0][0]));

        while (stack.Count > 0)
        {
            var (layer, index, sum) = stack.Pop();

            if (layer == layers - 1)
            {
                if (sum > maxSum)
                {
                    maxSum = sum;
                }

                continue;
            }

            int nextLayer = layer + 1;

            for (int i = index; i <= index + 1 && i < nodes[nextLayer].Length; i++)
            {
                int nextValue = nodes[nextLayer][i];
                stack.Push((nextLayer, i, sum + nextValue));
            }
        }

        return maxSum;
    }
}

public class Al2
{
    public static int Recommend(int[][] nodes)
    {
        if (nodes == null || nodes.Length == 0)
        {
            return 0;
        }

        int layers = nodes.Length;
        int maxSum = 0;

        List<int> sums = new List<int>();

        Explore(nodes, sums, layers, 0, 0, nodes[0][0]);

        foreach (int sum in sums)
        {
            if (sum > maxSum)
            {
                maxSum = sum;
            }
        }

        return maxSum;
    }

    private static void Explore(int[][] nodes, List<int> sums, int layers, int layer, int index, int sum)
    {
        if (layer == layers - 1)
        {
            sums.Add(sum);
            return;
        }

        int nextLayer = layer + 1;

        for (int i = index; i <= index + 1 && i < nodes[nextLayer].Length; i++)
        {
            int nextValue = nodes[nextLayer][i];

            Explore(nodes, sums, layers, nextLayer, i, sum + nextValue);
        }
    }
}

public class Al3
{
    public static int Recommend(int[][] nodes)
    {
        if (nodes == null || nodes.Length == 0)
        {
            return 0;
        }

        int layers = nodes.Length;
        int[,] maxSum = new int[layers, layers];

        for (int i = 0; i < layers; i++)
        {
            maxSum[layers - 1, i] = nodes[layers - 1][i];
        }

        for (int layer = layers - 2; layer >= 0; layer--)
        {
            for (int index = 0; index < nodes[layer].Length; index++)
            {
                maxSum[layer, index] = nodes[layer][index] +
                                   Math.Max(maxSum[layer + 1, index],
                                            index + 1 < nodes[layer + 1].Length ? maxSum[layer + 1, index + 1] : 0);
            }
        }

        return maxSum[0, 0];
    }
}

public class TestData
{
    public void Test_1()
    {
        int[][] nodes1 = new int[][]
        {
                new int[] { 5 },
                new int[] { 7, 3 },
                new int[] { 6, 8, 10 },
                new int[] { 12, 9, 13, 16 }
        };

        int result = Al.Recommend(nodes1);
        Console.WriteLine($"Result 1: {result}");
        //Expected Result: 34
    }

    public void Test_2()
    {
        int[][] nodes2 = new int[][]
        {
                new int[] { 2 },
                new int[] { 3, 4 },
        };

        int result = Al.Recommend(nodes2);
        Console.WriteLine($"Result 2: {result}");
        //Expected Result: 6
    }

    public void Test_3()
    {
        int[][] nodes3 = new int[][]
        {

        };

        int result = Al.Recommend(nodes3);
        Console.WriteLine($"Result 3: {result}");
        //Expected Result: 0
    }

    public void Test_4()
    {
        int[][] nodes4 = new int[][]
        {
            new int[] { 5 },
            new int[] { 7, 8 },
            new int[] { 2, 4, 3 },
            new int[] { 9, 12, 10, 9 },
            new int[] { 6, 7, 8, 12, 10 }
        };

        int result = Al.Recommend(nodes4);
        Console.WriteLine($"Result 4: {result}");
        //Expected Result: 39
    }

    public void Test_5()
    {
        int[][] nodes5 = new int[][]
        {
            new int[] { 5 },
            new int[] { 7, 8 },
            new int[] { 2, 12, 4 },
            new int[] { 9, 10, 12, 9 },
            new int[] { 6, 7, 8, 13, 10 }
        };

        int result = Al.Recommend(nodes5);
        Console.WriteLine($"Result 5: {result}");
        //Expected Result: 50
    }

    public void Test_6()
    {
        int[][] nodes6 = new int[][]
        {
            new int[] { 10 },
            new int[] { 11, 8 },
            new int[] { 12, 3, 4 },
            new int[] { 13, 10, 12, 9 },
            new int[] { 14, 7, 8, 13, 10 }
        };

        int result = Al.Recommend(nodes6);
        Console.WriteLine($"Result 6: {result}");
        //Expected Result: 60
    }
}
