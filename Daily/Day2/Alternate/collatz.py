"""
DAY 2  •  Collatz Conjecture

Visualise the Collatz Conjecture:
take any number x and to get the next number apply the following operation:
even: x = x/2
odd: x = (3 * x) + 1
from any given starting number and follow the series until it reaches 1. For more of a challenge allow users to start from negative numbers.

Example:
input: 11
output: 11, 34, 17, 52, 26, 13, 40, 20, 10, 5, 16, 8, 4, 2, 1

Constraints:
• start from any integer
• finish at 1
"""

def collatz(num: int) -> list[int]:
    result: list[int] = [num]
    
    while abs(num) != 1:
        if abs(num % 2) == 0:
            num //= 2
        else:
            num = 3 * num + 1
            
        result.append(num)

    return result

if __name__ == '__main__':
    print(collatz(11))