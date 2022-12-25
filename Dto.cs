internal class Dto
{
    public int IntProp { get; set; } = 111;

    public override string ToString() => 
        $"[{nameof(IntProp)}: {IntProp}]";
}