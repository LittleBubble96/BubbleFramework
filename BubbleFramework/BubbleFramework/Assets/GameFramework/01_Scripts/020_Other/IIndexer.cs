namespace BubbleFramework
{
    interface IIndexer<T> 
    {
        /// <summary>
        /// get value by index
        /// </summary>
        /// <param name="index"></param>
        T this[int index]
        {
            get;
            set;
        }

        /// <summary>
        /// get index by value
        /// </summary>
        /// <param name="indexValue"></param>
        int this[T indexValue]
        {
            get;
            set;
        }
        
    }
}

