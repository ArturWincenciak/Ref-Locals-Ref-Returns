Console.WriteLine("Alright Ref Returns, Ref Locals");

Console.WriteLine();
Console.WriteLine("Let's go with value type");
var globalClassObject = new Class();

Console.WriteLine();
Console.WriteLine("Just get a value");
var value = globalClassObject.GetInt();
Console.WriteLine($"#01.01: {nameof(value)} = {value}"); // 100
Console.WriteLine("Change the value of the value type");
value += 100;
Console.WriteLine($"#01.02: {nameof(value)} = {value}"); // 200
Console.WriteLine("Local changes don't affect to value to inside Class (what is quite normal)");
Console.WriteLine($"#01.03: {nameof(globalClassObject)} = {globalClassObject}"); // 100

Console.WriteLine();
Console.WriteLine("Get value type by ref and assign them to local ref");
ref var localRef = ref globalClassObject.RefGetInt();
Console.WriteLine($"#01.04: {nameof(localRef)} = {localRef}"); // 100
Console.WriteLine("Change the value using the ref");
localRef += 100;
Console.WriteLine($"#01.05: {nameof(localRef)} = {localRef}"); // 200
Console.WriteLine("The local change by ref also changed the value inside Class (a bit strange and nice xD)");
Console.WriteLine($"#01.06: {nameof(globalClassObject)} = {globalClassObject}"); // 200 (!)

Console.WriteLine();
Console.WriteLine("Another case: get value by ref but assign them to local value type");
var localValueType = globalClassObject.RefGetInt(); // that is also possible
Console.WriteLine($"#01.07: {nameof(localValueType)} = {localValueType}"); // 200 
localValueType += 1000;
Console.WriteLine($"#01.08: {nameof(localValueType)} = {localValueType}"); // 1200 
Console.WriteLine($"Even though I used the {nameof(globalClassObject.RefGetInt)} to get value " +
                  $"and changed them the changes don't affect to value inside Class because " +
                  $"I didn't use local ref type");
Console.WriteLine($"#01.09: {nameof(globalClassObject)} = {globalClassObject}"); // 200

// Cannot assign value type returns by regular Get method to ref value
// compilation error: [CS1510] A ref or out value must be an assignable variable
// ref var tryRefByRegularGet = ref globalClassObject.GetInt();

/*
 * Second part with complex reference type
 */

Console.WriteLine();
Console.WriteLine("Let's go with complex reference type");
var complexObject = new Object();

Console.WriteLine("Just get the dto");
var dto = complexObject.GetDto();
Console.WriteLine($"#02.01: {nameof(dto)} = {dto}"); // 111
Console.WriteLine($"#02.01: {nameof(complexObject)} = {complexObject}"); // 111
dto.IntProp += 111;
Console.WriteLine($"That is well known behavior, the value of {nameof(dto.IntProp)} changed");
Console.WriteLine($"#02.02: {nameof(dto)} = {dto}"); // 222
Console.WriteLine($"#02.02: {nameof(complexObject)} = {complexObject}"); // 222

/*
 * To get basics and better understand what's going on below
 * I suggest you to read code that explain differences between
 * passing method argument by value versus by ref.
 *
 * See: https://github.com/ArturWincenciak/Ref-Arg
 */

Console.WriteLine();
Console.WriteLine("Create a new object somewhere in memory and assign a reference of the object to dto. " +
                  "Notice that here we will rewrite an address, which is just a hexadecimal value type, " +
                  $"meaning a reference to the object. When we use the {nameof(dto)} reference " +
                  $"to modify its members, like {nameof(dto.IntProp)}, we change the real memory of the object, " +
                  "and the changes are permanent. When we create a new instance of an object, " +
                  "we get a new address to that object (a new reference). It is important to note " +
                  $"that assigning an address, which is a value type, to a local value type named {nameof(dto)} " +
                  "is not permanent.");
dto = new Dto { IntProp = 1_000 };
Console.WriteLine($"#02.03: {nameof(dto)} = {dto}"); // 1 000 
Console.WriteLine($"#02.03: {nameof(complexObject)} = {complexObject}"); // 222

Console.WriteLine();
Console.WriteLine("Here we have the game changer. Here we have an address to an address (a pointer of the pointer) " +
                  "and we are changing the address value in place where the address in memory exists. Notice that " +
                  "we still don't change the memory of the object but the change is permanent. The change is " +
                  "permanent because we rewrite a new address (not only locally). There is a rewrite of the cell " +
                  "of memory where the address exists by a new address, which refers to new memory.");
ref var refDto = ref complexObject.RefGetDto();
refDto = new Dto { IntProp = 5_000_000 };
Console.WriteLine($"#02.04: {nameof(refDto)} = {refDto}"); // 5 000 000
Console.WriteLine($"#02.04: {nameof(complexObject)} = {complexObject}"); // 5 000 000