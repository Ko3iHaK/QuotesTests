using System;

namespace QuotesTests
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("������ ������ ������ ����� quotes.toscrape.com");

            using var tests = new QuotesTests();
            try
            {
                tests.TestHomePageTitle();
                Console.WriteLine("TestHomePageTitle �������.");

                tests.TestFirstQuoteIsDisplayed();
                Console.WriteLine("TestFirstQuoteIsDisplayed �������.");

                tests.TestAuthorLinkNavigation();
                Console.WriteLine("TestAuthorLinkNavigation �������.");

                tests.TestLoginLinkNavigation();
                Console.WriteLine("TestLoginLinkNavigation �������.");

                tests.TestLoginFormFieldsExist();
                Console.WriteLine("TestLoginFormFieldsExist �������.");

                tests.TestLoginFormInput();
                Console.WriteLine("TestLoginFormInput �������.");

                tests.TestLoginProcess();
                Console.WriteLine("TestLoginButtonClick �������.");

                tests.TestNextPageNavigation();
                Console.WriteLine("TestNextPageNavigation �������.");

                tests.TestTagLinkNavigation();
                Console.WriteLine("TestTagLinkNavigation �������.");

                tests.TestQuoteCountGreaterThanZero();
                Console.WriteLine("TestQuoteCountGreaterThanZero �������.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("������ ��� ������� �����: " + ex.Message);
            }

            Console.WriteLine("���������������� ������ ��������. ������� ����� ������� ��� ������.");
            Console.ReadKey();
        }
    }
}
