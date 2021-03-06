﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _1._3._31
{
    /*
     * 1.3.31
     * 
     * 实现一个嵌套类 DoubleNode 用来构造双向链表，
     * 其中每个结点都含有一个指向前驱元素的应用和一项指向后续元素的引用（如果不存在则为 null）。
     * 为以下任务实现若干静态方法：
     * 在表头插入结点。
     * 在表尾插入结点。
     * 从表头删除结点。
     * 从表尾删除结点。
     * 在指定结点之前插入新结点。
     * 在指定结点之后插入新结点。
     * 删除指定结点。
     * 
     */
     /// <summary>
     /// 双向链表。
     /// </summary>
     /// <typeparam name="Item">链表中要存放的元素。</typeparam>
    public class DoubleLinkList<Item> : IEnumerable<Item>
    {
        private class DoubleNode<T>
        {
            public T item;
            public DoubleNode<T> prev;
            public DoubleNode<T> next;
        }
        DoubleNode<Item> first;
        DoubleNode<Item> last;
        int count;

        /// <summary>
        /// 建立一条双向链表。
        /// </summary>
        public DoubleLinkList()
        {
            this.first = null;
            this.last = null;
            this.count = 0;
        }

        /// <summary>
        /// 检查链表是否为空。
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return this.count == 0;
        }

        /// <summary>
        /// 返回链表中元素的数量。
        /// </summary>
        /// <returns></returns>
        public int Size()
        {
            return this.count;
        }

        /// <summary>
        /// 在表头插入一个元素。
        /// </summary>
        /// <param name="item">要插入的元素。</param>
        public void InsertFront(Item item)
        {
            DoubleNode<Item> node = new DoubleNode<Item>()
            {
                item = item,
                next = this.first,
                prev = null
            };
            if (this.first != null)
            {
                this.first.prev = node;
            }
            else
            {
                this.last = node;
            }
            this.first = node;
            this.count++;
        }

        /// <summary>
        /// 在表尾插入一个元素。
        /// </summary>
        /// <param name="item">要插入表尾的元素。</param>
        public void InsertRear(Item item)
        {
            DoubleNode<Item> node = new DoubleNode<Item>()
            {
                item = item,
                next = null,
                prev = this.last
            };
            if (this.last != null)
            {
                this.last.next = node;
            }
            else
            {
                this.first = node;
            }
            this.last = node;
            this.count++;
        }

        /// <summary>
        /// 检索指定下标的元素。
        /// </summary>
        /// <param name="index">要检索的下标。</param>
        /// <returns></returns>
        public Item At(int index)
        {
            if (index >= this.count || index < 0)
                throw new IndexOutOfRangeException();

            DoubleNode<Item> current = this.first;
            for (int i = 0; i < index; i++)
            {
                current = current.next;
            }
            return current.item;
        }

        /// <summary>
        /// 返回指定下标的结点。
        /// </summary>
        /// <param name="index">要查找的下标。</param>
        /// <returns></returns>
        private DoubleNode<Item> Find(int index)
        {
            if (index >= this.count || index < 0)
                throw new IndexOutOfRangeException();

            DoubleNode<Item> current = this.first;
            for (int i = 0; i < index; i++)
            {
                current = current.next;
            }
            return current;
        }

        /// <summary>
        /// 在指定位置之前插入一个元素。
        /// </summary>
        /// <param name="item">要插入的元素。</param>
        /// <param name="index">插入位置的下标。</param>
        public void InsertBefore(Item item, int index)
        {
            if (index == 0)
            {
                InsertFront(item);
                return;
            }

            if (index >= this.count || index < 0)
                throw new IndexOutOfRangeException();

            DoubleNode<Item> current = Find(index);
            DoubleNode<Item> node = new DoubleNode<Item>()
            {
                next = current,
                prev = current.prev,
                item = item
            };
            current.prev.next = node;
            current.prev = node;
            this.count++;
        }

        /// <summary>
        /// 在指定位置之后插入一个元素。
        /// </summary>
        /// <param name="item">要插入的元素。</param>
        /// <param name="index">查找元素的下标。</param>
        public void InsertAfter(Item item, int index)
        {
            if (index == this.count - 1)
            {
                InsertRear(item);
                return;
            }

            if (index >= this.count || index < 0)
                throw new IndexOutOfRangeException();

            DoubleNode<Item> current = Find(index);
            DoubleNode<Item> node = new DoubleNode<Item>()
            {
                prev = current,
                next = current.next,
                item = item
            };
            current.next.prev = node;
            current.next = node;
            this.count++;
        }

        /// <summary>
        /// 删除表头元素。
        /// </summary>
        /// <returns></returns>
        public Item DeleteFront()
        {
            if (IsEmpty())
                throw new InvalidOperationException("List underflow");

            Item temp = this.first.item;
            this.first = this.first.next;
            this.count--;
            if (IsEmpty())
            {
                this.last = null;
            }
            return temp;
        }

        /// <summary>
        /// 删除表尾的元素。
        /// </summary>
        /// <returns></returns>
        public Item DeleteRear()
        {
            if (IsEmpty())
                throw new InvalidOperationException("List underflow");

            Item temp = this.last.item;
            this.last = this.last.prev;
            this.count--;
            if (IsEmpty())
            {
                this.first = null;
            }
            else
            {
                this.last.next = null;
            }
            return temp;
        }

        /// <summary>
        /// 删除指定位置的元素。
        /// </summary>
        /// <param name="index">要删除元素的下标。</param>
        /// <returns></returns>
        public Item Delete(int index)
        {
            if (index < 0 || index >= this.count)
                throw new IndexOutOfRangeException();

            if (index == 0)
            {
                return DeleteFront();
            }

            if (index == this.count - 1)
            {
                return DeleteRear();
            }

            DoubleNode<Item> current = Find(index);
            Item temp = current.item;
            current.prev.next = current.next;
            current.next.prev = current.prev;
            this.count--;
            return temp;
        }

        public override string ToString()
        {
            StringBuilder s = new StringBuilder();

            foreach (Item i in this)
            {
                s.Append(i.ToString());
                s.Append(" ");
            }

            return s.ToString();
        }

        public IEnumerator<Item> GetEnumerator()
        {
            return new DoubleLinkListEnumerator(this.first);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class DoubleLinkListEnumerator : IEnumerator<Item>
        {
            DoubleNode<Item> current;
            DoubleNode<Item> first;

            public DoubleLinkListEnumerator(DoubleNode<Item> first)
            {
                this.current = new DoubleNode<Item>();
                this.current.next = first;
                this.first = this.current;
            }

            Item IEnumerator<Item>.Current => this.current.item;

            object IEnumerator.Current => this.current.item;

            void IDisposable.Dispose()
            {
                this.current = null;
                this.first = null;
            }

            bool IEnumerator.MoveNext()
            {
                if (this.current.next == null)
                    return false;
                this.current = this.current.next;
                return true;
            }

            void IEnumerator.Reset()
            {
                this.current = this.first;
            }
        }
    }
}
