using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HangCayNhaAnhBac_v2
{
    internal class Program
    {
        static readonly int Maxsize = 100;

        static string treeline = "aabcdabc"; //aabcdabc

        static ArrayList arrListStr;

        static void Main(string[] args)
        {

            int remaining_trees = 0;
            arrListStr = new ArrayList();

            Console.WriteLine();
            // treeline = Console.ReadLine();

            // step1: kt xem là hàng cây có cây hay 0
            remaining_trees = treeline.Length <= 0 ? remaining_trees : treeline.Length;
            if (remaining_trees == 0)
            {
                Console.WriteLine($"Output: {remaining_trees}");
            }
            else
            {
                ArrayList trees = GetTrees(treeline);
                FindDuplicateTrees(trees);

                while (CateTreelist().Count > 2)
                {
                    RemoveTree(FindMinTree());
                }

                // in ra danh sách cây sau khi xóa
                foreach (char tree in arrListStr)
                {
                    Console.Write($"{tree} ");
                }
            }

            Console.ReadKey();

        }
        static ArrayList GetTrees(string treeline)
        {
            char[] tree = treeline.ToCharArray();
            foreach (char t in tree)
            {
                arrListStr.Add(t);
            }
            return arrListStr;
        }
        static ArrayList FindDuplicateTrees(ArrayList trees)
        {
            int item = 0;
            while (item < trees.Count - 1)
            {
                // so sánh hiện tại với phần tử sau
                if (trees[item].Equals(trees[item + 1]))
                {
                    // Loại bỏ cây trùng lặp
                    RemoveTree((char)trees[item]);
                    FindDuplicateTrees(arrListStr);

                }
                else
                {
                    item++;
                }
            }
            return arrListStr;
        }
        static void RemoveTree(char tree)
        {
            int item = 0;
            while (item < arrListStr.Count)
            {
                // so sánh và loại bỏ cây nếu trùng khớp
                if ((char)arrListStr[item] == tree)
                {
                    arrListStr.RemoveAt(item);
                }
                else
                {
                    item++;
                }
            }
        }
        static char FindMinTree()
        {
            List<Tuple<char, int>> cateTreeSize = CateTreelist();

            char min = cateTreeSize[0].Item1;
            for (int i = 0; i < cateTreeSize.Count - 1; i++)
            {
                if (cateTreeSize[i].Item2 < cateTreeSize[i + 1].Item2)
                {
                    min = cateTreeSize[i].Item1;
                }

            }
            return min;
        }
        static List<Tuple<char, int>> CateTreelist()
        {
            List<Tuple<char, int>> cateTreeSize = new List<Tuple<char, int>>();

            for (int item = 0; item < arrListStr.Count; item++)
            {
                int count = 0;
                char cateTree = (char)arrListStr[item];

                for (int tree = 0; tree < arrListStr.Count; tree++)
                {
                    if ((char)arrListStr[tree] == cateTree)
                        count++;
                }

                cateTreeSize.Add(Tuple.Create(cateTree, count));
                count = 0;
            }
            return cateTreeSize;
        }
    }
}
