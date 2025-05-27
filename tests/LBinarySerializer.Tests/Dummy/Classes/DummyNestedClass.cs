namespace LBinarySerializer.Tests;

public class DummyNestedClass : ILBinarySerializable
{
    public string Name { get; set; }
    public int Age { get; set; }
    public bool IsAdmin { get; set; }
    public DateTime BirthDate { get; set; }
    public Guid Guid { get; set; }
    public string SecondName { get; set; }
    public DummyEnum DummyEnum { get; set; }

    public void Serialize(LBinarySerializer serializer)
    {
        serializer.Write(Name);
        serializer.Write(Age);
        serializer.Write(IsAdmin);
        serializer.Write(BirthDate);
        serializer.Write(Guid);
        serializer.Write(SecondName);
        serializer.WriteEnum(DummyEnum);
    }

    public void Deserialize<T>(LBinaryDeserializer deserializer)
    {
        Name = deserializer.ReadString();
        Age = deserializer.ReadInt();
        IsAdmin = deserializer.ReadBool();
        BirthDate = deserializer.ReadDateTime();
        Guid = deserializer.ReadGuid();
        SecondName = deserializer.ReadString();
        DummyEnum = deserializer.ReadEnum<DummyEnum>();
    }
}