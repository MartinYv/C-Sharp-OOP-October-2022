namespace Robots.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    public class RobotsTests
    {
        [Test]
        public void Ctor_Test_Working()
        {
            RobotManager manager = new RobotManager(5);

            List<Robot> robots = new List<Robot>();
            Assert.AreEqual(5, manager.Capacity);

           Assert.AreEqual(robots.Count, manager.Count);
        }

        [Test]

        public void CapacityLessThenZero_Throws()
        {
            Assert.Throws<ArgumentException>(() =>  new RobotManager(-1));

        }

        [Test]

        public void CounterCheckPossitive()
        {
            RobotManager manager = new RobotManager(5);
            Robot robot = new Robot("Asd", 100);

            manager.Add(robot);

            Assert.AreEqual(1, manager.Count);

        }

        [Test]
        public void Adding_Throws()
        {
            Robot robot = new Robot("Asd", 100);
            Robot robot2 = new Robot("Asd", 111);

            RobotManager manager = new RobotManager(5);

            manager.Add(robot);

            Assert.Throws<InvalidOperationException>(() => manager.Add(robot2));
        }


        [Test]
        public void Adding_Throw_WhenThereIsNoCapacity()
        {
            RobotManager manager = new RobotManager(1);

            Robot robot = new Robot("Asd", 100);
            Robot robot2 = new Robot("Asd", 111);

            manager.Add(robot);

            Assert.Throws<InvalidOperationException>(() => manager.Add(robot2));
        }

        [Test]
        public void Remove_Throws_WhenRobotIs_NotFound()
        {
            RobotManager manager = new RobotManager(1);

            Assert.Throws<InvalidOperationException>(() => manager.Remove("asd"));
        }

        [Test]
        public void Remove_Works_Positive()
        {
            RobotManager manager = new RobotManager(1);
            Robot robot = new Robot("Asd", 100);

            manager.Add(robot);
            manager.Remove("Asd");
            Assert.AreEqual(0, manager.Count);
        }


        [Test]
        public void Work_Throws_WhenRobotIs_NotFound()
        {
            RobotManager manager = new RobotManager(1);

            Assert.Throws<InvalidOperationException>(() => manager.Work("asd","Cleaner", 10));
        }

        [Test]
        public void Work_Method_Throws_When_Robot_Doesnt_Have_Enough_Battery_For_Work()
        {
            RobotManager manager = new RobotManager(1);
            Robot robot = new Robot("Asd", 10);

            manager.Add(robot);

            Assert.Throws<InvalidOperationException>(() => manager.Work("Asd", "Cleaner", 20));
        }

        [Test]
        public void Work_Method_Works_Positive()
        {
            RobotManager manager = new RobotManager(1);
            Robot robot = new Robot("Asd", 100);

            manager.Add(robot);

          manager.Work("Asd", "Cleaner", 20);

            Assert.AreEqual(80, robot.Battery);
        }

        [Test]
        public void Charge_Method_Throws_When_Robot_Doesnt_Exist()
        {
            RobotManager manager = new RobotManager(1);
            Robot robot = new Robot("Asd", 10);

            manager.Add(robot);

            Assert.Throws<InvalidOperationException>(() => manager.Charge("xxx"));
        }

        [Test]
        public void Charge_Method_Works_Possitive()
        {
            RobotManager manager = new RobotManager(1);
            Robot robot = new Robot("Asd", 10);

            manager.Add(robot);
            manager.Work("Asd", "Clean", 2);
           
            manager.Charge("Asd");

            Assert.AreEqual(robot.Battery, robot.MaximumBattery);
        }
    }
}
