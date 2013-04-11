using System;
//A bank account has a holder name (first name, middle name and last name),
//available amount of money (balance), bank name, IBAN, BIC code and 3 credit card numbers
//associated with the account. Declare the variables needed to keep the information for a 
//single bank account using the appropriate data types and descriptive names.


class BankAccount
{
    static void Main()
    {
        string firstName = "Ivan";
        string middleName = "Ivanov";
        string lastName = "Ivanov";
        decimal money = 1235.55M;
        string bankName = "DSK Bank";
        string IBAN = "BG00011FFCC1100022";
        string BIC = "32194CC255";
        ulong firstCreditCard = 44132314544L;
        ulong secondCreditCard = 994561165L;
        ulong thirdCreditCard = 12144477788921L;
        Console.WriteLine("First name: {0}\nMiddle name: {1}\nLast name: {2}\nMoney ballance: {3}\nBank name: {4}",
            firstName,middleName,lastName,money,bankName);
        Console.WriteLine("IBAN: {0}\nBIC: {1}\nCredit card: {2}\nCredit card: {3}\nCredit card: {4}\n",
            IBAN,BIC,firstCreditCard,secondCreditCard,thirdCreditCard);

    }
}

