namespace bbdotnet.Domain.Exceptions;

[Serializable]
public class CollectionNotInitializedException : Exception
{
    public CollectionNotInitializedException(string collectionName) 
        : base($"{collectionName} is not loaded.") { }
        
    protected CollectionNotInitializedException(
      System.Runtime.Serialization.SerializationInfo info,
      System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}
