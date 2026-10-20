#define ARRAY_SIZE 100000

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