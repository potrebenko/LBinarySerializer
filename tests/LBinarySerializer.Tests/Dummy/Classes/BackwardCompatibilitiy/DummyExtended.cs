namespace LBinarySerializer.Tests;

public class DummyExtended : ILBinarySerializable
{
    public int Age { get; set; }
    public DummyNestedExtended[] Array { get; set; }
    public string Name { get; set; }

    public void Serialize(LBinarySerializer serializer)
    {
        serializer.Write(Age);
        serializer.Write(Array);
        serializer.Write(Name);
    }

    public void Deserialize<T>(LBinaryDeserializer deserializer)
    {
        Age = deserializer.ReadInt();
        Array = deserializer.ReadArrayOf<DummyNestedExtended>()!;
        Name = deserializer.ReadString()!;
    }
}

public class DummyNestedExtended : ILBinarySerializable
{
    public string Name { get; set; }
    public int Age { get; set; }

    public void Serialize(LBinarySerializer serializer)
    {
        serializer.Write(Name);
        serializer.Write(Age);
    }

    public void Deserialize<T>(LBinaryDeserializer deserializer)
    {
        Name = deserializer.ReadString();
        Age = deserializer.ReadInt();
    }
}