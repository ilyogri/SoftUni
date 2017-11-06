namespace _07.Animals
{
    using System;
    using System.Collections.Generic;
    using Models;

    public class Startup
    {
        public static void Main()
        {
            var animals = new List<Animal>();
            var animalTypeName = Console.ReadLine();
            while (animalTypeName != "Beast!")
            {
                try
                {
                    var animalTypeArgs = Console.ReadLine().Split();
                    var name = animalTypeArgs[0];
                    var age = int.Parse(animalTypeArgs[1]);
                    var gender = animalTypeArgs[2];
                    switch (animalTypeName)
                    {
                        case "Cat":
                            var cat = new Cat(name, age, gender);
                            animals.Add(cat);
                            break;
                        case "Dog":
                            var dog = new Dog(name, age, gender);
                            animals.Add(dog);
                            break;
                        case "Frog":
                            var frog = new Frog(name, age, gender);
                            animals.Add(frog);
                            break;
                        case "Kitten":
                            var kittens = new Kitten(name, age, "Female");
                            animals.Add(kittens);
                            break;
                        case "Tomcat":
                            var tomcat = new Tomcat(name, age, "Male");
                            animals.Add(tomcat);
                            break;
                        default:
                            Console.WriteLine("Invalid input!");
                            break;
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input!");
                }
                animalTypeName = Console.ReadLine();
            }
            PrintResult(animals);
        }

        public static void PrintResult(List<Animal> animals)
        {
            foreach (var a in animals)
            {
                Console.WriteLine(a.ToString());
                Console.WriteLine($"{a.Name} {a.Age} {a.Gender}");
                Console.WriteLine(a.ProduceSound());
            }
        }
    }
}