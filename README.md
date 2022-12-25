# Ref Lokals, Ref Returns

## Overview

There is an example of ability to return values by reference and to store references in local variables.

I recommend taking a look at the repository [Ref Arg](https://github.com/ArturWincenciak/Ref-Arg) first

## Possible drivers to usage

This can be used to improve performance, especially when working with large structs, as it allows you to reference them directly in safe code, avoiding the need for unsafe code and pointers to pinned memory. Ref returns and ref locals can be used to reference array elements and can be useful in various situations where we want to access a variable by reference rather than by copy, for example when implementing certain data structures like linked lists. This can be particularly useful for large, data structures as it can significantly reduce memory overhead when modifying them by avoiding the need to create copies of the large data structures when passing them to methods.

Overall, ref returns and ref locals are useful tools that can facilitate working with large data structures and improve code performance.

## Output

```
Alright Ref Returns, Ref Locals

Let's go with value type

Just get a value
#01.01: value = 100
Change the value of the value type
#01.02: value = 200
Local changes don't affect to value to inside Class (what is quite normal)
#01.03: globalClassObject = [_valueTypeVariable: 100]

Get value type by ref and assign them to local ref
#01.04: localRef = 100
Change the value using the ref
#01.05: localRef = 200
The local change by ref also changed the value inside Class (a bit strange and nice xD)
#01.06: globalClassObject = [_valueTypeVariable: 200]

Another case: get value by ref but assign them to local value type
#01.07: localValueType = 200
#01.08: localValueType = 1200
Even though I used the RefGetInt to get value and changed them the changes don't affect to value inside Class because I didn't use local ref type
#01.09: globalClassObject = [_valueTypeVariable: 200]

Let's go with complex reference type
Just get the dto
#02.01: dto = [IntProp: 111]
#02.01: complexObject = [_dto: [IntProp: 111]]
That is well known behavior, the value of IntProp changed
#02.02: dto = [IntProp: 222]
#02.02: complexObject = [_dto: [IntProp: 222]]

Create a new object somewhere in memory and assign a reference of the object to dto. Notice that here we will rewrite an address, which is just a hexadecimal value type, meaning a reference to the object. When we use the dto reference to modify its members, like IntProp, we change the real memory of the object, and the changes are permanent. When we create a new instance of an object, we get a new address to that object (a new reference). It is important to note that assigning an address, which is a value type, to a local value type named dto is not permanent.
#02.03: dto = [IntProp: 1000]
#02.03: complexObject = [_dto: [IntProp: 222]]

Here we have the game changer. Here we have an address to an address (a pointer of the pointer) and we are changing the address value in place where the address in memory exists. Notice that we still don't change the memory of the object but the change is permanent. The change is permanent because we rewrite a new address (not only locally). There is a rewrite of the cell of memory where the address exists by a new address, which refers to new memory.
#02.04: refDto = [IntProp: 5000000]
#02.04: complexObject = [_dto: [IntProp: 5000000]]
```
