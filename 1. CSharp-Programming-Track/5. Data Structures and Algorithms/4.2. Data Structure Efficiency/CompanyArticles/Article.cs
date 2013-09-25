using System;

//A large trade company has millions of articles, each described by barcode, vendor, title and price. 

public class Article : IComparable<Article>
{
    public string Barcode { get; set; }
    public string Vendor { get; set; }
    public string Title { get; set; }
    public decimal Price { get; set; }

    public Article(string barcode, string vendor, string title, decimal price)
    {
        this.Barcode = barcode;
        this.Vendor = vendor;
        this.Title = title;
        this.Price = price;
    }

    public override string ToString()
    {
        string result = string.Format("Title: {0}, Vendor: {1}, Price: {2}, Barcode: {3}"
            , this.Title, this.Vendor, this.Price, this.Barcode);
        return result;
    }

    public int CompareTo(Article other)
    {
        if (this == null && other == null)
        {
            return 0;
        }
        else if (this == null)
        {
            return -1;
        }
        else if (other == null)
        {
            return 1;
        }

        int result = this.Title.CompareTo(other.Title);

        if (result == 0)
        {
            result = this.Vendor.CompareTo(other.Vendor);
        }

        if (result == 0)
        {
            result = this.Price.CompareTo(other.Price);
        }

        if (result == 0)
        {
            result = this.Barcode.CompareTo(other.Barcode);
        }

        return result;
    }
}

