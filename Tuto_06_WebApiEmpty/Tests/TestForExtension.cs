using DatabaseThree.Models;
using DatabaseTwo.Models;

namespace Tuto_06_MinimalApi.Tests
{
    public static class TestForExtension
    {
        public static string Test(this Book book)
        {
            book.Title = "Test";
            return $"Title =>> {book?.Title}";
        }
    }
}
