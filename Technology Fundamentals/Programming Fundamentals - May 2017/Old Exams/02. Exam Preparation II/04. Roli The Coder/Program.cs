namespace _04.Roli_The_Coder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RoliTheCoder
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var person = new List<Person>();

            while (input != "Time for Code")
            {
                var args = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                var currentID = args[0];
                var eventName = args[1];
                var participants = args.Skip(2).Take(args.Length).Distinct().ToList();

                if (eventName[0] == '#')
                {
                    eventName = eventName.Remove(0, 1);

                    if (person.All(x => x.ID != currentID))
                    {
                        var personAddInfo =
                            new Person(currentID, eventName, participants);
                        person.Add(personAddInfo);
                    }

                    else
                    {
                        var index = person.FindIndex(x => x.ID == currentID & x.Event == eventName);

                        if (index > -1)
                        {
                            var currentEventParticipants = person[index].Participants;

                            foreach (var participant in participants)
                            {
                                if (!currentEventParticipants.Contains(participant))
                                {
                                    currentEventParticipants.Add(participant);
                                }
                            }

                            var personAddInfo = new Person(currentID, eventName, currentEventParticipants);
                            person[index] = personAddInfo;
                        }
                    }
                }

                input = Console.ReadLine();
            }

            PrintResult(person);
        }

        public static void PrintResult(List<Person> person)
        {
            var sortedPersonData = person
                    .OrderByDescending(p => p.Participants.Count)
                    .ThenBy(e => e.Event);

            foreach (var data in sortedPersonData)
            {
                Console.WriteLine($"{data.Event} - {data.Participants.Count}");

                foreach (var participant in data
                    .Participants
                    .OrderBy(p => p))
                {
                    Console.WriteLine(participant);
                }
            }
        }
    }
}