namespace LBinarySerializer.Tests;

public class DummyBaseClass : ILBinarySerializable
{
    public DummyNestedClass? Dummy { get; set; }
    public string? Name { get; set; }
    public int Age { get; set; }
    
    public void Serialize(LBinarySerializer serializer)
    {
        serializer.Write(Dummy);
        serializer.Write(Name);
        serializer.Write(Age);
    }

    public void Deserialize<T>(LBinaryDeserializer deserializer)
    {
        Dummy = deserializer.Deserialize<DummyNestedClass>();
        Name = deserializer.ReadString();
        Age = deserializer.ReadInt();
    }
}