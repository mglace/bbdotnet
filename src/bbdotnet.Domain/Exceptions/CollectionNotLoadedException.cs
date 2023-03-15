namespace bbdotnet.Domain.Exceptions;

[Serializable]
public class CollectionNotLoadedException : Exception
{
    public CollectionNotLoadedException(string collectionName) 
        : base($"{collectionName} is not loaded.") { }
        
    protected CollectionNotLoadedException(
      System.Runtime.Serialization.SerializationInfo info,
      System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}
