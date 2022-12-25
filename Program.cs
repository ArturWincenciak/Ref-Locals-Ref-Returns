Console.WriteLine("Alright Ref Returns, Ref Locals");

Console.WriteLine();
Console.WriteLine("Let's go");
var globalClassObject = new Class();

Console.WriteLine();
Console.WriteLine("Just get a value");
var value = globalClassObject.GetInt();
Console.WriteLine($"#01: {nameof(value)} = {value}"); // 100
Console.WriteLine("Change the value of the value type");
value += 100;
Console.WriteLine($"#02: {nameof(value)} = {value}"); // 200
Console.WriteLine("Local changes don't affect to value to inside Class (what is quite normal)");
Console.WriteLine($"#03: {nameof(globalClassObject)} = {globalClassObject}"); // 100

Console.WriteLine();
Console.WriteLine("Get value type by ref and assign them to local ref");
ref var localRef = ref globalClassObject.RefGetInt();
Console.WriteLine($"#04: {nameof(localRef)} = {localRef}"); // 100
Console.WriteLine("Change the value using the ref");
localRef += 100;
Console.WriteLine($"#05: {nameof(localRef)} = {localRef}"); // 200
Console.WriteLine("The local change by ref also changed the value inside Class (a bit strange and nice xD)");
Console.WriteLine($"#06: {nameof(globalClassObject)} = {globalClassObject}"); // 200 (!)

Console.WriteLine();
Console.WriteLine("Another case: get value by ref but assign them to local value type");
var localValueType = globalClassObject.RefGetInt(); // that is also possible
Console.WriteLine($"#07: {nameof(localValueType)} = {localValueType}"); // 200 
localValueType += 1000;
Console.WriteLine($"#08: {nameof(localValueType)} = {localValueType}"); // 1200 
Console.WriteLine($"Even though I used the {nameof(globalClassObject.RefGetInt)} to get value " +
                  $"and changed them the changes don't affect to value inside Class because " +
                  $"I didn't use local ref type");
Console.WriteLine($"#09: {nameof(globalClassObject)} = {globalClassObject}"); // 200

// Cannot assign value type returns by regular Get method to ref value
// compilation error: [CS1510] A ref or out value must be an assignable variable
// ref var tryRefByRegularGet = ref globalClassObject.GetInt();