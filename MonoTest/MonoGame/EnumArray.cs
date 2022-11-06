using System;

namespace MonoWrap;

//特定の列挙型でのみアクセス可能なコンテナ
public class EnumArray<T,TEnum> where T : new()
{
    T[] array;

    public EnumArray(int Size)
    {
        array = new T[Size];

        for (int i = 0; i < Size; i++)
        {
            array[i] = new T();
        }

    }

    public T this[TEnum tenum]
    {
        set { this.array[(int)(object)tenum] = value; }
        get { return this.array[(int)(object)tenum]; }

    }
}
