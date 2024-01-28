namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ExtendedDatabaseTests
    {

        [Test]
        public void Add_Already_Existing_Person_By_Name()
        {
            Person person1 = new Person(12345, "Pesho");

            Database dataBase = new Database();

            dataBase.Add(person1);

            Person person2 = new Person(1234, "Pesho");

            Assert.Throws<InvalidOperationException>(() => dataBase.Add(person2));
        }

        [Test]
        public void Add_Already_Existing_Person_By_Id()
        {
            Person person1 = new Person(12345, "Pesho");

            Database dataBase = new Database();

            dataBase.Add(person1);

            Person person2 = new Person(12345, "Gosho");

            Assert.Throws<InvalidOperationException>(() => dataBase.Add(person2));
        }

        [Test]
        public void Remove_When_There_Are_No_Persons()
        {

            Database dataBase = new Database();
            Person person1 = new Person(12345, "Pesho");

            Assert.Throws<InvalidOperationException>(() => dataBase.Remove());

        }

        [Test]
        public void Remove_When_There_Are__Persons()
        {

            Database dataBase = new Database();
            Person person1 = new Person(12345, "Pesho");
            dataBase.Add(person1);

            dataBase.Remove();
            Assert.AreEqual(0, dataBase.Count);

        }

        [TestCase("Gosho")]
        [TestCase("Pesho")]
        public void Find_Existing_User_By_Username(string username)
        {
            Database dataBase = new Database();

            Person person1 = new Person(12345, "Pesho");
            Person person2 = new Person(123245, "Gosho");

            dataBase.Add(person1);
            dataBase.Add(person2);

            bool isItCondain = dataBase.FindByUsername(username).UserName == username;

            Assert.IsTrue(isItCondain);
        }

        [TestCase("Gosho")]
        [TestCase("Pesho")]
        public void Find_Non_Existing_User_By_Username(string username)
        {

            Database dataBase = new Database();

            Person person1 = new Person(12345, "Asdo");
            Person person2 = new Person(123245, "Zko");

            dataBase.Add(person1);
            dataBase.Add(person2);

            Assert.Throws<InvalidOperationException>(() => dataBase.FindByUsername(username));

        }

        [Test]
        public void Find_By_Username_When_Its_Null()
        {

            Database dataBase = new Database();

            Person person1 = new Person(12345, null);

            Assert.Throws<ArgumentNullException>(() => dataBase.FindByUsername(person1.UserName));
        }

        [Test]
        public void Find_By_Id_When_Its_Negative()
        {
            Database dataBase = new Database();

            Person person1 = new Person(-12345, "Jivka");

            Assert.Throws<ArgumentOutOfRangeException>(() => dataBase.FindById(person1.Id));
        }

        [Test]

        public void Find_By_Id_When_There_Isnt_Existing_User()
        {
            Database dataBase = new Database();

            Person person1 = new Person(12345, "Jivka");

            Assert.Throws<InvalidOperationException>(() => dataBase.FindById(person1.Id));
        }

    
        [Test]
        public void Constructor_Test2()
        {
            Database dataBase = new Database(new Person[]
            {
          new Person (12,"asd"),
          new Person (13,"asdd"),

            });
            Assert.AreEqual(12, dataBase.FindById(12).Id);
            Assert.AreEqual(13, dataBase.FindById(13).Id);
            Assert.AreEqual("asd", dataBase.FindByUsername("asd").UserName);
            Assert.AreEqual("asdd", dataBase.FindByUsername("asdd").UserName);
        }


        [Test]
        public void Add_Persons_In_Range_Of_Limit_16()
        {
            Database dataBase = new Database(new Person[]
                {
                    new Person(13323,"Asdz"),
                    new Person(124423,"Asdx"),
                    new Person(13223,"Asdc"),
                    new Person(142234,"Asdv"),
                    new Person(151223,"Asdb"),
                    new Person(164323,"Asdn"),
                    new Person(1723523,"Asdm"),
                    new Person(1865323,"Asasdd,"),
                    new Person(191323,"Asdaq"),
                    new Person(1025433,"Asdww"),
                    new Person(1234513,"Asdee"),
                    new Person(1223423,"Asdrr"),
                    new Person(1238573,"Asdtg"),
                    new Person(190243,"Asdvd"),
                    new Person(12953,"Asdqw"),
                    new Person(127963,"Asdfs"),
                });

            Assert.Throws<InvalidOperationException>(() => dataBase.Add(new Person(777, "sssss")));
        }

        [Test]
        public void Add_Persons_In_Range()
        {
            Database dataBase = new Database();

            Person[] persons =
            {
               new Person(123,"fff" ),
                new Person(1223,"f4ff" ),
            };

            dataBase = new Database(persons);

            Assert.AreEqual(persons.Length, dataBase.Count);
        }

        [TestCase("Asd")]
        public void Arguments_Are_Case_Sensitive(string argument)
        {
            Person person = new Person(1223423, "Asd");

            Assert.AreEqual(argument, person.UserName);
        }

        [TestCase(456)]
        public void Arguments_Are_Case_Sensitive(int argument)
        {
            Person person = new Person(456, "Asd");

            Assert.AreEqual(argument, person.Id);
        }

    }
}