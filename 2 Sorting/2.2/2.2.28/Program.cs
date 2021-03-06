﻿using System;
using Merge;

namespace _2._2._28
{
    /*
     * 2.2.28
     * 
     * 自顶向下和自底向上。
     * 对于 N=10^3、10^4、10^5 和 10^6，
     * 使用 SortCompare 比较自顶向下和自底向上的归并排序的性能。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            int n = 1000;
            MergeSort topBottomMergeSort = new MergeSort();
            MergeSortBU bottomUpMergeSort = new MergeSortBU();
            int trialTimes = 100;
            for (int i = 0; i < 4; i++)
            {
                Console.Write("数组大小：" + n + "\t");
                int time1 = 0, time2 = 0;
                for (int j = 0; j < trialTimes; j++)
                {
                    double[] data1 = SortCompare.GetRandomArrayDouble(n);
                    double[] data2 = new double[n];
                    data1.CopyTo(data2, 0);
                    time1 += (int)SortCompare.Time(topBottomMergeSort, data1);
                    time2 += (int)SortCompare.Time(bottomUpMergeSort, data2);
                }
                
                Console.WriteLine("自顶向下：" + time1 / trialTimes + "ms\t自底向上：" + time2 / trialTimes + "ms");
                n *= 10;
            }
        }
    }
}
