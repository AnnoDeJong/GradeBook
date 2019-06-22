using System;
using Xunit;

namespace GradeBook.Tests
{
    public class TypeTests
    {
        [Fact]
        public void StringsBehavesLikevalueTypes()
        {
            string name = "Andre";
            MakeUpperCase(name);

            Assert.NotEqual("ANDRE", name);
        }

        private void MakeUpperCase(string parameter)
        {
            parameter.ToUpper();
        }

        [Fact]
        public void SetValueTypeByRef()
        {
            var x = GetInt();
            SetIntByRef(ref x);

            Assert.Equal(42, x);
        }

        private void SetIntByRef(ref int z)
        {
            z = 42;
        }

        [Fact]
        public void SetValueType()
        {
            var x = GetInt();
            SetInt(x);          //the value is copied, as this is a valuetype

            Assert.Equal(3, x);
        }

        private void SetInt(int z)
        {
            z = 42;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void CSharpCanPassByRef()
        {
            //arrange
            var book1 = GetBook("Book 1");
            GetBookSetNameByRef(ref book1, "New Name"); //can also be GetBookSetNameByRef(out book1, "New Name");
            //act

            //assert
            Assert.Equal("New Name", book1.Name);
        }

        private void GetBookSetNameByRef(ref Book book, string name) //can also be private void GetBookSetNameByRef(out Book book, string name)
        {
            //using "out" the C# compiler assumes the object has not been initialised and will through an error if not done
            book = new Book(name);
        }

        [Fact]
        public void CSharpIsPassByValue()
        {
            //arrange
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");
            //act

            //assert
            Assert.Equal("Book 1", book1.Name);
        }

        private void GetBookSetName(Book book, string name)
        {
            book = new Book(name);
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            //arrange
            var book1 = GetBook("Book 1");
            setName(book1, "New Name");
            //act

            //assert
            Assert.Equal("New Name", book1.Name);
        }

        private void setName(Book book1, string name)
        {
            book1.Name = name;
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            //arrange
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");
            //act

            //assert
            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);
        }

        [Fact]
        public void TwoVarsCanReferenceTheSameObject()
        {
            //arrange
            var book1 = GetBook("Book 1");
            var book2 = book1;
            //act

            //assert
            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));
        }
        Book GetBook(string name)
        {
            return new Book(name);
        }
    }
}
