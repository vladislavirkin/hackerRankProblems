# 30 Days of code. Day 29: Bitwise AND

## Welcome to the last day! Today, we're discussing bitwise operations.

## Task

Given set `S = {1, 2, .. N}`. Find two integers, `A` and `B` (where `A < B`), from set `S` such that the value of `A&B` is the maximum possible and also less than a given integer, `K`. In this case, `&` represents the _bitwise AND_ operator.

## Function Description

Complete the _bitwiseAnd_ function in the editor below.

_bitwiseAnd_ has the following paramter(s):
- int N: the maximum integer to consider
- int K: the limit of the result, inclusive

## Returns

- int: the maximum value of `A&B` within the limit.

## Input Format

The first line contains an integer, `T`, the number of test cases.
Each of the `T` subsequent lines defines a test case as 2 space-separated integers, `N` and `K`, respectively.

## Constraints

- `1 <= T <= 10^3`
- `2 <= N <= 10^3`
- `2 <= K <= N`

## Sample Input

```txt
STDIN   Function
-----   --------
3       T = 3
5 2     N = 5, K = 2
8 5     N = 8, K = 5
2 2     N = 8, K = 5
```

## Sample Output

```
1
4
0
```

## Explanation

```
N = 5, K = 2, S = {1,2,3,4,5}
All possible values of A and B are:
- A = 1, B = 2, A&B = 0
- A = 1, B = 3, A&B = 1
- A = 1, B = 4, A&B = 0
- A = 1, B = 5, A&B = 1
- A = 2, B = 3, A&B = 2
- A = 2, B = 4, A&B = 0
- A = 2, B = 5, A&B = 0
- A = 3, B = 4, A&B = 0
- A = 3, B = 5, A&B = 1
- A = 4, B = 2, A&B = 4

The max possible value of `A&B` that is also <(K=2) is 1, so we print 1 on a new line.
```
