#include <stdio.h>
#include <stdlib.h>
#include <time.h>

#define ARRAY_SIZE 100000
#define CALL_COUNT 100000

void declare_static_array(void) {
    static int large_array[ARRAY_SIZE];
    large_array[0] = 1;
    large_array[ARRAY_SIZE - 1] = large_array[0];
}

void declare_stack_array(void) {
    int large_array[ARRAY_SIZE];
    large_array[0] = 1;
    large_array[ARRAY_SIZE - 1] = large_array[0];
}

void declare_heap_array(void) {
    int *large_array = (int *)malloc(ARRAY_SIZE * sizeof(int));
    large_array[0] = 1;
    large_array[ARRAY_SIZE - 1] = large_array[0];
    free(large_array);
}

int main(void) {
    clock_t start, end;
    int i;

    start = clock();
    for (i = 0; i < CALL_COUNT; i++) {
        declare_static_array();
    }
    end = clock();
    printf("static: %f seconds\n", (double)(end - start) / CLOCKS_PER_SEC);

    start = clock();
    for (i = 0; i < CALL_COUNT; i++) {
        declare_stack_array();
    }
    end = clock();
    printf("stack: %f seconds\n", (double)(end - start) / CLOCKS_PER_SEC);

    start = clock();
    for (i = 0; i < CALL_COUNT; i++) {
        declare_heap_array();
    }
    end = clock();
    printf("heap: %f seconds\n", (double)(end - start) / CLOCKS_PER_SEC);

    return 0;
}