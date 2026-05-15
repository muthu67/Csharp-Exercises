# Arrays: Core Concepts and Patterns

A comprehensive guide to fundamental array techniques and patterns essential for DSA interviews.

---

## Table of Contents

1. [Traversal](#traversal)
2. [Prefix Sum](#prefix-sum)
3. [Running Sum](#running-sum)
4. [Frequency Count](#frequency-count)
5. [Two Pointers](#two-pointers)
6. [Sliding Window](#sliding-window)
7. [In-place Modification](#in-place-modification)

---

## 1. Traversal

### Concept

Array traversal is the fundamental operation of visiting each element sequentially. Understanding different traversal patterns is crucial for solving many array problems.

### Key Insights

- **Forward traversal**: Useful for most problems where order matters (cumulative operations, comparisons)
- **Backward traversal**: Useful when current position depends on future elements (right-to-left dependencies)
- **Conditional traversal**: Skip elements based on conditions (early termination, filtered access)

### Diagrams

#### Forward Traversal
```
Array:     [10, 20, 30, 40, 50]
Index:      0   1   2   3   4
Pointer:   ↓
           ↓
              ↓
                 ↓
                    ↓
Step:       0   1   2   3   4
```

#### Backward Traversal
```
Array:     [10, 20, 30, 40, 50]
Index:      0   1   2   3   4
Pointer:                      ↑
                           ↑
                        ↑
                     ↑
                  ↑
Step:            4   3   2   1   0
```

### Code Examples

#### Example 1: Forward Traversal (Beginner)
```csharp
public void PrintArrayForward(int[] nums)
{
    // Simple forward loop
    for (int i = 0; i < nums.Length; i++)
    {
        Console.WriteLine(nums[i]);
    }
}

// Time: O(n)  |  Space: O(1)
```

#### Example 2: Backward Traversal (Beginner)
```csharp
public void PrintArrayBackward(int[] nums)
{
    // Simple backward loop
    for (int i = nums.Length - 1; i >= 0; i--)
    {
        Console.WriteLine(nums[i]);
    }
}

// Time: O(n)  |  Space: O(1)
```

#### Example 3: Conditional Forward with Early Exit (Intermediate)
```csharp
public int FindFirstTarget(int[] nums, int target)
{
    // Exit early when target is found
    for (int i = 0; i < nums.Length; i++)
    {
        if (nums[i] == target)
            return i;  // Early termination saves time
    }
    return -1;
}

// Time: O(n) worst case, O(1) best case  |  Space: O(1)
```

#### Example 4: Bidirectional Traversal (Advanced)
```csharp
public bool IsPalindrome(int[] nums)
{
    // Two pointers converging from both ends
    int left = 0, right = nums.Length - 1;
    
    while (left < right)
    {
        if (nums[left] != nums[right])
            return false;
        left++;
        right--;
    }
    return true;
}

// Time: O(n)  |  Space: O(1)
```

### Complexity Analysis

| Traversal Type | Time | Space | Use Case |
|---|---|---|---|
| Forward | O(n) | O(1) | Sequential processing, left-to-right dependencies |
| Backward | O(n) | O(1) | Right-to-left dependencies, reverse processing |
| Conditional | O(k), k < n | O(1) | Early termination possible |
| Bidirectional | O(n/2) | O(1) | Palindrome checks, two-pointer problems |

### Interview Tips & Common Mistakes

✅ **Do's:**
- Choose traversal direction based on data dependencies
- Use early termination when possible (O(n) worst case → O(k) average)
- Consider bidirectional traversal for symmetry problems

❌ **Don'ts:**
- Don't iterate beyond array bounds (index out of range errors)
- Don't assume forward traversal is always optimal
- Don't miss opportunities for early exit in linear searches

**Interview Question Pattern:**
> "How would you traverse this array to solve the problem? What direction makes sense?"

---

## 2. Prefix Sum

### Concept

Prefix sum (or cumulative sum) is an array where each element at index `i` contains the sum of all elements from index `0` to `i`. This enables **O(1) range sum queries** after **O(n) preprocessing**.

### Key Insights

- **Preprocessing**: Build prefix sum array in O(n) - calculate once, query many times
- **Range queries**: Sum from index `i` to `j` = `prefix[j] - prefix[i-1]`
- **Space-time tradeoff**: Use O(n) extra space to achieve O(1) query time
- **2D extension**: Works for 2D arrays (matrix range sum queries)

### Diagrams

#### 1D Prefix Sum Construction
```
Original:  [3,    1,    2,    4,    5]
Index:      0     1     2     3     4

Prefix:    [3,    4,    6,   10,   15]
           3  (3+1) (3+1+2) (3+1+2+4) (3+1+2+4+5)
```

#### Range Sum Query Using Prefix Sum
```
Query: Sum from index 1 to 3

Original:  [3,    1,    2,    4,    5]
                  ├────┼────┼────┤
                  1    2    4   = 7

Prefix:    [3,    4,    6,   10,   15]
           
Range Sum = prefix[3] - prefix[0] = 10 - 3 = 7
```

### Code Examples

#### Example 1: Build Prefix Sum Array (Beginner)
```csharp
public int[] BuildPrefixSum(int[] nums)
{
    int[] prefix = new int[nums.Length];
    prefix[0] = nums[0];
    
    for (int i = 1; i < nums.Length; i++)
    {
        prefix[i] = prefix[i - 1] + nums[i];
    }
    return prefix;
}

// Time: O(n)  |  Space: O(n)
```

#### Example 2: Range Sum Query (Intermediate)
```csharp
public class PrefixSumQuery
{
    private int[] prefix;
    
    // Constructor: O(n) preprocessing
    public PrefixSumQuery(int[] nums)
    {
        prefix = new int[nums.Length + 1];
        for (int i = 0; i < nums.Length; i++)
        {
            prefix[i + 1] = prefix[i] + nums[i];
        }
    }
    
    // Query: O(1) range sum
    public int RangeSum(int left, int right)
    {
        return prefix[right + 1] - prefix[left];
    }
}

/*
Setup: O(n)  |  Query: O(1)
Example:
  nums = [1, 2, 3, 4, 5]
  prefix = [0, 1, 3, 6, 10, 15]
  
  RangeSum(1, 3) = prefix[4] - prefix[1] = 10 - 1 = 9 (2+3+4)
*/
```

#### Example 3: Subarray Sum Equals K (Advanced - Prefix Sum + HashMap)
```csharp
public int SubarraySum(int[] nums, int k)
{
    // Prefix sum + frequency map
    Dictionary<int, int> prefixCount = new();
    prefixCount[0] = 1;  // Base case: sum 0 appears once
    
    int sum = 0, count = 0;
    
    foreach (int num in nums)
    {
        sum += num;
        
        // If (sum - k) exists in map, we found valid subarrays
        if (prefixCount.ContainsKey(sum - k))
        {
            count += prefixCount[sum - k];
        }
        
        // Add current prefix sum to map
        prefixCount[sum] = prefixCount.GetValueOrDefault(sum, 0) + 1;
    }
    
    return count;
}

/*
Time: O(n)  |  Space: O(n)
Example:
  nums = [1, 1, 1], k = 2
  Subarrays: [1,1] (indices 0-1), [1,1] (indices 1-2) → count = 2
*/
```

#### Example 4: 2D Prefix Sum for Matrix Range Queries (Advanced)
```csharp
public class Matrix2DPrefixSum
{
    private int[][] prefix;
    
    public Matrix2DPrefixSum(int[][] matrix)
    {
        int rows = matrix.Length;
        int cols = matrix[0].Length;
        prefix = new int[rows + 1][];
        
        for (int i = 0; i <= rows; i++)
        {
            prefix[i] = new int[cols + 1];
        }
        
        // Build 2D prefix sum
        for (int i = 1; i <= rows; i++)
        {
            for (int j = 1; j <= cols; j++)
            {
                prefix[i][j] = matrix[i - 1][j - 1]
                    + prefix[i - 1][j]
                    + prefix[i][j - 1]
                    - prefix[i - 1][j - 1];
            }
        }
    }
    
    // O(1) range sum query for rectangle
    public int SumRegion(int row1, int col1, int row2, int col2)
    {
        return prefix[row2 + 1][col2 + 1]
            - prefix[row1][col2 + 1]
            - prefix[row2 + 1][col1]
            + prefix[row1][col1];
    }
}

// Time: O(m*n) build  |  O(1) query  |  Space: O(m*n)
```

### Complexity Analysis

| Operation | Time | Space | Notes |
|---|---|---|---|
| Build | O(n) | O(n) | One-time cost |
| Range Query | O(1) | - | After building |
| 2D Build | O(m*n) | O(m*n) | Matrix dimensions |
| 2D Query | O(1) | - | After building |

### Interview Tips & Common Mistakes

✅ **Do's:**
- Use prefix sum when you have **multiple range queries**
- Include index `0` with value `0` in prefix array for boundary handling
- Think: "Will this problem benefit from preprocessing?"

❌ **Don'ts:**
- Don't use prefix sum for single query (no benefit, just adds space)
- Don't forget `-1` indexing when calculating range sum
- Don't confuse inclusion/exclusion in range (verify with test cases)

**Interview Question Pattern:**
> "Given multiple queries, how can you preprocess to make each query O(1)?"

---

## 3. Running Sum

### Concept

Running sum (or cumulative total) is a real-time accumulation pattern where you maintain a running total as you traverse the array. Unlike prefix sum (which stores all values), running sum only keeps the current accumulation.

### Key Insights

- **Real-time accumulation**: Process elements sequentially, maintaining current sum
- **Memory efficient**: Only track current value, not entire array
- **Event-driven**: Update sum as new elements arrive (streaming data)
- **Applications**: Moving averages, cumulative statistics, balance calculations

### Diagrams

#### Running Sum Calculation
```
Original:     [10,  20,  30,  40,  50]
              
Running:
Step 1:       10
              ↓
Step 2:       30 (10+20)
              ↓
Step 3:       60 (30+30)
              ↓
Step 4:      100 (60+40)
              ↓
Step 5:      150 (100+50)
```

#### Running Sum with Conditions
```
Array:        [5,   -2,   8,   -3,   6]

Running Sum   5    3     11    8    14
Condition:    +    +     +     +    +  (all positive)
              
If sum < 5:   ✓    ✓     ✓     ✗    ✓  (reset counter)
```

### Code Examples

#### Example 1: Simple Running Sum (Beginner)
```csharp
public int[] GetRunningSum(int[] nums)
{
    int[] result = new int[nums.Length];
    int runningSum = 0;
    
    for (int i = 0; i < nums.Length; i++)
    {
        runningSum += nums[i];
        result[i] = runningSum;
    }
    
    return result;
}

/*
Input:  [3, 1, 2, 10, 1]
Output: [3, 4, 6, 16, 17]
Time: O(n)  |  Space: O(n) for output
*/
```

#### Example 2: Running Sum with Conditional Update (Intermediate)
```csharp
public decimal CalculateRunningAverage(int[] nums, int windowSize)
{
    decimal sum = 0;
    int count = 0;
    
    foreach (int num in nums)
    {
        sum += num;
        count++;
        
        if (count == windowSize)
        {
            Console.WriteLine($"Average: {sum / windowSize}");
            sum = 0;
            count = 0;
        }
    }
    
    return sum;  // Remaining elements
}

// Time: O(n)  |  Space: O(1)
```

#### Example 3: Running Sum with Reset Condition (Intermediate)
```csharp
public int MaxAlternatingSum(int[] nums)
{
    // Running sum alternating +/- operations
    int maxSum = 0;
    int evenSum = 0;  // Sum at even indices (add)
    int oddSum = 0;   // Sum at odd indices (subtract)
    
    for (int i = 0; i < nums.Length; i++)
    {
        if (i % 2 == 0)
        {
            evenSum = Math.Max(evenSum + nums[i], evenSum);
        }
        else
        {
            oddSum = Math.Max(oddSum - nums[i], oddSum);
        }
        maxSum = Math.Max(maxSum, evenSum + oddSum);
    }
    
    return maxSum;
}

/*
Input:  [6, 2, 1, 2, 4, 5]
Output: 7  (6-2+1-2+4-5 or other alternating combinations)
Time: O(n)  |  Space: O(1)
*/
```

#### Example 4: Streaming Running Sum with State Machine (Advanced)
```csharp
public class RunningStreamProcessor
{
    private int sum = 0;
    private List<int> sums = new();
    private int threshold;
    private bool active = true;
    
    public RunningStreamProcessor(int threshold)
    {
        this.threshold = threshold;
    }
    
    public void ProcessValue(int value)
    {
        if (!active) return;
        
        sum += value;
        sums.Add(sum);
        
        // Check condition
        if (sum > threshold)
        {
            active = false;
            Console.WriteLine($"Threshold exceeded at sum={sum}");
        }
    }
    
    public int GetCurrentSum() => sum;
    public List<int> GetAllSums() => new(sums);
}

/*
Usage:
  processor = new(100);
  processor.ProcessValue(30);
  processor.ProcessValue(40);  // sum = 70
  processor.ProcessValue(50);  // sum = 120 > 100 → stop processing
  
Time: O(1) per element  |  Space: O(n) for history
*/
```

### Complexity Analysis

| Pattern | Time | Space | Use Case |
|---|---|---|---|
| Simple Running Sum | O(n) | O(1) or O(n) | Cumulative totals, output array |
| Conditional Update | O(n) | O(1) | State-based processing, early termination |
| Alternating Operations | O(n) | O(1) | Alternating additions/subtractions |
| Stream Processing | O(1) per element | O(n) | Real-time data, event-driven |

### Interview Tips & Common Mistakes

✅ **Do's:**
- Use running sum for **sequential, state-dependent operations**
- Consider memory: store only what's necessary for the algorithm
- Think about **resetting** conditions (when to clear accumulator)

❌ **Don'ts:**
- Don't confuse running sum with prefix sum (different use cases)
- Don't forget to handle **initial value** (start from 0 or first element?)
- Don't miss edge cases like empty arrays or single elements

**Interview Question Pattern:**
> "How would you process this data stream in one pass while maintaining state?"

---

## 4. Frequency Count

### Concept

Frequency counting is the technique of tracking how many times each element appears in an array. It's fundamental for detecting duplicates, finding modes, and identifying patterns.

### Key Insights

- **Hash-based approach**: Use Dictionary/HashSet for O(1) lookups
- **Array-based approach**: Use array indices when values are bounded (0 to n-1)
- **Space consideration**: Dictionary uses O(k) space where k = unique elements
- **Multiple passes**: Some problems require one pass (counting), then query (analysis)

### Diagrams

#### Frequency Counting - Hash Approach
```
Array:      [1, 2, 2, 3, 3, 3, 1]

Frequency Map:
  1  →  2  (appears at indices 0, 6)
  2  →  2  (appears at indices 1, 2)
  3  →  3  (appears at indices 3, 4, 5)

Visual:
1: ██        (2 occurrences)
2: ██        (2 occurrences)
3: ███       (3 occurrences)
```

#### Frequency Counting - Array Approach (bounded values)
```
Array:      [0, 1, 0, 2, 1, 0]
Values:     0-2 (can use array of size 3)

Frequency:  [3, 2, 1]
Index:       0  1  2
            (0 appears 3x) (1 appears 2x) (2 appears 1x)
```

### Code Examples

#### Example 1: Count Element Frequency (Beginner)
```csharp
public Dictionary<int, int> CountFrequency(int[] nums)
{
    var frequency = new Dictionary<int, int>();
    
    foreach (int num in nums)
    {
        if (frequency.ContainsKey(num))
            frequency[num]++;
        else
            frequency[num] = 1;
    }
    
    return frequency;
}

/*
Input:  [1, 2, 2, 3, 3, 3]
Output: {1:1, 2:2, 3:3}
Time: O(n)  |  Space: O(k) where k = unique elements
*/
```

#### Example 2: Find Mode (Most Frequent Element) (Intermediate)
```csharp
public int FindMode(int[] nums)
{
    var frequency = new Dictionary<int, int>();
    int maxCount = 0;
    int mode = 0;
    
    // Build frequency map
    foreach (int num in nums)
    {
        frequency[num] = frequency.GetValueOrDefault(num, 0) + 1;
        
        // Track maximum frequency and corresponding element
        if (frequency[num] > maxCount)
        {
            maxCount = frequency[num];
            mode = num;
        }
    }
    
    return mode;
}

/*
Input:  [1, 1, 1, 2, 2, 3]
Output: 1 (appears 3 times, most frequent)
Time: O(n)  |  Space: O(k)
*/
```

#### Example 3: Frequency Count with Array (Bounded Values) (Intermediate)
```csharp
public int[] FindDuplicates(int[] nums)
{
    // Since 1 ≤ nums[i] ≤ n, use array for O(1) space
    int[] frequency = new int[nums.Length + 1];
    
    foreach (int num in nums)
    {
        frequency[num]++;
    }
    
    var duplicates = new List<int>();
    for (int i = 1; i < frequency.Length; i++)
    {
        if (frequency[i] > 1)
            duplicates.Add(i);
    }
    
    return duplicates.ToArray();
}

/*
Input:  [1, 1, 2, 2, 3]
Output: [1, 2]
Time: O(n)  |  Space: O(1) if output not counted
*/
```

#### Example 4: Top K Frequent Elements (Advanced)
```csharp
public int[] TopKFrequent(int[] nums, int k)
{
    // Step 1: Build frequency map
    var frequency = new Dictionary<int, int>();
    foreach (int num in nums)
    {
        frequency[num] = frequency.GetValueOrDefault(num, 0) + 1;
    }
    
    // Step 2: Use min-heap (priority queue) to track top k
    var heap = new PriorityQueue<int, int>();
    
    foreach (var (num, count) in frequency)
    {
        heap.Enqueue(num, count);
        
        // Keep only top k elements
        if (heap.Count > k)
            heap.Dequeue();
    }
    
    // Step 3: Extract results
    var result = new int[k];
    for (int i = k - 1; i >= 0; i--)
    {
        result[i] = heap.Dequeue();
    }
    
    return result;
}

/*
Input:  [1,1,1,2,2,3], k=2
Output: [1,2] (1 appears 3x, 2 appears 2x)
Time: O(n log k)  |  Space: O(n) for frequency map
*/
```

### Complexity Analysis

| Approach | Time | Space | Best For |
|---|---|---|---|
| HashMap | O(n) | O(k) unique elements | Unknown value range |
| Array | O(n) | O(max_value) | Bounded value range |
| With Sort | O(n log n) | O(k) | When sorted output needed |
| With Heap | O(n log k) | O(n) | Top-K problems |

### Interview Tips & Common Mistakes

✅ **Do's:**
- Choose HashMap when **values are unbounded or sparse**
- Use array when **values are bounded** (saves space)
- Consider whether you need **exact frequencies or just presence**

❌ **Don'ts:**
- Don't use HashMap for bounded values (wastes space vs. array)
- Don't forget to initialize map values correctly (0 vs. missing key)
- Don't assume you need to return frequencies in order unless specified

**Interview Question Pattern:**
> "Find the most/least frequent element" or "Find top K elements"

---

## 5. Two Pointers

### Concept

Two pointers is a technique using two indices moving through the array (usually from opposite ends or at different speeds) to solve problems in **O(n) time with O(1) extra space**.

### Key Insights

- **Three main patterns**: Converging (outside→inside), Diverging (inside→outside), Same-speed (both move forward)
- **Efficiency**: Reduces nested loops O(n²) → O(n)
- **Sorted requirement**: Most converging patterns require sorted arrays
- **Moving strategy**: Direction determined by problem constraints

### Diagrams

#### Converging Pattern (Two Sum in Sorted Array)
```
Array (sorted):  [1, 2, 3, 4, 5, 6]
Target: 9

Initial:  Left    →  →  →           → Right
          L                          R

Step 1: 1 + 6 = 7 < 9  →  Move left right
               L                     R

Step 2: 2 + 6 = 8 < 9  →  Move left right
                  L                  R

Step 3: 3 + 6 = 9 ✓  Found!
                     L               R
```

#### Diverging Pattern (Reverse Array In-Place)
```
Array:  [1, 2, 3, 4, 5]

Initial:  L              R
          1  2  3  4  5
          
Step 1:   L           R
          5  2  3  4  1  (swap)
          
Step 2:      L     R
          5  4  3  2  1  (swap)

Result:  [5, 4, 3, 2, 1]
```

#### Same-Speed Pattern (Remove Duplicates)
```
Array:  [1, 1, 2, 2, 3, 4, 4, 5]

        Read          Write
        Pointer       Pointer
        ↓             ↓
        1, 1, 2, 2, 3, 4, 4, 5
        
Track unique elements:
1 → 2 → 3 → 4 → 5  (5 unique)
```

### Code Examples

#### Example 1: Two Sum in Sorted Array (Beginner)
```csharp
public int[] TwoSum(int[] nums, int target)
{
    int left = 0, right = nums.Length - 1;
    
    while (left < right)
    {
        int sum = nums[left] + nums[right];
        
        if (sum == target)
            return new[] { left + 1, right + 1 };  // 1-indexed
        else if (sum < target)
            left++;  // Need larger sum
        else
            right--;  // Need smaller sum
    }
    
    return new[] { };
}

/*
Input:  [2,7,11,15], target=9
Output: [1,2] (indices of 2 and 7, 1-indexed)
Time: O(n)  |  Space: O(1)
*/
```

#### Example 2: Reverse Array In-Place (Beginner)
```csharp
public void ReverseArray(int[] nums)
{
    int left = 0, right = nums.Length - 1;
    
    while (left < right)
    {
        // Swap
        int temp = nums[left];
        nums[left] = nums[right];
        nums[right] = temp;
        
        left++;
        right--;
    }
}

/*
Input:  [1, 2, 3, 4, 5]
Output: [5, 4, 3, 2, 1]
Time: O(n)  |  Space: O(1)
*/
```

#### Example 3: Remove Duplicates In-Place (Intermediate)
```csharp
public int RemoveDuplicates(int[] nums)
{
    if (nums.Length == 0)
        return 0;
    
    int write = 0;  // Position to write unique element
    
    for (int read = 1; read < nums.Length; read++)
    {
        if (nums[read] != nums[write])
        {
            write++;
            nums[write] = nums[read];
        }
    }
    
    return write + 1;  // Length of unique elements
}

/*
Input:  [1, 1, 2, 2, 3, 4, 4, 5]
Output: 5  (first 5 elements: [1, 2, 3, 4, 5])
Time: O(n)  |  Space: O(1)
*/
```

#### Example 4: Container with Most Water (Advanced)
```csharp
public int MaxArea(int[] height)
{
    // Two pointers converging strategy
    int left = 0, right = height.Length - 1;
    int maxArea = 0;
    
    while (left < right)
    {
        // Area = width × min(height[left], height[right])
        int width = right - left;
        int minHeight = Math.Min(height[left], height[right]);
        int area = width * minHeight;
        
        maxArea = Math.Max(maxArea, area);
        
        // Move the pointer with smaller height
        // (taller one might give better result)
        if (height[left] < height[right])
            left++;
        else
            right--;
    }
    
    return maxArea;
}

/*
Input:  [1,8,6,2,5,4,8,3,7]
Output: 49  (between indices 1 and 8)
Time: O(n)  |  Space: O(1)
*/
```

### Complexity Analysis

| Pattern | Time | Space | Condition | Best For |
|---|---|---|---|---|
| Converging | O(n) | O(1) | Sorted array | Two-sum, target problems |
| Diverging | O(n) | O(1) | Any array | Reverse, palindrome checks |
| Same-Speed | O(n) | O(1) | Any array | Dedup, removing elements |
| Three Pointers | O(n) | O(1) | Sorted array | Partition, 3-sum variant |

### Interview Tips & Common Mistakes

✅ **Do's:**
- Recognize **O(n²) nested loops** → can often be solved with two pointers O(n)
- Move **pointer with smaller value** when both directions possible (greedy reasoning)
- Verify **sorted requirement** - converging patterns need sorted data

❌ **Don'ts:**
- Don't use two pointers on **unsorted arrays** for converging patterns (gives wrong answer)
- Don't forget **boundary conditions** (left < right, left <= right?)
- Don't overcomplicate - if one pointer works, don't force two

**Interview Question Pattern:**
> "Can you solve this in O(n) with O(1) space? Have you considered two pointers?"

---

## 6. Sliding Window

### Concept

Sliding window is a technique that maintains a **contiguous subarray (window)** that slides across the array. It solves problems requiring subarray analysis in **O(n)** instead of **O(n²)**.

### Key Insights

- **Two types**: Fixed window (size k) and Variable window (expand/contract)
- **Efficiency**: Single pass with O(n) time complexity
- **Pattern**: Expand window → Check condition → Contract window
- **Applications**: Max/min in window, subarray sum, longest substring

### Diagrams

#### Fixed Window (Size 3)
```
Array:  [1, 2, 3, 4, 5, 6, 7]
Window Size: 3

Window 1:  [1, 2, 3] → sum=6
           ███
           
Window 2:     [2, 3, 4] → sum=9
              ███
              
Window 3:        [3, 4, 5] → sum=12
                 ███
                 
Window 4:           [4, 5, 6] → sum=15
                    ███
                    
Window 5:              [5, 6, 7] → sum=18
                       ███
```

#### Variable Window (Expand When Sum < target, Contract When Sum ≥ target)
```
Array:  [1, 4, 1, 7, 3, 2], target=11

Start:  L,R=0

Expand:  [1] sum=1 < 11, expand
         [1,4] sum=5 < 11, expand
         [1,4,1] sum=6 < 11, expand
         [1,4,1,7] sum=13 ≥ 11, contract
           [4,1,7] sum=12 ≥ 11, contract
             [1,7] sum=8 < 11, expand
             [1,7,3] sum=11 ≥ 11, found! (length=3)
```

### Code Examples

#### Example 1: Maximum Sum in Fixed Window (Beginner)
```csharp
public int MaxSumInWindow(int[] nums, int k)
{
    if (k > nums.Length) return -1;
    
    // Build initial window
    int windowSum = 0;
    for (int i = 0; i < k; i++)
    {
        windowSum += nums[i];
    }
    
    int maxSum = windowSum;
    
    // Slide window: remove left, add right
    for (int i = k; i < nums.Length; i++)
    {
        windowSum = windowSum - nums[i - k] + nums[i];
        maxSum = Math.Max(maxSum, windowSum);
    }
    
    return maxSum;
}

/*
Input:  [1, 3, 2, 6, -1, 4, 1, 8], k=3
Output: 13 (window [6, -1, 4] or [4, 1, 8])
Time: O(n)  |  Space: O(1)
*/
```

#### Example 2: Longest Substring Without Repeating Characters (Intermediate)
```csharp
public int LengthOfLongestSubstring(string s)
{
    var charLastSeen = new Dictionary<char, int>();
    int left = 0;
    int maxLength = 0;
    
    for (int right = 0; right < s.Length; right++)
    {
        char c = s[right];
        
        // If char seen and in current window, move left
        if (charLastSeen.ContainsKey(c) && charLastSeen[c] >= left)
        {
            left = charLastSeen[c] + 1;
        }
        
        charLastSeen[c] = right;
        maxLength = Math.Max(maxLength, right - left + 1);
    }
    
    return maxLength;
}

/*
Input:  "abcabcbb"
Output: 3 ("abc")
Time: O(n)  |  Space: O(min(n, charset_size))
*/
```

#### Example 3: Minimum Window Substring (Advanced)
```csharp
public string MinWindow(string s, string t)
{
    if (s.Length < t.Length) return "";
    
    // Character frequency in t
    var required = new Dictionary<char, int>();
    foreach (char c in t)
    {
        required[c] = required.GetValueOrDefault(c, 0) + 1;
    }
    
    int left = 0, minLength = int.MaxValue, minStart = 0;
    var window = new Dictionary<char, int>();
    int formed = 0;  // Chars with desired frequency
    
    for (int right = 0; right < s.Length; right++)
    {
        char c = s[right];
        window[c] = window.GetValueOrDefault(c, 0) + 1;
        
        // Check if this char has desired frequency
        if (required.ContainsKey(c) && window[c] == required[c])
            formed++;
        
        // Contract window from left
        while (left <= right && formed == required.Count)
        {
            // Update minimum window
            if (right - left + 1 < minLength)
            {
                minLength = right - left + 1;
                minStart = left;
            }
            
            // Remove left char
            char leftChar = s[left];
            window[leftChar]--;
            if (required.ContainsKey(leftChar) && window[leftChar] < required[leftChar])
                formed--;
            
            left++;
        }
    }
    
    return minLength == int.MaxValue ? "" : s.Substring(minStart, minLength);
}

/*
Input:  s="ADOBECODEBANC", t="ABC"
Output: "BANC"
Time: O(n+m)  |  Space: O(1) for charset
*/
```

### Complexity Analysis

| Problem Type | Time | Space | Pattern |
|---|---|---|---|
| Fixed Window | O(n) | O(1) or O(k) | Slide and calculate |
| Variable Window | O(n) | O(1) or O(charset) | Expand/contract |
| With Frequency | O(n) | O(charset) | Track char counts |
| Multiple Passes | O(2n) | O(charset) | Optimize via 2-pass |

### Interview Tips & Common Mistakes

✅ **Do's:**
- Recognize **"find subarray with property X"** → sliding window candidate
- Maintain **window invariant** (what property must hold?)
- Use **HashMap for character/element tracking** inside window

❌ **Don'ts:**
- Don't forget to handle **edge cases** (empty window, t longer than s)
- Don't confuse **window contraction condition** (expand when good, contract when bad)
- Don't recalculate entire window sum each iteration (use incremental update)

**Interview Question Pattern:**
> "Find the longest/shortest subarray/substring with property X"

---

## 7. In-place Modification

### Concept

In-place modification means **rearranging array elements without using extra space** (O(1) auxiliary space, only input modification allowed). Techniques include swapping, overwriting, and pointer management.

### Key Insights

- **Space constraint**: No auxiliary arrays (except small constants like pointers, flags)
- **Mutation allowed**: Can modify input array
- **Challenge**: Determine new positions before overwriting old values
- **Applications**: Remove elements, rotate, rearrange

### Diagrams

#### Reverse In-Place
```
Before:  [1, 2, 3, 4, 5]

Swap indices 0,4:  [5, 2, 3, 4, 1]
Swap indices 1,3:  [5, 4, 3, 2, 1]
Stop at center

After:   [5, 4, 3, 2, 1]
```

#### Remove Element In-Place
```
Array:  [1, 0, 2, 0, 3, 0], remove=0

WritePtr  ReadPtr
    ↓         ↓
1, 0, 2, 0, 3, 0

Find 2:
    ↓           ↓
1, 0, 2, 0, 3, 0
Move WritePtr to 0 position, overwrite with 2:
[1, 2, 2, 0, 3, 0]
        ↓           ↓
Continue...
Final:  [1, 2, 3, ...]  Length=3
```

### Code Examples

#### Example 1: Remove Element In-Place (Beginner)
```csharp
public int RemoveElement(int[] nums, int val)
{
    int write = 0;  // Position to place next non-val element
    
    for (int read = 0; read < nums.Length; read++)
    {
        if (nums[read] != val)
        {
            nums[write] = nums[read];
            write++;
        }
    }
    
    return write;  // New length
}

/*
Input:  [0, 1, 2, 2, 3, 0, 4, 2], val=2
Output: 5  (first 5 elements: [0, 1, 3, 0, 4])
Time: O(n)  |  Space: O(1)
*/
```

#### Example 2: Rotate Array In-Place (Intermediate)
```csharp
public void RotateRight(int[] nums, int k)
{
    k = k % nums.Length;  // Handle k > length
    
    // Reverse entire array
    Reverse(nums, 0, nums.Length - 1);
    
    // Reverse first k elements
    Reverse(nums, 0, k - 1);
    
    // Reverse remaining elements
    Reverse(nums, k, nums.Length - 1);
}

private void Reverse(int[] nums, int start, int end)
{
    while (start < end)
    {
        int temp = nums[start];
        nums[start] = nums[end];
        nums[end] = temp;
        start++;
        end--;
    }
}

/*
Input:  [1, 2, 3, 4, 5], k=2
Output: [4, 5, 1, 2, 3]
Time: O(n)  |  Space: O(1)
*/
```

#### Example 3: Move Zeros to End (Intermediate)
```csharp
public void MoveZeroes(int[] nums)
{
    int write = 0;  // Position for next non-zero
    
    // First pass: move all non-zeros to front
    for (int read = 0; read < nums.Length; read++)
    {
        if (nums[read] != 0)
        {
            nums[write] = nums[read];
            write++;
        }
    }
    
    // Second pass: fill remaining with zeros
    while (write < nums.Length)
    {
        nums[write] = 0;
        write++;
    }
}

/*
Input:  [0, 1, 0, 3, 12]
Output: [1, 3, 12, 0, 0]
Time: O(n)  |  Space: O(1)
*/
```

#### Example 4: Dutch National Flag Problem (Advanced)
```csharp
public void SortColors(int[] nums)
{
    // Partition array into three sections: 0s, 1s, 2s
    int low = 0, mid = 0, high = nums.Length - 1;
    
    while (mid <= high)
    {
        if (nums[mid] == 0)
        {
            // Swap with low boundary
            Swap(nums, low, mid);
            low++;
            mid++;
        }
        else if (nums[mid] == 1)
        {
            // Already in middle section
            mid++;
        }
        else  // nums[mid] == 2
        {
            // Swap with high boundary
            Swap(nums, mid, high);
            high--;
        }
    }
}

private void Swap(int[] nums, int i, int j)
{
    int temp = nums[i];
    nums[i] = nums[j];
    nums[j] = temp;
}

/*
Input:  [2, 0, 1, 2, 1, 0]
Output: [0, 0, 1, 1, 2, 2]
Time: O(n)  |  Space: O(1)
*/
```

### Complexity Analysis

| Problem | Time | Space | Technique |
|---|---|---|---|
| Remove Element | O(n) | O(1) | Two-pointer (read/write) |
| Rotate Array | O(n) | O(1) | Three-way reverse |
| Move Zeros | O(n) | O(1) | Two-pass technique |
| Partition | O(n) | O(1) | Multi-pointer tracking |

### Interview Tips & Common Mistakes

✅ **Do's:**
- Use **two pointers** (read/write) to track processed vs. unprocessed regions
- Verify **mutation is allowed** - some problems forbid changing input
- Consider **order preservation** - does relative order of kept elements matter?

❌ **Don'ts:**
- Don't create new array **when in-place is required**
- Don't forget to **handle overwrites carefully** - save value before losing it
- Don't miss **boundary conditions** - ensure pointers don't go out of bounds

**Interview Question Pattern:**
> "Can you solve this in-place?" or "Remove X elements from array without using extra space"

---

## Summary Table

| Concept | Use Case | Time | Space | Key Technique |
|---|---|---|---|---|
| Traversal | Basic iteration, order-dependent ops | O(n) | O(1) | Forward/backward/bidirectional loops |
| Prefix Sum | Range queries, cumulative data | O(n) build, O(1) query | O(n) | Precompute cumulative sums |
| Running Sum | Sequential accumulation, state tracking | O(n) | O(1) | Maintain single accumulator |
| Frequency Count | Detect duplicates, find modes | O(n) | O(k) | HashMap or bounded array |
| Two Pointers | Reduce O(n²) to O(n), sorted arrays | O(n) | O(1) | Converging/diverging/same-speed |
| Sliding Window | Subarray properties, max/min in window | O(n) | O(k) or O(1) | Expand/contract window |
| In-place Modification | Rearrange without extra space | O(n) | O(1) | Multi-pointer tracking |

---

## Practice Roadmap

### Beginner Level
1. Master **Traversal** - Ensure bidirectional iteration is second nature
2. Learn **Prefix Sum** - Build, then query patterns
3. Practice **Frequency Count** - HashMap and array-based approaches

### Intermediate Level
4. Master **Two Pointers** - Converging and diverging patterns
5. Learn **Sliding Window** - Fixed window first, then variable
6. Practice **In-place Modification** - Read/write pointers

### Advanced Level
7. Combine concepts - Sliding Window + Frequency Count (longest substring)
8. Optimize problems - Reduce nested loops to single pass
9. Handle edge cases - Boundaries, empty arrays, single elements
