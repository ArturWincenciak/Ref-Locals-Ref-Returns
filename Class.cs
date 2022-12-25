internal class Class
{
    private int _valueTypeVariable = 100;

    public int GetInt() =>
        _valueTypeVariable;

    public ref int RefGetInt() =>
        ref _valueTypeVariable;

    public override string ToString() => 
        $"[{nameof(_valueTypeVariable)}: {_valueTypeVariable}]";
}