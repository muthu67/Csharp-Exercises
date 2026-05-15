# Hashing Patterns

## Overview

This guide covers common hashing patterns used in DSA interviews. For in-depth concept explanations with diagrams and code examples, see [Core Concepts: Hashing](../CoreConcepts/Hashing.md).

## Core Hashing Concepts (See CoreConcepts/Hashing.md)

1. **HashSet** - Unique element collection with O(1) membership testing
2. **Dictionary** - Key-value mapping with O(1) lookup
3. **Frequency Maps** - Element counting and frequency analysis
4. **Fast Lookup** - Reduce nested loops using hash-based O(1) lookups
5. **Duplicate Detection** - Identify repeated elements efficiently
6. **Counting Patterns** - Aggregate data patterns (anagrams, isomorphic)

## Common Hashing Problems

### Frequency Counter
Track how often each element appears.
- **Pattern**: HashMap/Dictionary for counting
- **See**: [CoreConcepts/Hashing.md - Frequency Maps](../CoreConcepts/Hashing.md#3-frequency-maps)

### Two Sum with Hash Map
Find two numbers that sum to target (unsorted array).
- **Pattern**: Single pass with HashMap
- **See**: [CoreConcepts/Hashing.md - Fast Lookup](../CoreConcepts/Hashing.md#4-fast-lookup)

### Group Anagrams
Group words that are anagrams of each other.
- **Pattern**: Canonical form (sort) as key
- **See**: [CoreConcepts/Hashing.md - Counting Patterns](../CoreConcepts/Hashing.md#6-counting-patterns)

### Valid Anagram
Check if two strings are anagrams.
- **Pattern**: Frequency comparison
- **See**: [CoreConcepts/Hashing.md - Counting Patterns](../CoreConcepts/Hashing.md#6-counting-patterns)

### Contains Duplicate
Detect if array has duplicate elements.
- **Pattern**: HashSet for O(1) duplicate detection
- **See**: [CoreConcepts/Hashing.md - Duplicate Detection](../CoreConcepts/Hashing.md#5-duplicate-detection)

## Pattern Application Guide

| Problem Type | Structure | Complexity | Example |
|---|---|---|---|
| Membership testing | HashSet | O(1) | Contains duplicate |
| Element counting | Dictionary | O(n) | Frequency count, top K |
| Anagram detection | Frequency comparison | O(n) | Group anagrams |
| Fast lookups | HashMap | O(1) | Two sum |
| Duplicate finding | HashSet or marking | O(n) | Find duplicates |
| Pattern matching | Bidirectional map | O(n) | Isomorphic strings |

## Pattern Application Matrix

### When to Use HashSet
- ✓ Check membership: "Does this element exist?"
- ✓ Remove duplicates: "Get unique elements"
- ✓ Set operations: Union, intersection, difference
- ✗ Need value data: Use Dictionary instead
- ✗ Order preservation: Use List instead

### When to Use Dictionary
- ✓ Store relationships: Key → Value mapping
- ✓ Count frequencies: Element → Count
- ✓ Cache/memoization: Input → Result
- ✗ Only need uniqueness: Use HashSet instead
- ✗ Sorted by key: Use SortedDictionary

### When to Use Frequency Maps
- ✓ Analyze patterns: Most/least frequent
- ✓ Compare data: Are frequencies equal?
- ✓ Top-K problems: Find k most frequent
- ✓ Aggregate analysis: Summarize by count

## Practice Problems by Pattern

### HashSet Basics
- Contains Duplicate
- Valid Anagram
- Happy Number

### Dictionary Operations
- Two Sum (unsorted)
- Isomorphic Strings
- Word Pattern

### Frequency Maps
- Top K Frequent Elements
- Find Mode
- Frequency Sort

### Advanced Patterns
- Group Anagrams (sorting + HashMap)
- Find Duplicates (HashSet + constraints)
- Substring Pattern Matching (sliding window + frequency)
