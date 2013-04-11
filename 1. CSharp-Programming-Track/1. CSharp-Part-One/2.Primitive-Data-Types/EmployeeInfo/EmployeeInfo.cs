using System;
//A marketing firm wants to keep record of its employees. Each record would have the following characteristics
//– first name, family name, age, gender (m or f), ID number, unique employee number (27560000 to 27569999).
//Declare the variables needed to keep the information for a single employee using appropriate data types and descriptive names.

class EmployeeInfo
{
    enum genders
    {
        male, female
    };
    static void Main()
    {
        string firstName = "Viktor";
        string lastName = "Bahtev";
        byte age = 21;
        genders gender = genders.male;
        int ID = 123456789;
        int uniqueEmployeeNumber = 27569999;
        Console.WriteLine("First name:{0}\nLast name:{1}\nAge:{2}\nGender:{3}\nID:{4}\nUniqueEmployeeNumber:{5}",
            firstName, lastName, age, gender, ID, uniqueEmployeeNumber);
    }
}