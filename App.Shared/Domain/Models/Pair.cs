namespace App.Shared.Domain.Models
{
    public class Pair<T, U>
    {
        public T First { get; }
        public U Second { get; }

        public Pair(T first, U second)
        {
            First = first;
            Second = second;
        }
    }
}
