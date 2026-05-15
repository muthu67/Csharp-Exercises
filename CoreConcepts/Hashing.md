# Hashing: Core Concepts and Patterns

A comprehensive guide to hashing techniques using HashSet, Dictionary, and hashing patterns essential for DSA interviews.

---

## Table of Contents

1. [HashSet](#hashset)
2. [Dictionary](#dictionary)
3. [Frequency Maps](#frequency-maps)
4. [Fast Lookup](#fast-lookup)
5. [Duplicate Detection](#duplicate-detection)
6. [Counting Patterns](#counting-patterns)

---

## 1. HashSet

### Concept

A **HashSet** is an unordered collection of **unique elements** with O(1) average-case lookup, insertion, and deletion. It uses **hashing** to store and retrieve elements efficiently.

### Key Insights

- **Uniqueness**: Automatically eliminates duplicates on insertion
- **No ordering**: Elements have no guaranteed order (unlike SortedSet)
- **Hash collision handling**: Internal mechanism manages collisions
- **Best for**: Membership testing, duplicate removal, intersection/union operations

### Diagrams

#### HashSet Internal Structure (Simplified)
```
HashSet<int>

Hash Function: value % 10

Bucket Array:
[0]: 10, 20, 30, ...
[1]: 11, 21, 31, ...
[2]: 2, 12, 22, ...
[3]: 3, 13, 23, ...
[4]: 4, 14, 24, ...
[5]: 5, 15, 25, ...
[6]: 6, 16, 26, ...
[7]: 7, 17, 27, ...
[8]: 8, 18, 28, ...
[9]: 9, 19, 29, ...

Insert 7 → hash(7) = 7 % 10 = 7 → Bucket[7]
Lookup 7 → hash(7) = 7 → Bucket[7] → O(1) average
```

#### Adding Elements to HashSet
```
Initial:     { }

Add 3:       { 3 }

Add 3:       { 3 }  (duplicate ignored)

Add 7:       { 3, 7 }

Add 1:       { 3, 7, 1 }

Contains 7:  YES (O(1) lookup)
Contains 5:  NO  (O(1) lookup)
```

### Code Examples

#### Example 1: Create and Use HashSet (Beginner)
```csharp
public void BasicHashSetOperations()
{
    var set = new HashSet<int> { 1, 2, 3 };
    
    // Add elements
    set.Add(4);      // Returns true
    set.Add(4);      // Returns false (already exists)
    
    // Check membership
    bool has3 = set.Contains(3);  // true
    bool has10 = set.Contains(10);  // false
    
    // Remove elements
    set.Remove(3);   // Returns true
    set.Remove(100); // Returns false (not found)
    
    // Iterate (order not guaranteed)
    foreach (int num in set)
    {
        Console.WriteLine(num);
    }
    
    // Size and clear
    int count = set.Count;
    set.Clear();
}

// Time: O(1) average for all operations  |  Space: O(n)
```

#### Example 2: Remove Duplicates with HashSet (Beginner)
```csharp
public int[] RemoveDuplicates(int[] nums)
{
    var set = new HashSet<int>(nums);
    return set.ToArray();
}

/*
Input:  [1, 2, 2, 3, 3, 3, 1]
Output: [1, 2, 3] (order not guaranteed)
Time: O(n)  |  Space: O(n)
*/
```

#### Example 3: Set Operations - Union, Intersection (Intermediate)
```csharp
public void SetOperations()
{
    var set1 = new HashSet<int> { 1, 2, 3, 4 };
    var set2 = new HashSet<int> { 3, 4, 5, 6 };
    
    // Union: all elements from both sets
    set1.UnionWith(set2);  // {1, 2, 3, 4, 5, 6}
    
    // Intersection: only common elements
    var set3 = new HashSet<int> { 1, 2, 3, 4 };
    var set4 = new HashSet<int> { 3, 4, 5, 6 };
    set3.IntersectWith(set4);  // {3, 4}
    
    // Difference: elements in set1 but not in set2
    var set5 = new HashSet<int> { 1, 2, 3, 4 };
    var set6 = new HashSet<int> { 3, 4, 5, 6 };
    set5.ExceptWith(set6);  // {1, 2}
    
    // Check if subset/superset
    bool isSubset = set1.IsSubsetOf(set2);
}

// Time: O(n + m) for union/intersection  |  Space: O(n + m)
```

#### Example 4: Contains Duplicate Optimization (Intermediate)
```csharp
public bool ContainsDuplicate(int[] nums)
{
    var seen = new HashSet<int>();
    
    foreach (int num in nums)
    {
        if (seen.Contains(num))
            return true;  // Early exit on finding duplicate
        
        seen.Add(num);
    }
    
    return false;
}

/*
Input:  [99, 99]
Output: true
Time: O(n) average, O(n²) worst  |  Space: O(n)
Early exit: O(1) best case
*/
```

#### Example 5: Happy Number Detection with HashSet (Advanced)
```csharp
public bool IsHappyNumber(int n)
{
    var seen = new HashSet<int>();
    
    while (n != 1 && !seen.Contains(n))
    {
        seen.Add(n);
        n = SumOfSquares(n);
    }
    
    return n == 1;
}

private int SumOfSquares(int n)
{
    int sum = 0;
    while (n > 0)
    {
        int digit = n % 10;
        sum += digit * digit;
        n /= 10;
    }
    return sum;
}

/*
Input:  n=19
Steps:  19 → 1+81=82 → 64+4=68 → 36+64=100 → 1+0+0=1 → true
Time: O(log n) iterations, O(1) per iteration  |  Space: O(log n)
*/
```

### Complexity Analysis

| Operation | Average | Worst Case | Use Case |
|---|---|---|---|
| Add | O(1) | O(n) | Build set |
| Remove | O(1) | O(n) | Delete element |
| Contains | O(1) | O(n) | Membership test |
| Union | O(n+m) | O(n+m) | Combine sets |
| Intersection | O(min(n,m)) | O(n+m) | Common elements |

### Interview Tips & Common Mistakes

✅ **Do's:**
- Use HashSet for **quick membership testing** (O(1) vs. O(n) in array)
- Leverage **set operations** (union, intersection) for complex queries
- Remember **duplicates are ignored** - useful for deduplication

❌ **Don'ts:**
- Don't use HashSet when **order matters** (use List instead)
- Don't assume **worst case O(1)** - hash collisions can degrade to O(n)
- Don't forget **set is unordered** - ToArray() order is not guaranteed

**Interview Question Pattern:**
> "Does this number/element already exist? Can you do it in O(1) time?"

---

## 2. Dictionary

### Concept

A **Dictionary** (or Hash Map) is a collection of **key-value pairs** with O(1) average-case lookup, insertion, and deletion. It maps unique keys to values.

### Key Insights

- **Unique keys**: Each key maps to exactly one value
- **Fast lookup**: O(1) average by key
- **Ordered or unordered**: Dictionary is unordered in C#
- **Best for**: Caching, grouping, associative data structures

### Diagrams

#### Dictionary Internal Structure
```
Dictionary<string, int>

Hash Function: hashCode(key) % bucketSize

Key-Value Pairs:
"Alice" → 85
"Bob"   → 92
"Charlie" → 78
"Diana" → 95

Bucket Array:
[0]: ("Alice", 85) → ("Charlie", 78)
[1]: ("Bob", 92)
[2]: 
[3]: ("Diana", 95)
...

Lookup "Bob" → hash("Bob") → Bucket[1] → Value: 92 (O(1))
```

#### Key-Value Mapping
```
Student Grades:

Keys:     Alice   Bob    Charlie  Diana
          ↓       ↓       ↓       ↓
Values:   85      92      78      95

Dictionary["Alice"] = 85    (O(1) lookup)
Dictionary["Bob"] = 92      (O(1) lookup)
```

### Code Examples

#### Example 1: Basic Dictionary Operations (Beginner)
```csharp
public void BasicDictionaryOperations()
{
    var dict = new Dictionary<string, int>
    {
        { "Alice", 85 },
        { "Bob", 92 }
    };
    
    // Add
    dict["Charlie"] = 78;  // Add or update
    dict.Add("Diana", 95); // Add (throws if exists)
    
    // Lookup
    int aliceScore = dict["Alice"];  // 85 (throws if not found)
    bool exists = dict.TryGetValue("Eve", out int score);  // false
    
    // Remove
    dict.Remove("Bob");
    
    // Iterate
    foreach (var kvp in dict)
    {
        Console.WriteLine($"{kvp.Key}: {kvp.Value}");
    }
    
    // Clear
    dict.Clear();
}

// Time: O(1) average for all operations  |  Space: O(n)
```

#### Example 2: Frequency Counting with Dictionary (Beginner)
```csharp
public Dictionary<char, int> CharacterFrequency(string text)
{
    var frequency = new Dictionary<char, int>();
    
    foreach (char c in text)
    {
        if (frequency.ContainsKey(c))
            frequency[c]++;
        else
            frequency[c] = 1;
    }
    
    return frequency;
}

/*
Input:  "hello"
Output: {'h':1, 'e':1, 'l':2, 'o':1}
Time: O(n)  |  Space: O(k) where k = unique chars
*/
```

#### Example 3: Grouping with Dictionary (Intermediate)
```csharp
public Dictionary<int, List<int>> GroupByRemainder(int[] nums, int k)
{
    var groups = new Dictionary<int, List<int>>();
    
    foreach (int num in nums)
    {
        int remainder = num % k;
        
        if (!groups.ContainsKey(remainder))
            groups[remainder] = new List<int>();
        
        groups[remainder].Add(num);
    }
    
    return groups;
}

/*
Input:  [1, 2, 3, 4, 5, 6], k=3
Output: 
  {0: [3, 6],
   1: [1, 4],
   2: [2, 5]}
Time: O(n)  |  Space: O(n)
*/
```

#### Example 4: Anagram Grouping with Dictionary (Intermediate)
```csharp
public List<List<string>> GroupAnagrams(string[] words)
{
    var groups = new Dictionary<string, List<string>>();
    
    foreach (string word in words)
    {
        // Sort characters to create canonical form
        char[] sorted = word.ToCharArray();
        Array.Sort(sorted);
        string key = new string(sorted);
        
        if (!groups.ContainsKey(key))
            groups[key] = new List<string>();
        
        groups[key].Add(word);
    }
    
    return new List<List<string>>(groups.Values);
}

/*
Input:  ["eat", "tea", "ate", "nat", "tan", "bat"]
Output: [["eat","tea","ate"], ["nat","tan"], ["bat"]]
Time: O(n * k log k) where k = avg word length  |  Space: O(n)
*/
```

#### Example 5: Cache with Dictionary (Advanced)
```csharp
public class SimpleLRUCache
{
    private Dictionary<int, int> cache;
    private LinkedList<int> order;
    private Dictionary<int, LinkedListNode<int>> nodeMap;
    private int capacity;
    
    public SimpleLRUCache(int capacity)
    {
        this.capacity = capacity;
        cache = new Dictionary<int, int>();
        order = new LinkedList<int>();
        nodeMap = new Dictionary<int, LinkedListNode<int>>();
    }
    
    public int Get(int key)
    {
        if (!cache.ContainsKey(key))
            return -1;
        
        // Move to end (most recently used)
        order.Remove(nodeMap[key]);
        var node = order.AddLast(key);
        nodeMap[key] = node;
        
        return cache[key];
    }
    
    public void Put(int key, int value)
    {
        if (cache.ContainsKey(key))
        {
            cache[key] = value;
            order.Remove(nodeMap[key]);
        }
        else if (cache.Count >= capacity)
        {
            // Remove least recently used
            int lru = order.First.Value;
            cache.Remove(lru);
            nodeMap.Remove(lru);
            order.RemoveFirst();
        }
        
        cache[key] = value;
        var node = order.AddLast(key);
        nodeMap[key] = node;
    }
}

/*
Time: O(1) for Get and Put  |  Space: O(capacity)
*/
```

### Complexity Analysis

| Operation | Average | Worst Case | Use Case |
|---|---|---|---|
| Add | O(1) | O(n) | Insert key-value |
| Remove | O(1) | O(n) | Delete entry |
| Lookup | O(1) | O(n) | Get value by key |
| Update | O(1) | O(n) | Change value |
| Iteration | O(n) | O(n) | Traverse all pairs |

### Interview Tips & Common Mistakes

✅ **Do's:**
- Use Dictionary for **associative data** (key-value relationships)
- Prefer `TryGetValue()` for safe lookups (no exceptions)
- Consider **memory usage** - storing entire values vs. references

❌ **Don'ts:**
- Don't assume **insertion order is preserved** (use SortedDictionary if needed)
- Don't forget **null keys** - Dictionary allows null keys in C#
- Don't use **expensive hash functions** (keep hash computation O(1))

**Interview Question Pattern:**
> "Can you map X to Y? Can you store this relationship efficiently?"

---

## 3. Frequency Maps

### Concept

Frequency maps track **how often each element appears** using a Dictionary/HashMap. Combines counting (frequency) with fast lookup (dictionary).

### Key Insights

- **Count before query**: Build frequency map, then analyze patterns
- **Efficient analysis**: O(n) to build, then O(1) to query any frequency
- **Extensions**: Top-K, least frequent, modes
- **Applications**: Word frequency, character frequency, pattern analysis

### Diagrams

#### Building Frequency Map
```
Array:        [1, 2, 2, 3, 3, 3, 1, 4]

Pass 1:
  1 → 1
  2 → 1
  3 → 1
  4 → 1

Pass 2:
  1 → 2 (duplicate)
  2 → 2
  3 → 2

Pass 3:
  3 → 3

Final Frequency Map:
  {1: 2, 2: 2, 3: 3, 4: 1}
```

#### Frequency Analysis
```
Frequency Map: {1: 2, 2: 2, 3: 3, 4: 1}

Query Examples:
  How many appear once?     → 1 element (4)
  What appears most?         → 3 (appears 3 times)
  What appears least?        → 4 (appears 1 time)
  Elements appearing >= 2?   → 3 elements (1, 2, 3)
```

### Code Examples

#### Example 1: Build Simple Frequency Map (Beginner)
```csharp
public Dictionary<int, int> GetFrequency(int[] nums)
{
    var freq = new Dictionary<int, int>();
    
    foreach (int num in nums)
    {
        if (freq.ContainsKey(num))
            freq[num]++;
        else
            freq[num] = 1;
    }
    
    return freq;
}

/*
Input:  [1, 2, 2, 3, 3, 3]
Output: {1: 1, 2: 2, 3: 3}
Time: O(n)  |  Space: O(k) where k = unique elements
*/
```

#### Example 2: Find Most Frequent Element (Intermediate)
```csharp
public int FindMostFrequent(int[] nums)
{
    var freq = new Dictionary<int, int>();
    int maxFreq = 0;
    int mostFrequent = 0;
    
    foreach (int num in nums)
    {
        freq[num] = freq.GetValueOrDefault(num, 0) + 1;
        
        if (freq[num] > maxFreq)
        {
            maxFreq = freq[num];
            mostFrequent = num;
        }
    }
    
    return mostFrequent;
}

/*
Input:  [1, 1, 1, 2, 2, 3]
Output: 1 (appears 3 times)
Time: O(n)  |  Space: O(k)
*/
```

#### Example 3: Top K Frequent Elements (Advanced)
```csharp
public int[] TopKFrequent(int[] nums, int k)
{
    // Step 1: Build frequency map
    var freq = new Dictionary<int, int>();
    foreach (int num in nums)
    {
        freq[num] = freq.GetValueOrDefault(num, 0) + 1;
    }
    
    // Step 2: Use min-heap to track top K
    // Min-heap keeps elements in ascending order by frequency
    var minHeap = new PriorityQueue<int, int>();
    
    foreach (var (num, count) in freq)
    {
        minHeap.Enqueue(num, count);
        
        // Keep only top K elements
        if (minHeap.Count > k)
            minHeap.Dequeue();
    }
    
    // Step 3: Extract results
    var result = new int[k];
    int idx = k - 1;
    while (minHeap.Count > 0)
    {
        result[idx--] = minHeap.Dequeue();
    }
    
    return result;
}

/*
Input:  [1,1,1,2,2,3], k=2
Output: [1,2] (1 appears 3x, 2 appears 2x)
Time: O(n log k)  |  Space: O(n) for frequency
*/
```

#### Example 4: Frequency Map with Sorting (Advanced)
```csharp
public List<int> FrequencySort(int[] nums)
{
    // Build frequency map
    var freq = new Dictionary<int, int>();
    foreach (int num in nums)
    {
        freq[num] = freq.GetValueOrDefault(num, 0) + 1;
    }
    
    // Sort by frequency ascending, then by value descending
    return freq.Keys
        .OrderBy(x => freq[x])          // Sort by frequency
        .ThenByDescending(x => x)       // Then by value descending
        .ToList();
}

/*
Input:  [4,1,1,1,2,2,3]
Output: [4, 3, 2, 2, 1, 1, 1]
Time: O(n + k log k) where k = unique elements  |  Space: O(n)
*/
```

#### Example 5: Anagram Index with Frequency (Advanced)
```csharp
public bool IsAnagram(string s, string t)
{
    if (s.Length != t.Length)
        return false;
    
    var freqS = new Dictionary<char, int>();
    var freqT = new Dictionary<char, int>();
    
    // Build both frequency maps
    foreach (char c in s)
        freqS[c] = freqS.GetValueOrDefault(c, 0) + 1;
    
    foreach (char c in t)
        freqT[c] = freqT.GetValueOrDefault(c, 0) + 1;
    
    // Compare frequencies
    if (freqS.Count != freqT.Count)
        return false;
    
    foreach (var (c, count) in freqS)
    {
        if (!freqT.ContainsKey(c) || freqT[c] != count)
            return false;
    }
    
    return true;
}

/*
Input:  s="listen", t="silent"
Output: true (same character frequencies)
Time: O(n)  |  Space: O(1) for fixed alphabet
*/
```

### Complexity Analysis

| Operation | Time | Space | Notes |
|---|---|---|---|
| Build map | O(n) | O(k) | One-time cost |
| Query frequency | O(1) | - | After building |
| Find max/min | O(k) | O(1) | Iterate frequencies |
| Top K | O(n log k) | O(n) | With priority queue |
| Sort by frequency | O(k log k) | O(n) | Sort then return |

### Interview Tips & Common Mistakes

✅ **Do's:**
- Build frequency map **before analyzing** (separate concerns)
- Use `GetValueOrDefault()` to handle missing keys elegantly
- Consider **performance trade-offs**: HashMap vs. Array for bounded values

❌ **Don'ts:**
- Don't iterate raw array repeatedly for frequency queries (build map once)
- Don't forget **character encoding** in string problems (ASCII vs. Unicode)
- Don't mix frequency map building with analysis (harder to debug)

**Interview Question Pattern:**
> "Find the most/least frequent X" or "Sort by frequency"

---

## 4. Fast Lookup

### Concept

**Fast lookup** uses hashing to achieve **O(1) average membership testing** instead of O(n) linear search. Critical for performance-sensitive algorithms.

### Key Insights

- **Membership cost**: HashSet/Dictionary O(1) vs. Array O(n)
- **When to use**: Repeated lookups, large datasets, sparse queries
- **When not to**: Small collections, order preservation needed
- **Memory tradeoff**: Extra space for faster lookup

### Diagrams

#### Linear Search vs. Hash Lookup
```
Array Lookup:        Hash Lookup:
[1, 5, 3, 9, 2]      HashSet {1, 5, 3, 9, 2}

Find 9:              Find 9:
Check 1 ✗            Hash(9) = index 4
Check 5 ✗            Bucket[4]: 9 ✓
Check 3 ✗            Found! O(1)
Check 9 ✓
Found! O(n)

Time: O(n)           Time: O(1)
```

#### Two Sum Optimization
```
Brute Force: O(n²)

Array: [2, 7, 11, 15], target=9

i=0: j=1,2,3       Compare with each element
i=1: j=2,3         Total: 3+2+1 = 6 comparisons

Optimized: O(n)

HashSet: {2, 7, 11, 15}
target = 9

For 2: Need 9-2=7 → HashSet contains 7? YES ✓
For 7: Need 9-7=2 → HashSet contains 2? YES ✓
Total: 4 checks (one per element)
```

### Code Examples

#### Example 1: Contains in Array vs. HashSet (Beginner)
```csharp
// Linear Search: O(n)
public bool ContainsInArray(int[] nums, int target)
{
    for (int i = 0; i < nums.Length; i++)
    {
        if (nums[i] == target)
            return true;
    }
    return false;
}

// Fast Lookup: O(1)
public bool ContainsInHashSet(int[] nums, int target)
{
    var set = new HashSet<int>(nums);
    return set.Contains(target);
}

/*
Large array lookup: HashSet much faster
nums has 100,000 elements, worst case:
  Linear: 100,000 checks
  HashSet: 1 check (average)
*/
```

#### Example 2: Two Sum with Hash Lookup (Intermediate)
```csharp
public int[] TwoSum(int[] nums, int target)
{
    var seen = new HashSet<int>();
    
    foreach (int num in nums)
    {
        int complement = target - num;
        
        // O(1) lookup instead of O(n) search
        if (seen.Contains(complement))
        {
            return new[] { seen.IndexOf(complement), /* ... */ };
            // Note: IndexOf on HashSet is O(1) if implemented
        }
        
        seen.Add(num);
    }
    
    return new int[] { };
}

/*
Time: O(n) vs. O(n²) with nested loops  |  Space: O(n)
*/
```

#### Example 3: Valid Sudoku with Dictionary Lookup (Intermediate)
```csharp
public bool IsValidSudoku(char[][] board)
{
    var rows = new HashSet<char>[9];
    var cols = new HashSet<char>[9];
    var boxes = new HashSet<char>[9];
    
    for (int i = 0; i < 9; i++)
    {
        rows[i] = new HashSet<char>();
        cols[i] = new HashSet<char>();
        boxes[i] = new HashSet<char>();
    }
    
    for (int i = 0; i < 9; i++)
    {
        for (int j = 0; j < 9; j++)
        {
            char c = board[i][j];
            if (c == '.') continue;
            
            int boxIndex = (i / 3) * 3 + (j / 3);
            
            // Fast O(1) lookup
            if (rows[i].Contains(c) || 
                cols[j].Contains(c) || 
                boxes[boxIndex].Contains(c))
                return false;
            
            rows[i].Add(c);
            cols[j].Add(c);
            boxes[boxIndex].Add(c);
        }
    }
    
    return true;
}

/*
Time: O(1) with 9x9 board (constant work)  |  Space: O(1)
*/
```

#### Example 4: Intersection of Two Arrays (Advanced)
```csharp
public int[] Intersection(int[] nums1, int[] nums2)
{
    // Build set from first array
    var set1 = new HashSet<int>(nums1);
    var result = new HashSet<int>();
    
    // Fast lookup for each element in second array
    foreach (int num in nums2)
    {
        if (set1.Contains(num))  // O(1) lookup
            result.Add(num);
    }
    
    return result.ToArray();
}

/*
Input:  nums1=[1,2,2,1], nums2=[2,2]
Output: [2]
Time: O(m + n)  |  Space: O(min(m, n))
Without hashing: O(m * n) with nested loops
*/
```

### Complexity Analysis

| Method | Time | Space | Best For |
|---|---|---|---|
| Linear Search | O(n) | O(1) | Small arrays |
| HashSet Lookup | O(1) avg | O(n) | Multiple lookups |
| Sorted + Binary | O(log n) | O(1) | Sorted data |
| HashMap | O(1) avg | O(n) | Key-value lookups |

### Interview Tips & Common Mistakes

✅ **Do's:**
- Ask: **"Will I do multiple lookups?"** - If yes, use hash structure
- Estimate tradeoff: **Time savings vs. space cost**
- Consider **average vs. worst case** (hash collision)

❌ **Don'ts:**
- Don't over-optimize - simple array can be fine for small data
- Don't forget **hash collision worst case** (interview questions might target it)
- Don't use HashSet when **order preservation** is needed

**Interview Question Pattern:**
> "Can you optimize this O(n²) nested loop?" → "Yes, with O(1) lookup!"

---

## 5. Duplicate Detection

### Concept

**Duplicate detection** identifies repeated elements efficiently using hash-based techniques. Can be O(n) time and O(n) space with HashSet, or O(1) space with mathematical tricks.

### Key Insights

- **Simple approach**: HashSet tracks seen elements (O(n) time & space)
- **Optimized approach**: Mark indices, use value ranges, cycle detection
- **Constraints matter**: Value range, array mutability affect solution choice
- **Applications**: Duplicate finding, cycle detection, missing number

### Diagrams

#### HashSet Duplicate Detection
```
Array:    [1, 2, 3, 1, 4]

HashSet   Element   Contains?   Action
{}        1         No          Add: {1}
{1}       2         No          Add: {1, 2}
{1,2}     3         No          Add: {1, 2, 3}
{1,2,3}   1         YES!        Found duplicate!

Duplicate found: 1
```

#### In-place Marking (values 1 to n)
```
Array:    [1, 2, 0, 1]  (duplicates: use negative flag)

Pass 1:   1 at index 1, mark nums[1] negative
          [1, -2, 0, 1]

Pass 2:   2 at index 2, mark nums[2] negative
          [1, -2, -0, 1]

Pass 3:   0 at index 0, nums[0] already positive
          [1, -2, -0, 1]

Pass 4:   1 at index 1, nums[1] already negative!
          Duplicate found: 1
```

### Code Examples

#### Example 1: Contains Duplicate with HashSet (Beginner)
```csharp
public bool ContainsDuplicate(int[] nums)
{
    var seen = new HashSet<int>();
    
    foreach (int num in nums)
    {
        if (seen.Contains(num))
            return true;
        seen.Add(num);
    }
    
    return false;
}

/*
Input:  [1, 2, 3, 1]
Output: true
Time: O(n)  |  Space: O(n)
*/
```

#### Example 2: Find All Duplicates (Intermediate)
```csharp
public List<int> FindDuplicates(int[] nums)
{
    var seen = new HashSet<int>();
    var duplicates = new HashSet<int>();
    
    foreach (int num in nums)
    {
        if (seen.Contains(num))
            duplicates.Add(num);  // Use HashSet to avoid duplicates in result
        else
            seen.Add(num);
    }
    
    return new List<int>(duplicates);
}

/*
Input:  [4, 3, 2, 7, 8, 2, 3, 1]
Output: [2, 3] (both appear twice)
Time: O(n)  |  Space: O(n)
*/
```

#### Example 3: Find Duplicate with O(1) Space (Advanced - Mark indices)
```csharp
public int FindDuplicateOptimized(int[] nums)
{
    // Values are 1 to n, array has n+1 elements
    // Use array indices as hash markers (mark negative)
    
    foreach (int num in nums)
    {
        int index = Math.Abs(num);
        
        if (nums[index] < 0)
            return index;  // Duplicate found!
        
        nums[index] = -nums[index];  // Mark as seen
    }
    
    return -1;
}

/*
Input:  [1, 3, 4, 2, 2]
Output: 2 (duplicate)
Time: O(n)  |  Space: O(1)
Note: Modifies input array!
*/
```

#### Example 4: Find Duplicate with Cycle Detection (Advanced - Floyd's Algorithm)
```csharp
public int FindDuplicateFloyd(int[] nums)
{
    // Treat array as linked list where nums[i] is next node
    // Duplicate value = cycle entry point
    
    int slow = nums[0], fast = nums[0];
    
    // Phase 1: Detect cycle
    do
    {
        slow = nums[slow];
        fast = nums[nums[fast]];
    } while (slow != fast);
    
    // Phase 2: Find cycle entry point
    slow = nums[0];
    while (slow != fast)
    {
        slow = nums[slow];
        fast = nums[fast];
    }
    
    return slow;
}

/*
Input:  [1, 3, 4, 2, 2]
Output: 2
Time: O(n)  |  Space: O(1)
No array modification!
*/
```

#### Example 5: Duplicate Check with Distance Limit (Advanced)
```csharp
public bool ContainsNearbyDuplicate(int[] nums, int k)
{
    // Find if duplicate exists within distance k
    var window = new HashSet<int>();
    
    for (int i = 0; i < nums.Length; i++)
    {
        if (window.Contains(nums[i]))
            return true;
        
        window.Add(nums[i]);
        
        // Maintain window size k
        if (window.Count > k)
            window.Remove(nums[i - k]);
    }
    
    return false;
}

/*
Input:  [1, 2, 3, 1], k=3
Output: true (1 at indices 0 and 3, distance=3)
Time: O(n)  |  Space: O(min(n, k))
*/
```

### Complexity Analysis

| Method | Time | Space | Conditions |
|---|---|---|---|
| HashSet | O(n) | O(n) | No modifications allowed |
| Mark indices | O(n) | O(1) | Values 1 to n, can modify |
| Floyd's cycle | O(n) | O(1) | Exactly one duplicate |
| Sorted | O(n log n) | O(1) | Can sort input |

### Interview Tips & Common Mistakes

✅ **Do's:**
- Ask **constraint questions**: "Can I modify the array?" "What's the value range?"
- Use **HashSet for simplicity** - O(n) time, O(n) space is usually acceptable
- Know **Floyd's algorithm** - impressive for O(1) space solution

❌ **Don'ts:**
- Don't modify input unless explicitly allowed
- Don't assume **can't modify when question allows it** (saves space)
- Don't confuse **cycle detection vs. marking** approaches

**Interview Question Pattern:**
> "Find the duplicate value" or "Detect duplicate within distance k"

---

## 6. Counting Patterns

### Concept

**Counting patterns** are sophisticated algorithms combining frequency counting with additional logic to solve complex problems like anagram grouping, pattern matching, and aggregation.

### Key Insights

- **Multi-level counting**: Count by category, then analyze patterns
- **Canonical forms**: Normalize data (sort) to identify equivalences
- **Frequency comparison**: Compare frequency maps to verify patterns
- **Applications**: Anagrams, valid words, pattern matching

### Diagrams

#### Anagram Grouping Pattern
```
Words:    ["eat", "tea", "ate", "nat", "tan", "bat"]

Step 1: Sort each word (canonical form)
        "eat" → "aet"
        "tea" → "aet"
        "ate" → "aet"
        "nat" → "ant"
        "tan" → "ant"
        "bat" → "abt"

Step 2: Group by canonical form
        "aet" → ["eat", "tea", "ate"]
        "ant" → ["nat", "tan"]
        "abt" → ["bat"]

Output: [["eat","tea","ate"], ["nat","tan"], ["bat"]]
```

#### Frequency Comparison Pattern
```
String s:     "anagram"
String t:     "nagaram"

Frequency of s:  a:3, n:1, g:1, r:1, m:1
Frequency of t:  n:1, a:3, g:1, r:1, a:1, m:1

Compare frequencies: Match? YES → Anagrams
```

### Code Examples

#### Example 1: Group Anagrams (Intermediate)
```csharp
public List<List<string>> GroupAnagrams(string[] words)
{
    var groups = new Dictionary<string, List<string>>();
    
    foreach (string word in words)
    {
        // Create canonical form by sorting characters
        char[] sorted = word.ToCharArray();
        Array.Sort(sorted);
        string key = new string(sorted);
        
        if (!groups.ContainsKey(key))
            groups[key] = new List<string>();
        
        groups[key].Add(word);
    }
    
    return new List<List<string>>(groups.Values);
}

/*
Input:  ["eat", "tea", "ate", "nat", "tan", "bat"]
Output: [["eat","tea","ate"], ["nat","tan"], ["bat"]]
Time: O(n * k log k) where k = avg word length  |  Space: O(n)
*/
```

#### Example 2: Frequency Map Comparison (Intermediate)
```csharp
public bool IsAnagram(string s, string t)
{
    if (s.Length != t.Length)
        return false;
    
    var freqS = new Dictionary<char, int>();
    var freqT = new Dictionary<char, int>();
    
    foreach (char c in s)
        freqS[c] = freqS.GetValueOrDefault(c, 0) + 1;
    
    foreach (char c in t)
        freqT[c] = freqT.GetValueOrDefault(c, 0) + 1;
    
    // Compare all frequencies
    if (freqS.Count != freqT.Count)
        return false;
    
    foreach (var (c, count) in freqS)
    {
        if (!freqT.ContainsKey(c) || freqT[c] != count)
            return false;
    }
    
    return true;
}

/*
Input:  s="listen", t="silent"
Output: true
Time: O(n)  |  Space: O(1) for fixed alphabet
*/
```

#### Example 3: Word Pattern with Mapping (Advanced)
```csharp
public bool WordPattern(string pattern, string s)
{
    string[] words = s.Split(' ');
    
    if (pattern.Length != words.Length)
        return false;
    
    var charToWord = new Dictionary<char, string>();
    var wordToChar = new Dictionary<string, char>();
    
    for (int i = 0; i < pattern.Length; i++)
    {
        char c = pattern[i];
        string word = words[i];
        
        // Check bidirectional mapping consistency
        if (charToWord.ContainsKey(c))
        {
            if (charToWord[c] != word)
                return false;
        }
        else
        {
            charToWord[c] = word;
        }
        
        if (wordToChar.ContainsKey(word))
        {
            if (wordToChar[word] != c)
                return false;
        }
        else
        {
            wordToChar[word] = c;
        }
    }
    
    return true;
}

/*
Input:  pattern="badc", s="b a d c"
Output: true
Time: O(n)  |  Space: O(1) bounded by unique patterns
*/
```

#### Example 4: Isomorphic Strings (Advanced)
```csharp
public bool IsIsomorphic(string s, string t)
{
    if (s.Length != t.Length)
        return false;
    
    var sToT = new Dictionary<char, char>();
    var tToS = new Dictionary<char, char>();
    
    for (int i = 0; i < s.Length; i++)
    {
        char sc = s[i];
        char tc = t[i];
        
        // Check if mapping is consistent
        if (sToT.ContainsKey(sc))
        {
            if (sToT[sc] != tc)
                return false;
        }
        else
        {
            sToT[sc] = tc;
        }
        
        // Check reverse mapping
        if (tToS.ContainsKey(tc))
        {
            if (tToS[tc] != sc)
                return false;
        }
        else
        {
            tToS[tc] = sc;
        }
    }
    
    return true;
}

/*
Input:  s="badc", t="baba"
Output: false (a→b, a→a conflict)
Time: O(n)  |  Space: O(1) bounded by charset
*/
```

#### Example 5: Substring Pattern Matching (Advanced)
```csharp
public List<int> FindAnagrams(string s, string p)
{
    if (p.Length > s.Length)
        return new List<int>();
    
    var pFreq = new Dictionary<char, int>();
    var windowFreq = new Dictionary<char, int>();
    
    foreach (char c in p)
        pFreq[c] = pFreq.GetValueOrDefault(c, 0) + 1;
    
    var result = new List<int>();
    
    for (int i = 0; i < s.Length; i++)
    {
        // Add new character to window
        windowFreq[s[i]] = windowFreq.GetValueOrDefault(s[i], 0) + 1;
        
        // Remove character leaving window
        if (i >= p.Length)
        {
            windowFreq[s[i - p.Length]]--;
            if (windowFreq[s[i - p.Length]] == 0)
                windowFreq.Remove(s[i - p.Length]);
        }
        
        // Compare frequencies
        if (FrequenciesEqual(pFreq, windowFreq))
            result.Add(i - p.Length + 1);
    }
    
    return result;
}

private bool FrequenciesEqual(Dictionary<char, int> d1, Dictionary<char, int> d2)
{
    if (d1.Count != d2.Count)
        return false;
    
    foreach (var (key, value) in d1)
    {
        if (!d2.ContainsKey(key) || d2[key] != value)
            return false;
    }
    
    return true;
}

/*
Input:  s="cbaebabacd", p="abc"
Output: [0, 6]
Time: O(n + m)  |  Space: O(1) bounded by charset
*/
```

### Complexity Analysis

| Pattern | Time | Space | Key Step |
|---|---|---|---|
| Anagram Grouping | O(n * k log k) | O(n) | Sort each word |
| Frequency Compare | O(n) | O(1) | Compare maps |
| Bidirectional Map | O(n) | O(n) | Two-way mapping |
| Isomorphic Check | O(n) | O(1) | Bidirectional mapping |
| Substring Search | O(n) | O(1) | Sliding window + freq |

### Interview Tips & Common Mistakes

✅ **Do's:**
- Use **canonical forms** (sort) for equivalence detection
- Maintain **bidirectional mappings** when order matters
- Combine **sliding window + frequency counting** for substring patterns

❌ **Don'ts:**
- Don't forget **bidirectional checks** in mapping problems
- Don't assume **single direction mapping** (can be one-to-many)
- Don't recreate frequency maps - update incrementally in windows

**Interview Question Pattern:**
> "Find all anagrams" or "Check if isomorphic/pattern matches"

---

## Summary Table

| Concept | Use Case | Time | Space | Key Technique |
|---|---|---|---|---|
| HashSet | Membership, dedup | O(1) | O(n) | Hash function, buckets |
| Dictionary | Key-value mapping | O(1) | O(n) | Hash lookup by key |
| Frequency Maps | Count patterns, top-K | O(n) build, O(1) query | O(n) | Pre-compute frequencies |
| Fast Lookup | Reduce nested loops | O(1) | O(n) | Hash membership test |
| Duplicate Detection | Find repeats | O(n) | O(n) or O(1) | HashSet or in-place marking |
| Counting Patterns | Anagrams, isomorphic | O(n) or O(n log n) | O(1) | Frequency comparison, canonical forms |

---

## Practice Roadmap

### Beginner Level
1. Master **HashSet operations** - Add, remove, contains, iterate
2. Learn **Dictionary usage** - Add/update/remove, TryGetValue
3. Practice **Frequency counting** - Build maps and query

### Intermediate Level
4. Master **Fast lookups** - Replace nested loops with hash structures
5. Learn **Anagram detection** - Sorting and frequency comparison
6. Practice **Duplicate detection** - HashSet approach, multiple passes

### Advanced Level
7. Combine patterns - Frequency maps + sliding window (substring anagrams)
8. Bidirectional mappings - Pattern matching, isomorphic problems
9. Optimize space - Floyd's algorithm, in-place marking for duplicates
10. Recognize patterns - Convert O(n²) problems to O(n) with hashing
