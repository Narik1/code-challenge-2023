/*
 * Day 5 • Integer to Roman
 *
 * Roman numerals are represented by seven different symbols: I, V, X, L, C, D and M.
 * Symbol       Value
 * I             1
 * V             5
 * X             10
 * L             50
 * C             100
 * D             500
 * M             1000
 *
 * Given an integer, convert it to a roman numeral.
 *
 * Example 1
 * Input: num = 3
 * Output: "III"
 * Explanation: 3 is represented as 3 ones.
 *
 * Example 2
 * Input: num = 58
 * Output: "LVIII"
 * Explanation: L = 50, V = 5, III = 3.
 *
 * Constraints:
 * •    1 <= num <= 3999
 */

#include <iostream>
#include <map>
#include <sstream>
#include <string>

const std::map<int, std::string> numeral_mapping {
    { 1000, "M" },
    { 900, "CM" },
    { 500, "D" },
    { 400, "CD" },
    { 100, "C" },
    { 90, "XC" },
    { 50, "L" },
    { 40, "XL" },
    { 10, "X" },
    { 9, "IX" },
    { 5, "V" },
    { 4, "IV" },
    { 1, "I" }
};

std::string GetNumeral(int number, const std::map<int, std::string>& numeral_mapping) {
    std::stringstream builder{};
    for (auto iter = numeral_mapping.rbegin(), end = numeral_mapping.rend(); iter != end; ++iter) {
        const auto &[divider, numeral] = *iter;
        while (number % divider != number) { // While the number still needs one of the current symbol
            builder << numeral;
            number -= divider;
        }
    }

    return builder.str();
}

int main() {
    std::cout << GetNumeral(58, numeral_mapping) << std::endl;

    return EXIT_SUCCESS;
}