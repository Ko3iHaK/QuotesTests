using System;

namespace QuotesTests
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ручной запуск тестов сайта quotes.toscrape.com");

            using var tests = new QuotesTests();
            try
            {
                tests.TestHomePageTitle();
                Console.WriteLine("TestHomePageTitle пройден.");

                tests.TestFirstQuoteIsDisplayed();
                Console.WriteLine("TestFirstQuoteIsDisplayed пройден.");

                tests.TestAuthorLinkNavigation();
                Console.WriteLine("TestAuthorLinkNavigation пройден.");

                tests.TestLoginLinkNavigation();
                Console.WriteLine("TestLoginLinkNavigation пройден.");

                tests.TestLoginFormFieldsExist();
                Console.WriteLine("TestLoginFormFieldsExist пройден.");

                tests.TestLoginFormInput();
                Console.WriteLine("TestLoginFormInput пройден.");

                tests.TestLoginProcess();
                Console.WriteLine("TestLoginButtonClick пройден.");

                tests.TestNextPageNavigation();
                Console.WriteLine("TestNextPageNavigation пройден.");

                tests.TestTagLinkNavigation();
                Console.WriteLine("TestTagLinkNavigation пройден.");

                tests.TestQuoteCountGreaterThanZero();
                Console.WriteLine("TestQuoteCountGreaterThanZero пройден.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при запуске теста: " + ex.Message);
            }

            Console.WriteLine("Демонстрационный запуск завершён. Нажмите любую клавишу для выхода.");
            Console.ReadKey();
        }
    }
}
