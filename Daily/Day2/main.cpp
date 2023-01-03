/*
 * DAY 2  •  Collatz Conjecture
 * 
 * Visualise the Collatz Conjecture:
 * take any number x and to get the next number apply the following operation:
 * even: x = x/2
 * odd: x = (3 * x) + 1
 * from any given starting number and follow the series until it reaches 1.
 * For more of a challenge allow users to start from negative numbers.
 * 
 * Example:
 * input: 11
 * output: 11, 34, 17, 52, 26, 13, 40, 20, 10, 5, 16, 8, 4, 2, 1
 * 
 * Constraints:
 * • start from any integer
 * • finish at 1
 */

#include <cctype>
#include <cmath>
#include <iostream>
#include <vector>

void collatz(int64_t number, std::vector<int64_t>& result_sequence) {
    result_sequence.push_back(number);

    while (abs(number) != 1) {
        if (abs(number) % 2 == 0) { // Even
            number /= 2;
        } else { // Odd
            number = 3 * number + 1;
        }

        result_sequence.push_back(number);
    }
}

int main() {
    int64_t input_number = 11;
    //std::cin >> input_number;
    std::vector<int64_t> results;
    collatz(input_number, results);

    for (size_t num : results) {
        std::cout << num;
        if (num != 1) {
            std::cout << ", ";
        }
    }

    std::cout << std::endl; // Newline and flush

    return EXIT_SUCCESS;
}