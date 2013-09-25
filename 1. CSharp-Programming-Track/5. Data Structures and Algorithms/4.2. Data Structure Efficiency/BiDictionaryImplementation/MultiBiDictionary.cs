using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Wintellect.PowerCollections;

public class MultiBiDictionary<K1, K2, T>
{
    private class BiKeyValue : IEquatable<BiKeyValue>
    {
        public K1 Key1 { get; set; }
        public K2 Key2 { get; set; }
        public T Value { get; set; }

        public BiKeyValue(K1 key1, K2 key2, T value)
        {
            this.Key1 = key1;
            this.Key2 = key2;
            this.Value = value;
        }

        public bool Equals(BiKeyValue other)
        {
            if (this == null && other == null)
            {
                return true;
            }

            if (this == null || other == null)
            {
                return false;
            }

            return this.Key1.Equals(other.Key1) && this.Key2.Equals(other.Key2) && this.Value.Equals(other.Value);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as BiKeyValue);
        }
    }

    private MultiDictionary<K1, BiKeyValue> byFirstKey;
    private MultiDictionary<K2, BiKeyValue> bySecondKey;
    private MultiDictionary<Tuple<K1, K2>, BiKeyValue> byBothKeys;

    public MultiBiDictionary(bool allowDuplicates)
    {
        this.byFirstKey = new MultiDictionary<K1, BiKeyValue>(allowDuplicates);
        this.bySecondKey = new MultiDictionary<K2, BiKeyValue>(allowDuplicates);
        this.byBothKeys = new MultiDictionary<Tuple<K1, K2>, BiKeyValue>(allowDuplicates);
    }

    public int Count
    {
        get
        {
            Debug.Assert(byFirstKey.KeyValuePairs.Count == bySecondKey.KeyValuePairs.Count &&
               bySecondKey.KeyValuePairs.Count == byBothKeys.KeyValuePairs.Count);

            return byFirstKey.KeyValuePairs.Count;
        }
    }

    public void Add(K1 key1, K2 key2, T value)
    {
        BiKeyValue biKeyvalue = new BiKeyValue(key1, key2, value);
        byFirstKey.Add(key1, biKeyvalue);
        bySecondKey.Add(key2, biKeyvalue);
        byBothKeys.Add(new Tuple<K1, K2>(key1, key2), biKeyvalue);
    }

    public ICollection<T> GetValuesByFirstKey(K1 key)
    {
        ICollection<BiKeyValue> biKeyvalues = this.byFirstKey[key];
        ICollection<T> values = biKeyvalues.Select(x => x.Value).ToList();
        return values;
    }

    public ICollection<T> GetValuesBySecondKey(K2 key)
    {
        ICollection<BiKeyValue> biKeyvalues = this.bySecondKey[key];
        ICollection<T> values = biKeyvalues.Select(x => x.Value).ToList();
        return values;
    }

    public ICollection<T> GetValuesByBothKeys(K1 key1, K2 key2)
    {
        ICollection<BiKeyValue> biKeyvalues = this.byBothKeys[new Tuple<K1, K2>(key1, key2)];
        ICollection<T> values = biKeyvalues.Select(x => x.Value).ToList();
        return values;
    }

    public void RemoveValueByFirstKey(K1 key)
    {
        ICollection<BiKeyValue> biKeyvalues = this.byFirstKey[key];

        foreach (BiKeyValue biKeyvalue in biKeyvalues)
        {
            this.bySecondKey.Remove(biKeyvalue.Key2, biKeyvalue);
            this.byBothKeys.Remove(new Tuple<K1, K2>(biKeyvalue.Key1, biKeyvalue.Key2), biKeyvalue);
        }

        this.byFirstKey.Remove(key);
    }

    public void RemoveValueBySecondKey(K2 key)
    {
        ICollection<BiKeyValue> biKeyValues = this.bySecondKey[key];

        foreach (BiKeyValue biKeyValue in biKeyValues)
        {
            this.byFirstKey.Remove(biKeyValue.Key1, biKeyValue);
            this.byBothKeys.Remove(new Tuple<K1, K2>(biKeyValue.Key1, biKeyValue.Key2), biKeyValue);
        }

        this.bySecondKey.Remove(key);
    }

    public void RemoveValueByBothKeys(K1 key1, K2 key2)
    {
        Tuple<K1, K2> keys = new Tuple<K1, K2>(key1, key2);

        ICollection<BiKeyValue> biKeyValues = this.byBothKeys[keys];

        foreach (BiKeyValue biKeyValue in biKeyValues)
        {
            this.byFirstKey.Remove(biKeyValue.Key1, biKeyValue);
            this.bySecondKey.Remove(biKeyValue.Key2, biKeyValue);
        }

        this.byBothKeys.Remove(keys);
    }
}
