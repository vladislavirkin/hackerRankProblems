# Problem solving. Medium. Min operation.

Minimize steps to reach K from 0 by adding 1 or doubling at each step.

Given an array of integers kValues, each item is a positive integer K, the task is to find the minimum number of operations of the following two types, required to change 0 to K:
- Add one to the operand
- Multiply the operand by 2.

```
Input: K = 1 
Output: 1 
Explanation: 
Step 1: 0 + 1 = 1 = K
Input: K = 4 
Output: 3 
Explanation: 
Step 1: 0 + 1 = 1, 
Step 2: 1 * 2 = 2, 
Step 3: 2 * 2 = 4 = K
```

## Constraints

```
1 <= n <= 10^4
0 <= kValues <= 10^16
```

## **Approach**: 

If K is an odd number, the last step must be adding 1 to it.
If K is an even number, the last step is to multiply by 2 to minimize the number of steps.
Create a table that stores in every dp[i], the minimum steps required to reach i. 

## Failed tests:

Time exceeded and out of mem, if use the dictionary.