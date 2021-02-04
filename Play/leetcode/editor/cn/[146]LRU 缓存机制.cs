//运用你所掌握的数据结构，设计和实现一个 LRU (最近最少使用) 缓存机制 。 
//
// 
// 
// 实现 LRUCache 类： 
//
// 
// LRUCache(int capacity) 以正整数作为容量 capacity 初始化 LRU 缓存 
// int get(int key) 如果关键字 key 存在于缓存中，则返回关键字的值，否则返回 -1 。 
// void put(int key, int value) 如果关键字已经存在，则变更其数据值；如果关键字不存在，则插入该组「关键字-值」。当缓存容量达到上
//限时，它应该在写入新数据之前删除最久未使用的数据值，从而为新的数据值留出空间。 
// 
//
// 
// 
// 
//
// 进阶：你是否可以在 O(1) 时间复杂度内完成这两种操作？ 
//
// 
//
// 示例： 
//
// 
//输入
//["LRUCache", "put", "put", "get", "put", "get", "put", "get", "get", "get"]
//[[2], [1, 1], [2, 2], [1], [3, 3], [2], [4, 4], [1], [3], [4]]
//输出
//[null, null, null, 1, null, -1, null, -1, 3, 4]
//
//解释
//LRUCache lRUCache = new LRUCache(2);
//lRUCache.put(1, 1); // 缓存是 {1=1}
//lRUCache.put(2, 2); // 缓存是 {1=1, 2=2}
//lRUCache.get(1);    // 返回 1
//lRUCache.put(3, 3); // 该操作会使得关键字 2 作废，缓存是 {1=1, 3=3}
//lRUCache.get(2);    // 返回 -1 (未找到)
//lRUCache.put(4, 4); // 该操作会使得关键字 1 作废，缓存是 {4=4, 3=3}
//lRUCache.get(1);    // 返回 -1 (未找到)
//lRUCache.get(3);    // 返回 3
//lRUCache.get(4);    // 返回 4
// 
//
// 
//
// 提示： 
//
// 
// 1 <= capacity <= 3000 
// 0 <= key <= 3000 
// 0 <= value <= 104 
// 最多调用 3 * 104 次 get 和 put 
// 
// Related Topics 设计 
// 👍 1131 👎 0


//leetcode submit region begin(Prohibit modification and deletion)

using System.Collections.Generic;

public class LRUCache {
    
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

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */
//leetcode submit region end(Prohibit modification and deletion)
