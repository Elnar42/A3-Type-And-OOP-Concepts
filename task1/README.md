# Task 1 — Static, stack, and heap allocation

`array_declaration.c` builds the same array of 100,000 `int`s three ways and calls each function 1,000,000 times. `clock()` records the processor time of each loop. The run printed:

| Storage | Time for 1,000,000 calls |
| --- | --- |
| Static | 0.002937 seconds |
| Stack | 0.002170 seconds |
| Heap | 0.035970 seconds |

Per call, that is about 2.9 ns for the static array, 2.2 ns for the stack array, and 36 ns for the heap array.

## What the times mean

The static array is reserved for the whole run of the program, before `main` starts. The timed loop does not create it again. Each call writes the first element and the last element of the same block.

The stack array is a local variable. Entering `declare_stack_array` reserves its space by adjusting the stack pointer, and returning from the function releases that space. Those two steps are a few instructions. The loop then does the same two writes as the static function. Both loops therefore spend their time on the call and the writes, which is why 0.002170 s and 0.002937 s are close. In this run the stack loop was a little faster. The gap is small next to the heap result; both measurements are dominated by the loop, and the exact order of these two can change with the compiler and the cache.

The heap function calls `malloc` and `free` on every iteration. `malloc` has to find a block large enough for 100,000 integers and update the allocator's records. `free` has to return that block. That bookkeeping is much more work than moving the stack pointer, so the heap loop took 0.035970 s, about 17 times the stack loop and about 12 times the static loop. The program frees the block immediately and always asks for the same size, so the allocator can often hand the same block back, but the search and the record updates still happen on every call.

Each function writes only the first and last elements. The times compare the cost of obtaining the storage and touching those two positions. They do not include filling all 100,000 elements.

## References

- Why heap allocation costs more than stack allocation: https://stackoverflow.com/questions/2264969/why-is-memory-allocation-on-heap-much-slower-than-on-stack
- Cost of `malloc` and `free`: https://johnnysswlab.com/the-price-of-dynamic-memory-allocation/
