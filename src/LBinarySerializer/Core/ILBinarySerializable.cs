namespace LBinarySerializer;

public interface ILBinarySerializable
{
    public void Serialize(LBinarySerializer serializer);
    public void Deserialize<T>(LBinaryDeserializer deserializer);
}