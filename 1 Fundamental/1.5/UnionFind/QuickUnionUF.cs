﻿namespace UnionFind
{
    /// <summary>
    /// 用 QuickUnion 算法实现的并查集。
    /// </summary>
    public class QuickUnionUF : UF
    {
        public int ArrayVisitCount { get; private set; } //记录数组访问的次数。

        /// <summary>
        /// 建立使用 QuickUnion 的并查集。
        /// </summary>
        /// <param name="n">并查集的大小。</param>
        public QuickUnionUF(int n) : base(n) { }

        /// <summary>
        /// 重置数组访问计数。
        /// </summary>
        public virtual void ResetArrayCount()
        {
            this.ArrayVisitCount = 0;
        }

        /// <summary>
        /// 获得 parent 数组。
        /// </summary>
        /// <returns>返回 parent 数组。</returns>
        public int[] GetParent()
        {
            return this.parent;
        }

        /// <summary>
        /// 寻找一个结点所在的连通分量。
        /// </summary>
        /// <param name="p">需要寻找的结点。</param>
        /// <returns>该结点所属的连通分量。</returns>
        public override int Find(int p)
        {
            Validate(p);
            while (p != this.parent[p])
            {
                p = this.parent[p];
                this.ArrayVisitCount += 2;
            }
            return p;
        }

        /// <summary>
        /// 将两个结点所属的连通分量合并。
        /// </summary>
        /// <param name="p">需要合并的结点。</param>
        /// <param name="q">需要合并的另一个结点。</param>
        public override void Union(int p, int q)
        {
            int rootP = Find(p);
            int rootQ = Find(q);
            if (rootP == rootQ)
            {
                return;
            }

            this.parent[rootP] = rootQ;
            this.ArrayVisitCount++;
            this.count--;
        }
    }

}
