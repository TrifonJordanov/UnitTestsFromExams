namespace Book.Tests
{
    using System;
    using NUnit.Framework;

    public class Tests
    {
        [Test]
        public void ValidateConstructor()
        {
            Book book = new Book("BestSeller", "TheBest");
            Assert.AreEqual("BestSeller", book.BookName);
            Assert.AreEqual("TheBest", book.Author);
        }

        [Test]
        public void ValidateConstructor_CreateCollectionOfNotes()
        {
            Book book = new Book("BestSeller", "TheBest");
            Assert.AreEqual(0, book.FootnoteCount);
        }

        [Test]
        public void ValidateBookNameProperty_ThrowExceptionWithNull()
        {
            Assert.Throws<ArgumentException>(() => new Book(null, "Author"));
        }

        [Test]
        public void ValidateBookNameProperty_ThrowExceptionWithEmpty()
        {
            Assert.Throws<ArgumentException>(() => new Book("", "Author"));
        }

        [Test]
        public void ValidateAuthorProperty_ThrowExceptionWithNull()
        {
            Assert.Throws<ArgumentException>(() => new Book("BestSeller", null));
        }

        [Test]
        public void ValidateAuthorProperty_ThrowExceptionWithEmpty()
        {
            Assert.Throws<ArgumentException>(() => new Book("BestSeller", ""));
        }

        [Test]
        public void ValidateAddFootnoteMethod_AddingCorrectlyFootnoteToTheBook()
        {
            Book book = new Book("BestSeller", "TheBest");
            book.AddFootnote(12, "TextOnPage12");
            Assert.AreEqual(1, book.FootnoteCount);
        }

        [Test]
        public void ValidateAddFootnoteMethod_ThrowExceptionWithExistingFootnote()
        {
            Book book = new Book("BestSeller", "TheBest");
            book.AddFootnote(12, "TextOnPage12");
            Assert.Throws<InvalidOperationException>(() => book.AddFootnote(12, "TextOnPage12Again"));
        }

        [Test]
        public void ValidateFindFootnoteMethod_ReturnCorrectlyFootnote()
        {
            Book book = new Book("BestSeller", "TheBest");
            book.AddFootnote(12, "TextOnPage12");
            var text = book.FindFootnote(12);
            Assert.AreEqual(text, "Footnote #12: TextOnPage12");
        }

        [Test]
        public void ValidateFindFootnoteMethod_ThrowExceptionWithUnExistFootnotePage()
        {
            Book book = new Book("BestSeller", "TheBest");
            Assert.Throws<InvalidOperationException>(() => book.FindFootnote(12));
        }

        [Test]
        public void ValidateAlterFootnoteMethod_UpdateCorrectlyFootnoteText()
        {
            Book book = new Book("BestSeller", "TheBest");
            book.AddFootnote(12, "TextOnPage12");
            book.AlterFootnote(12, "NewTextOnPage12");
            var text = book.FindFootnote(12);
            Assert.AreEqual(text, "Footnote #12: NewTextOnPage12");
        }

        [Test]
        public void ValidateAlterFootnoteMethod_ThrowExceptionWithNonExistingFootnoteNumber()
        {
            Book book = new Book("BestSeller", "TheBest");
            Assert.Throws<InvalidOperationException>(() => book.AlterFootnote(12, "NewTextOnPage12"));
        }
    }
}