# Arrays Patterns

## Overview

This guide covers common array patterns used in DSA interviews. For in-depth concept explanations with diagrams and code examples, see [Core Concepts: Arrays](../CoreConcepts/Arrays.md).

## Core Array Concepts (See CoreConcepts/Arrays.md)

1. **Traversal** - Forward, backward, bidirectional iteration patterns
2. **Prefix Sum** - Cumulative sum computation and range queries
3. **Running Sum** - Sequential accumulation with state tracking
4. **Frequency Count** - Element occurrence tracking and analysis
5. **Two Pointers** - Converging/diverging pointer techniques
6. **Sliding Window** - Fixed and variable window patterns
7. **In-place Modification** - Array rearrangement without extra space

## Common Array Problems

### Two Sum
Find two numbers that add up to a target value.
- **Pattern**: Two Pointers (sorted) or HashMap (unsorted)
- **See**: [CoreConcepts/Arrays.md - Two Pointers](../CoreConcepts/Arrays.md#5-two-pointers)

### Contains Duplicate
Detect if array contains duplicate elements.
- **Pattern**: HashSet for O(1) membership testing
- **See**: [CoreConcepts/Arrays.md - Traversal](../CoreConcepts/Arrays.md#1-traversal)

### Product of Array Except Self
Return array where each element is product of all other elements.
- **Pattern**: Prefix Sum approach (left-right products)
- **See**: [CoreConcepts/Arrays.md - Prefix Sum](../CoreConcepts/Arrays.md#2-prefix-sum)

## Pattern Application Guide

| Problem Type | Pattern | Complexity | Example |
|---|---|---|---|
| Sum range queries | Prefix Sum | O(1) query | Range sum in subarray |
| Find target in sorted | Two Pointers | O(n), O(1) space | Two Sum, Container With Most Water |
| Subarray with property | Sliding Window | O(n) | Max sum in window, substring problems |
| Remove duplicates | In-place Modification | O(n), O(1) space | Remove Element, Move Zeroes |
| Count occurrences | Frequency Count | O(n) | Find mode, detect duplicates |

## Practice Problems by Pattern

### Prefix Sum
- Range Sum Query
- Subarray Sum Equals K
- Contiguous Array

### Two Pointers
- Reverse Array
- Remove Duplicates
- Container With Most Water
- Partition

### Sliding Window
- Maximum Sum Subarray of Size K
- Longest Substring Without Repeating
- Minimum Window Substring

### In-place Modification
- Remove Element
- Move Zeroes
- Rotate Array
- Sort Colors
