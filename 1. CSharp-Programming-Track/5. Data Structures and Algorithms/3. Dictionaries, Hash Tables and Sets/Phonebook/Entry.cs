using System;
using System.Collections.Generic;
using System.Linq;

public class Entry
{
    public string Name { get; set; }
    public string Town { get; set; }
    public string Phone { get; set; }

    public Entry(string name, string town, string phone)
    {
        this.Name = name;
        this.Town = town;
        this.Phone = phone;
    }

    public override string ToString()
    {
        string result = Name + " | " + Town + " | " + Phone;
        return result;
    }
}

