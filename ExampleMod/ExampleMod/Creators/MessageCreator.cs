namespace ExampleMod.Creators;

public class MessageCreator
{
    private int _a;
    
    public string GetMessage()
    {
        _a += 1;
        return $"test {_a}";
    }
}