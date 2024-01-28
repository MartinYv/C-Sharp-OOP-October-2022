namespace Book.Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;

    public class Tests
    {

        [Test]
        public void Ctor_Test()
        {

            Book book = new Book("Name", "Author");

            Assert.AreEqual("Name", book.BookName);
            Assert.AreEqual("Author", book.Author);
        }

        [Test]
        public void BookNameIsNullOrEmpty()
        {
            Assert.Throws<ArgumentException>(() => new Book(null, "BBB"));
            Assert.Throws<ArgumentException>(() => new Book("", "BBB"));
        }


        [Test]
        public void AuthorIsNullOrEmpty()
        {
            Assert.Throws<ArgumentException>(() => new Book("BBB", null));
            Assert.Throws<ArgumentException>(() => new Book("BBB", ""));
        }

        [Test]
        public void Add_FootNote_Throws()
        {
            Dictionary<int, string> footNote = new Dictionary<int, string>();
            footNote.Add(5, "Asd");


            Assert.Throws<InvalidOperationException>(() => footNote.Add(5, "Asd"));

        }

        [Test]
        public void Add_FootNote()
        {
            Dictionary<int, string> footNote = new Dictionary<int, string>();

            footNote.Add(5, "Asd");


           
            foreach (var item in footNote)
            {
                Assert.AreEqual(5, item.Key);
            Assert.AreEqual("Asd", item.Value);
            }


            

        }

        [Test]
        public void Add_DubliCate_FootNote_Throws()
        {
            Dictionary<int, string> footNote = new Dictionary<int, string>();
            footNote.Add(5, "Asd");
            

            if (footNote.ContainsKey(5))
            {
                Assert.Throws<ArgumentException>(() => footNote.Add(5, "Asd"));
            }
         
    }


        [Test]
        public void Find_FootNote()
        {
            Dictionary<int, string> footNote = new Dictionary<int, string>();
            footNote.Add(5, "Asd");

            int findByKey = 11;
            
                Assert.Throws<InvalidOperationException>(() => Assert.AreNotEqual(5, footNote.ContainsKey(findByKey)));
            

        }



        [Test]
        public void Find_ExistingFootnote()
        {

            Dictionary<int, string> footNote = new Dictionary<int, string>();
            footNote.Add(5, "Asd");

            if (footNote.ContainsKey(5))
            {
                footNote[5] = "asdasd";
            }

            Assert.AreEqual(footNote[5], "asdasd");
            
        }
    }
}
