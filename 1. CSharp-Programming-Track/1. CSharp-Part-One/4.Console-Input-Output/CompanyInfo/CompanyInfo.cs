using System;
//A company has name, address, phone number, fax number, web site and manager.
//The manager has first name, last name, age and a phone number. 
//Write a program that reads the information about a company and its manager and prints them on the console.


class CompanyInfo
{
    static void Main()
    {
        Console.WriteLine("Ënter information about your company.");
        Console.Write("Company name: ");
        string companyName = Console.ReadLine();
        Console.Write("Company address: ");
        string companyAddress = Console.ReadLine();
        Console.Write("Company phone number: ");
        string companyPhone = Console.ReadLine();
        Console.Write("Company fax number: ");
        string fax = Console.ReadLine();
        Console.Write("Company web site: ");
        string website = Console.ReadLine();
        Console.WriteLine("Done. Let's proceed with the manager.");
        Console.Write("First name: ");
        string firstName = Console.ReadLine();
        Console.Write("Last name: ");
        string lastName = Console.ReadLine();
        Console.Write("Age: ");
        byte age = byte.Parse(Console.ReadLine());
        Console.Write("Phone: ");
        string managerPhone = Console.ReadLine();
        Console.WriteLine("\n"+new string('-',80));
        Console.WriteLine("Company name: {0}\nCompany adress: {1}\nCompany phone: {2}\nCompany fax: {3}\nCompany website: {4}\n",
            companyName, companyAddress, companyPhone, fax, website);
        Console.WriteLine("Manager first name: {0}\nManager last name: {1}\nManager age: {2}\nManager phone: {3}",
            firstName, lastName, age, managerPhone);
    }
}

