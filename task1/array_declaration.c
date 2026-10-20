#define ARRAY_SIZE 1000000

void declare_static_array(void) {
    static int large_array[ARRAY_SIZE];
    large_array[0] = 1;
    large_array[ARRAY_SIZE - 1] = large_array[0];
}
