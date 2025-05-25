namespace LBinarySerializer.Tests;

public class DummyShort : ILBinarySerializable
{
    public int Age { get; set; }
    public DummyNestedShort[] Array { get; set; }
    
    public void Serialize(LBinarySerializer serializer)
    {
        serializer.Write(Age);
        serializer.Write(Array);
    }

    public void Deserialize<T>(LBinaryDeserializer deserializer)
    {
        Age = deserializer.ReadInt();
        Array = deserializer.ReadArrayOf<DummyNestedShort>()!;
    }
}

public class DummyNestedShort : ILBinarySerializable
{
    public string Name { get; set; }
    
    public void Serialize(LBinarySerializer serializer)
    {
        serializer.Write(Name);
    }

    public void Deserialize<T>(LBinaryDeserializer deserializer)
    {
        Name = deserializer.ReadString()!;
    }
}
