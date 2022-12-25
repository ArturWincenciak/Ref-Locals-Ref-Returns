# Ref Lokals, Ref Returns

## Overview

There is an example of ability to return values by reference and to store references in local variables.

I recommend taking a look at the repository [Ref Arg](https://github.com/ArturWincenciak/Ref-Arg) first

## Possible drivers to usage

This can be used to improve performance, especially when working with large structs, as it allows you to reference them directly in safe code, avoiding the need for unsafe code and pointers to pinned memory. Ref returns and ref locals can be used to reference array elements and can be useful in various situations where we want to access a variable by reference rather than by copy, for example when implementing certain data structures like linked lists. This can be particularly useful for large, data structures as it can significantly reduce memory overhead when modifying them by avoiding the need to create copies of the large data structures when passing them to methods.

Overall, ref returns and ref locals are useful tools that can facilitate working with large data structures and improve code performance.
