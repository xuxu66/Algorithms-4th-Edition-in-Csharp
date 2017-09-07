﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnionFind
{
    /// <summary>
    /// 并查集。
    /// </summary>
    public class UF
    {
        private int[] parent; // 记录各个结点的父级。
        private int[] rank; // 记录各个分量的子树高度。
        private int count; // 分量数目。

        /// <summary>
        /// 新建一个大小为 n 的并查集。
        /// </summary>
        /// <param name="n">并查集的大小。</param>
        public UF(int n)
        {
            if (n < 0)
                throw new ArgumentException();
            this.count = n;
            this.parent = new int[n];
            this.rank = new int[n];
            for (int i = 0; i < n; ++i)
            {
                parent[i] = i;
                rank[i] = 0;
            }
        }

        /// <summary>
        /// 寻找 p 所在的连通分量。
        /// </summary>
        /// <param name="p">需要寻找的结点。</param>
        /// <returns>p 所在的连通分量。</returns>
        public int Find(int p)
        {
            Validate(p);
            while (p != this.parent[p])
            {
                this.parent[p] = this.parent[this.parent[p]];
                p = this.parent[p];
            }
            return p;
        }

        /// <summary>
        /// 合并两个结点所在的连通分量。
        /// </summary>
        /// <param name="p">需要合并的结点。</param>
        /// <param name="q">需要合并的另一个结点。</param>
        public void Union(int p, int q)
        {
            int rootP = Find(p);
            int rootQ = Find(q);

            if (rootP == rootQ)
            {
                return;
            }

            if (this.rank[rootP] < this.rank[rootQ])
            {
                this.parent[rootP] = rootQ;
            }
            else if (this.rank[rootP] < this.rank[rootQ])
            {
                this.parent[rootQ] = rootP;
            }
            else
            {
                this.parent[rootQ] = rootP;
                this.rank[rootP]++;
            }

            this.count--;
        }

        /// <summary>
        /// 返回分量的数目。
        /// </summary>
        /// <returns>分量的数目。</returns>
        public int Count()
        {
            return this.count;
        }

        /// <summary>
        /// 判断两个结点是否同属于一个连通分量。
        /// </summary>
        /// <param name="p">需要判断的结点。</param>
        /// <param name="q">需要判断的另一个结点。</param>
        /// <returns>两个结点是否同属于一个连通分量。</returns>
        public bool IsConnected(int p, int q)
        {
            return Find(p) == Find(q);
        }

        /// <summary>
        /// 检查输入的 p 是否符合条件。
        /// </summary>
        /// <param name="p">输入的 p 值。</param>
        private void Validate(int p)
        {
            int n = this.parent.Length;
            if (p < 0 || p >= n)
            {
                throw new ArgumentException("index" + p + " is not between 0 and " + (n - 1));
            }
        }

    }
}
