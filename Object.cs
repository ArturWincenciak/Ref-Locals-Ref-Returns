internal class Object
{
    private Dto _dto = new ();

    public Dto GetDto() =>
        _dto;

    public ref Dto RefGetDto() =>
        ref _dto;

    public override string ToString() => 
        $"[{nameof(_dto)}: {_dto}]";
}