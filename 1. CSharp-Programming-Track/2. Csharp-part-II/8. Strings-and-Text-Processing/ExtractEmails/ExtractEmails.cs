//Write a program for extracting all email addresses from given text.
//All substrings that match the format <identifier>@<host>…<domain> should be recognized as emails.

using System;
using System.Text.RegularExpressions;


class ExtractEmails
{
    static void Main()
    {
        string text = "mail@gmail.com.uk.co.uk Write a program -mail_invalid#valid@gmail.com for extracting mail-91_abc@uk.co.com some_mail@gmail.com all email addresses form@a.given.text All substrings@mail.co.uk.net and one last email svetlin@nakov.com";
        MatchCollection mails = Regex.Matches(text, @"[a-zA-Z][\w-\.]+@[a-zA-Z][a-zA-Z-]+\.([a-zA-Z][a-zA-Z-]+\.){0,200}[a-zA-Z]{2,4}");
        foreach (Match mail in mails)
        {
            Console.WriteLine(mail);
        }
    }
}

