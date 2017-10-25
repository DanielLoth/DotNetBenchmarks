namespace NET46
{
    public interface Cut<T>
    {

    }

    public struct AboveAll<T> : Cut<T>
    {

    }

    public struct Range<T> where T : struct
    {
        //private readonly Cut<int> _lower;
        //private readonly Cut<int> _upper;

        //public Cut<int> LowerBound => _lower;
        //public Cut<int> UpperBound => _upper;

        private readonly T _lower;
        private readonly T _upper;

        public T LowerBound => _lower;
        public T UpperBound => _upper;

        public Range(T lower, T upper)
        {
            _lower = lower;
            _upper = upper;
        }
    }
}
