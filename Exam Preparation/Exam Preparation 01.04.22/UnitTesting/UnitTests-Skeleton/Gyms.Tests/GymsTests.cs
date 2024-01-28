using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Gyms.Tests
{
    public class GymsTests
    {
        [Test]
        public void Constructor_Testing()
        {
            Gym gym = new Gym("Asd", 10);

            Assert.AreEqual("Asd", gym.Name);
            Assert.AreEqual(10, gym.Capacity);
        }

        [Test]

        public void Testing_Name_Set()
        {

            Assert.Throws<ArgumentNullException>(() => new Gym("", 10));
            Assert.Throws<ArgumentNullException>(() => new Gym(null, 10));
        }

        [Test]

        public void Testing_Negative_Capacity_Throws()
        {

            Assert.Throws<ArgumentException>(() => new Gym("asd", -10));
            Assert.Throws<ArgumentException>(() => new Gym("Fighters", -110));
        }

        [Test]
        public void Testing_Count()
        {
            List<Athlete> athletes = new List<Athlete>(0);
            Gym gym = new Gym("Asd", 0);
            Assert.AreEqual(gym.Count, athletes.Count);
        }



        [Test]
        public void Testing_Adding_Athlete_Possitive()
        {
            Athlete athlete = new Athlete("Gosho");
            Gym gym = new Gym("Asd", 10);

            gym.AddAthlete(athlete);

            Assert.AreEqual(1, gym.Count);
        }

        [Test]
        public void Testing_Adding_Athlete_Negative()
        {
            Athlete athlete = new Athlete("Gosho");
            Gym gym = new Gym("Asd", 1);
            gym.AddAthlete(athlete);

            Athlete athlete2 = new Athlete("Pesho");


            Assert.Throws<InvalidOperationException>(() => gym.AddAthlete(athlete2));
        }


        [Test]
        public void Remove_Athlete_When_Its_NUll()
        {
            Athlete athlete = new Athlete("Gosho");
            Gym gym = new Gym("Asd", 1);
            gym.AddAthlete(athlete);

            Athlete athlete2 = new Athlete("Pesho");


            Assert.Throws<InvalidOperationException>(() => gym.RemoveAthlete("Pesho"));
        }

        [Test]
        public void Remove_Athlete_Positive()
        {

            Gym gym = new Gym("Asd", 5);

            Athlete athlete = new Athlete("Gosho");
            gym.AddAthlete(athlete);

            Athlete athlete2 = new Athlete("Pesho");
            gym.AddAthlete(athlete2);


            gym.RemoveAthlete(athlete.FullName);
            Assert.AreEqual(1, gym.Count);

        }


        [Test]
        public void Injure_Athlete_When_Its_NUll()
        {
            Athlete athlete = new Athlete("Gosho");
            Gym gym = new Gym("Asd", 1);
            gym.AddAthlete(athlete);

            


            Assert.Throws<InvalidOperationException>(() => gym.InjureAthlete("Pesho"));
        }


        [Test]
        public void Injure_Athlete_Positive()
        {

            Gym gym = new Gym("Asd", 5);

            Athlete athlete = new Athlete("Gosho");
            gym.AddAthlete(athlete);

            Athlete athlete2 = new Athlete("Pesho");
            gym.AddAthlete(athlete2);

            gym.InjureAthlete("Gosho");

            Assert.IsTrue(athlete.IsInjured);
           

        }


        [Test]
        public void Athletes_Report()
        {

            Gym gym = new Gym("Asd", 5);

            Athlete athlete = new Athlete("Gosho");
            gym.AddAthlete(athlete);

            Athlete athlete2 = new Athlete("Pesho");
            gym.AddAthlete(athlete2);

            gym.InjureAthlete("Gosho");

            Assert.AreEqual(gym.Report() , "Active athletes at Asd: Pesho" ) ;
    
        }
    }
}