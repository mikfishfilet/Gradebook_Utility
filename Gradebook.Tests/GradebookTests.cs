namespace Gradebook.Tests
{
    public class GradebookTests
    {
        [Fact]
        public void AddGrade_AddsValidGrade()
        {
            Gradebook book = new Gradebook();
            book.AddGrade(90);

            Assert.Equal(90, book.GetHighest());
        }
        [Fact]
        public void GetAverage_ReturnsCorrectValue()
        {
            Gradebook book = new Gradebook();

            book.AddGrade(80);
            book.AddGrade(90);
            book.AddGrade(100);

            Assert.Equal(90, book.GetAverage(), 2);
        }
        [Fact]
        public void GetHighestedAndLowest_WorkCorrectly()
        {
            Gradebook book = new Gradebook();

            book.AddGrade(70);
            book.AddGrade(85);
            book.AddGrade(95);

            Assert.Equal(95, book.GetHighest());
            Assert.Equal(70, book.GetLowest());
        }
    }
}
