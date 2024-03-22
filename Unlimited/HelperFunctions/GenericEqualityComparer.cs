namespace HelperFunctions
{
  public class GenericEqualityComparer<T> : IEqualityComparer<T>
  {
    private readonly Func<T, T, bool> _equalityComparer;
    private readonly Func<T, int> _hashFunction;

    public GenericEqualityComparer(Func<T, T, bool> equalityComparer, Func<T, int> hashFunction)
    {
      _equalityComparer = equalityComparer;
      _hashFunction = hashFunction;
    }

    public bool Equals(T x, T y)
    {
      return _equalityComparer(x, y);
    }

    public int GetHashCode(T obj)
    {
      return _hashFunction(obj);
    }
  }
}
