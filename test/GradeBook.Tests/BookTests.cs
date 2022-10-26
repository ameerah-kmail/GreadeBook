using System;
using Xunit;
namespace GradeBook.Tests
{

    
    public class BookTests
    {
        [Fact]
        public void Test1()
        {
            //arrange

            /* var x = 9;
            var y = 8;
            var expected = 72;*/
            var book = new Book();
            book.AddGrade(10);
            book.AddGrade(10);
            book.AddGrade(10);


            //act
            //var actual = x * y;
            var result = book.getStatistics();

            //Assert
            //Assert.Equal(expected, actual);
            Assert.Equal(10, result.Average,1);
            Assert.Equal(30, result.High,1);
            Assert.Equal(5, result.Low,1);
            Assert.Equal('B', result.Letter);


        }
    }
}