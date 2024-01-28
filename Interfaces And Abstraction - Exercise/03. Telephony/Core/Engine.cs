namespace Telephony.Core
{
    using System;
    using Interfaces;
    using IO.Interfaces;
    using Models;
    using Models.Interfaces;
    using Telephony.Exeptions;

    public class Engine : IEngine
    {
        //I do not know the type of the reader and writer
        //Someone outside of the engine sets their type
        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly IStationaryPhone stationaryPhone;
        private readonly ISmartphone smartphone;

        private Engine()
        {
            stationaryPhone = new StationaryPhone();
            smartphone = new Smartphone();
        }

        public Engine(IReader reader, IWriter writer)
            : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            //Using Console.ReadLine() method rejects another apps to use our logic..
            //We cannot have shared Engine class and shared business logic... :(
            string[] phoneNumbers = this.reader.ReadLine()
            .Split(' ');
            string[] urls = reader.ReadLine()
                .Split(' ');

            foreach (string phoneNumber in phoneNumbers)
            {
                try
                {
                    if (phoneNumber.Length == 10)
                    {
                        writer.WriteLine(smartphone.Call(phoneNumber));
                    }
                    else if (phoneNumber.Length == 7)
                    {
                        writer.WriteLine(stationaryPhone.Call(phoneNumber));
                    }
                    else
                    {
                        throw new InvalidPhoneNumberExeption();
                    }
                }
                catch (InvalidPhoneNumberExeption ipne)
                {
                    writer.WriteLine(ipne.Message);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            foreach (string url in urls)
            {
                try
                {
                    writer.WriteLine(smartphone.BrowseURL(url));
                }
                catch (InvalidURLException iue)
                {
                   writer.WriteLine(iue.Message);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}