namespace Praqtikuli_21._07.Common;

public class Entity
{
    private static int _counter = 1;
    
    public int Id { get; private set; }
    
    public Entity()=> Id = _counter++;
}