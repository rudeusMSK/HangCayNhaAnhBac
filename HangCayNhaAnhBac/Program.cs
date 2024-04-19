using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HangCayNhaAnhBac
{
    internal class Program
    {
        static readonly int Maxsize = 100;

        static string treeline = "affabbcfdabc"; //aabcdabc

        static void Main(string[] args)
        {
            
            int remaining_trees = 0;

            ArrayList listcate = new ArrayList();

            //Console.WriteLine("nhap:");
            //  treeline = Console.ReadLine();

            Console.WriteLine($"hang cay: {treeline} ");

            remaining_trees = treeline.Length <= 0 ? remaining_trees : treeline.Length;
            if (remaining_trees == 0)
            {
                Console.WriteLine($"Output: {remaining_trees}");
            }
            else
            {
                // lấy danh sách loại cây từ hàng cây
               
                listcate = GetTrees(treeline);

                CutTree(listcate);

                Console.WriteLine();
                Console.WriteLine("cat nhung cay cung loai dang ke nhau:");

                foreach (char output in listcate)
                {
                    Console.Write($"{output}");
                }

                Console.WriteLine();
                Console.WriteLine("hang cay nho nhat");

                while (Catesize(listcate).Count > 2)
                {
                    char min = FindMinTree(listcate);
                    Console.Write($"min: {min}\n");

                    listcate = RemoveTree(min,listcate);

                    char tree = FindDuplicateTrees(listcate);

                    while(tree != (char)default)
                    {
                        Console.WriteLine($"tree {tree} bi trung !");

                        listcate = RemoveTree(tree, listcate);

                        Console.WriteLine($"hang cay sau khi xoa {tree}");
                        foreach (char output in listcate)
                        {
                            Console.Write($"{output}");
                        }
                        Console.WriteLine();
                        tree = FindDuplicateTrees(listcate);
                    }

                    Console.WriteLine();
                    foreach (char output in listcate)
                    {
                        Console.Write($"{output}");
                    }
                    Console.WriteLine();
                }



                Console.WriteLine();
                if (Catesize(listcate).Count < 2)
                {
                    Console.Write($"ket luan: khong co cay de cat duoc hang cay xem ke nhau");
                }
                else
                {
                    foreach (char output in listcate)
                    {
                        Console.Write($"{output}");
                    }
                }

            }

            Console.ReadKey();

        }
        static ArrayList GetTrees(string treeline)
        {
            ArrayList cate_tree = new ArrayList();
            char[] tree = treeline.ToCharArray();
            foreach (char t in tree)
            {
                cate_tree.Add(t);
            }
            return cate_tree;
        }
        static char FindDuplicateTrees(ArrayList trees)
        {
            int item = 0;
            while (item < trees.Count - 1)
            {
                // so sánh hiện tại với phần tử sau
                if (trees[item].Equals(trees[item + 1]))
                {
                    return (char)trees[item];
                }
                else
                {
                    item++;
                }
            }
            return (char)default;
        }
        static ArrayList RemoveTree(char tree, ArrayList listcate)
        {
            int item = 0;
            while (item < listcate.Count)
            {
                // so sánh và loại bỏ cây nếu trùng khớp
                if ((char)listcate[item] == tree)
                {
                    listcate.RemoveAt(item);
                }
                else
                {
                    item++;
                }
            }
            return listcate;
        }
        static char FindMinTree(ArrayList listcate)
        {
            List<Tuple<char, int>> cate = Catesize(listcate);
            
            if (cate.Count == 0)
            {
                return default;
            }

            char min = cate[0].Item1;
            int minSize = cate[0].Item2;

            for (int i = 1; i < cate.Count; i++)
            {
                if (cate[i].Item2 < minSize)
                {
                    min = cate[i].Item1;
                    minSize = cate[i].Item2;
                }
            }

            return min;
        }
        static void CutTree(ArrayList listcate)
        {
            for (int i = 0; i < listcate.Count; i++)
            {
                // tìm cây bị trùng:
                char tree = FindDuplicateTrees(listcate);

                // nếu có cây trùng:
                while (tree != default)
                {
                    // xóa cây:
                    RemoveTree(tree, listcate);

                    // nếu xóa cây còn 1 loại thì ko xen kẽ được
                    if (Catesize(listcate).Count <= 1)
                    {
                        Console.WriteLine("ko tìm thấy cây để cắt");
                        Console.ReadKey();
                        return;
                    }
                    else
                    {
                        // tìm đến khi hết các cây bị trùng
                        tree = FindDuplicateTrees(listcate);
                    }
                }
            }
        }
        static List<Tuple<char, int>> Catesize(ArrayList list)
        {
            List<Tuple<char, int>> cateTreeSize = new List<Tuple<char, int>>();

            for (int item = 0; item < list.Count; item++)
            {
                int count = 0;
                char cateTree = (char)list[item];

                for (int tree = 0; tree < list.Count; tree++)
                {
                    if ((char)list[tree] == cateTree)
                        count++;
                }

                cateTreeSize.Add(Tuple.Create(cateTree, count));
            }

            cateTreeSize = cateTreeSize.Distinct().ToList();
            return cateTreeSize;
        }


    }
}
