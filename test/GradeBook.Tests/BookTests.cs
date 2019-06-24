using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void GradeValueValidation()
        {
            //arrange
            var book = new InMemoryBook("Test Grade Book");
            
            //act
            try
            {
                book.AddGrade(105);
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            //assert
            Assert.True(!book.GradeExists(105));
        }
        [Fact]
        public void BookCalculatesAnAverageGrade()
        {
            //arrange
            var book = new InMemoryBook("Test Grade Book");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            //act
            var result = book.GetStatistics();

            //assert
            Assert.Equal(85.6, result.average, 1);
            Assert.Equal(90.5, result.high, 1);
            Assert.Equal(77.3, result.low, 1);
            Assert.Equal('B', result.letter);
        }
    }
}
