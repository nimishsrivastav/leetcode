public class Node {
    public int key;
    public int value;
    public Node prev;
    public Node next;
    
    public Node(int key, int value) {
        this.key = key;
        this.value = value;
    }
}

public class LRUCache {
    private int capacity;
    private Dictionary<int, Node> cache;
    private Node head;
    private Node tail;
    
    public LRUCache(int capacity) {
        this.capacity = capacity;
        cache = new Dictionary<int, Node>();
        head = new Node(-1, -1);
        tail = new Node(-1, -1);
        head.next = tail;
        tail.prev = head;
    }
    
    public int Get(int key) {
        if (!cache.ContainsKey(key)) return -1;

        Node node = cache[key];
        
        Remove(node);
        Add(node);

        return node.value;
    }
    
    public void Put(int key, int value) {
        if (cache.ContainsKey(key)) {
            Node existingNode = cache[key];
            Remove(existingNode);
        }
        
        Node node = new Node(key, value);
        cache[key] = node;
        Add(node);

        if (cache.Count > capacity) {
            Node nodeToDelete = head.next;
            Remove(nodeToDelete);
            cache.Remove(nodeToDelete.key);
        }
    }

    private void Add(Node node) {
        Node prevNode = tail.prev;
        prevNode.next = node;
        node.prev = prevNode;
        node.next = tail;
        tail.prev = node;
    }

    private void Remove(Node node) {
        node.prev.next = node.next;
        node.next.prev = node.prev;
    }
}

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */