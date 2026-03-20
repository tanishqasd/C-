#include <stdio.h>

int main() {
    int a = 10, b = 3;
    float x = 5.5, y = 2.0;
    
    // Arithmetic operators
    printf("=== Arithmetic Operators ===\n");
    printf("%d + %d = %d\n", a, b, a + b);
    printf("%d - %d = %d\n", a, b, a - b);
    printf("%d * %d = %d\n", a, b, a * b);
    printf("%d / %d = %d\n", a, b, a / b);
    printf("%d %% %d = %d\n", a, b, a % b);
    
    // Relational operators
    printf("\n=== Relational Operators ===\n");
    printf("%d > %d: %d\n", a, b, a > b);
    printf("%d < %d: %d\n", a, b, a < b);
    printf("%d == %d: %d\n", a, b, a == b);
    printf("%d != %d: %d\n", a, b, a != b);
    
    // Logical operators
    printf("\n=== Logical Operators ===\n");
    printf("(%d > 5) && (%d < 5): %d\n", a, b, (a > 5) && (b < 5));
    printf("(%d > 5) || (%d > 5): %d\n", a, b, (a > 5) || (b > 5));
    printf("!(%d > 5): %d\n", a, !(a > 5));
    
    // Assignment operators
    printf("\n=== Assignment Operators ===\n");
    int c = a;
    printf("c = a: %d\n", c);
    c += 5;
    printf("c += 5: %d\n", c);
    
    // Increment and Decrement
    printf("\n=== Increment/Decrement ===\n");
    printf("a++ = %d, a after = %d\n", a++, a);
    printf("++b = %d, b after = %d\n", ++b, b);
    
    return 0;
}