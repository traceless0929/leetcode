using System;
using System.Collections.Generic;

namespace Play
{
    public class LRUCache
    {
        private Dictionary<int, DListNode> _lruValDic = null;
        private int _size = 0;
        private DListNode head;
        private DListNode tail;
        public LRUCache(int capacity)
        {
            _lruValDic = new Dictionary<int, DListNode>(capacity);
            _size = capacity;
            head = new DListNode(-1,-1);
            tail = new DListNode(-1,-1);
            head.Next = tail;
            head.Pre = tail;
            tail.Next = head;
            tail.Pre = head;
        }

        public void RemoveNode(DListNode node)
        {
            node.Pre.Next = node.Next;
            node.Next.Pre = node.Pre;
        }

        public void AddNode(DListNode node)
        {
            node.Pre = tail.Pre;
            node.Next = tail;
            tail.Pre.Next = node;
            tail.Pre = node;
        }
    
        public int Get(int key) {
            if (_lruValDic.TryGetValue(key, out DListNode outNode))
            {
                RemoveNode(outNode);
                AddNode(outNode);
                return outNode.val;
            }
            else
            {
                return -1;
            }
        }
    
        public void Put(int key, int value) {
            if (_lruValDic.TryGetValue(key, out DListNode outNode))
            {
                outNode.val = value;
                RemoveNode(outNode);
                AddNode(outNode);
            }
            else
            {
                var newDNode = new DListNode(key, value);
                AddNode(newDNode);
                _lruValDic.Add(key,newDNode);
                if (_lruValDic.Count > _size)
                {
                    _lruValDic.Remove(head.Next.Key);
                    RemoveNode(head.Next);
                }
            }
        }
        
        public class DListNode
        {
            public DListNode Pre = null;
            public DListNode Next = null;
            public int Key;
            public int val;

            public DListNode(int key, int val)
            {
                this.Key = key;
                this.val = val;
            }
            
        }
    }
}