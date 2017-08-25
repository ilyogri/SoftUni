namespace _03.Jarvis
{
    using System;

    public class Jarvis
    {
        public static void Main()
        {
            var maximumEnergyCapacity = long.Parse(Console.ReadLine());

            var FirstLeg = new FirstLeg();
            var SecondLeg = new SecondLeg();
            var FirstArm = new FirstArm();
            var SecondArm = new SecondArm();
            var Head = new Head();
            var Torso = new Torso();

            var torsoCounter = 0;
            var legsCount = 0;
            var armsCount = 0;
            var headCounter = 0;

            var data = Console.ReadLine();
            while (data != "Assemble!")
            {
                var args = data.Split();

                var typeOfComponent = args[0];
                var energyConsumption = int.Parse(args[1]);
                var firstProperty = args[2];
                var secondProperty = args[3];

                if (typeOfComponent == "Leg")
                {
                    if (legsCount == 0)
                    {
                        legsCount = 1;

                        FirstLeg.EnergyConsumption = energyConsumption;
                        FirstLeg.Strength = int.Parse(firstProperty);
                        FirstLeg.Speed = int.Parse(secondProperty);
                    }

                    else if (legsCount == 1)
                    {
                        legsCount = 2;

                        SecondLeg.EnergyConsumption = energyConsumption;
                        SecondLeg.Strength = int.Parse(firstProperty);
                        SecondLeg.Speed = int.Parse(secondProperty);
                    }

                    else if (energyConsumption < FirstLeg.EnergyConsumption)
                    {
                        FirstLeg.EnergyConsumption = energyConsumption;
                        FirstLeg.Strength = int.Parse(firstProperty);
                        FirstLeg.Speed = int.Parse(secondProperty);
                    }

                    else if (energyConsumption < SecondLeg.EnergyConsumption)
                    {
                        SecondLeg.EnergyConsumption = energyConsumption;
                        SecondLeg.Strength = int.Parse(firstProperty);
                        SecondLeg.Speed = int.Parse(secondProperty);
                    }
                }

                else if (typeOfComponent == "Arm")
                {
                    if(armsCount == 0)
                    {
                        armsCount = 1;

                        FirstArm.EnergyConsumption = energyConsumption;
                        FirstArm.ArmReachDistance = int.Parse(firstProperty);
                        FirstArm.FingersCount = int.Parse(secondProperty);
                    }

                    else if (armsCount == 1)
                    {
                        armsCount = 2;

                        SecondArm.EnergyConsumption = energyConsumption;
                        SecondArm.ArmReachDistance = int.Parse(firstProperty);
                        SecondArm.FingersCount = int.Parse(secondProperty);
                    }

                    else if(energyConsumption < FirstArm.EnergyConsumption)
                    {
                        FirstArm.EnergyConsumption = energyConsumption;
                        FirstArm.ArmReachDistance = int.Parse(firstProperty);
                        FirstArm.FingersCount = int.Parse(secondProperty);
                    }

                    else if (energyConsumption < SecondArm.EnergyConsumption)
                    {
                        SecondArm.EnergyConsumption = energyConsumption;
                        SecondArm.ArmReachDistance = int.Parse(firstProperty);
                        SecondArm.FingersCount = int.Parse(secondProperty);
                    }                  
                }
                
                else if (typeOfComponent == "Head" && (headCounter == 0 || energyConsumption < Head.EnergyConsumption))
                {
                    headCounter = 1;

                    Head.EnergyConsumption = energyConsumption;
                    Head.IQ = int.Parse(firstProperty);
                    Head.SkinMaterial = secondProperty;
                }

                else if (typeOfComponent == "Torso" && (torsoCounter == 0 || energyConsumption < Torso.EnergyConsumption))
                {
                    torsoCounter = 1;

                    Torso.EnergyConsumption = energyConsumption;
                    Torso.ProcessorSize = decimal.Parse(firstProperty);
                    Torso.HousingMaterial = secondProperty;
                }

                data = Console.ReadLine();
            }

            if(!(armsCount == 2 && legsCount == 2 && headCounter == 1 && torsoCounter == 1))
            {
                Console.WriteLine("We need more parts!");
                return;
            }

            var neededPower = Torso.EnergyConsumption
                + Head.EnergyConsumption
                + FirstArm.EnergyConsumption
                + SecondArm.EnergyConsumption
                + FirstLeg.EnergyConsumption
                + SecondLeg.EnergyConsumption;

            if(neededPower > maximumEnergyCapacity)
            {
                Console.WriteLine("We need more power!");
            }

            else
            {
                PrintHead(Head);
                PrintTorso(Torso);
                    
                if (FirstArm.EnergyConsumption <= SecondArm.EnergyConsumption)
                {
                    PrintFirstArm(FirstArm);
                    PrintSecondArm(SecondArm);
                }

                else
                {
                    PrintSecondArm(SecondArm);
                    PrintFirstArm(FirstArm);
                }

                if (FirstLeg.EnergyConsumption <= SecondLeg.EnergyConsumption)
                {
                    PrintFirstLeg(FirstLeg);
                    PrintSecondLeg(SecondLeg);
                }

                else
                {
                    PrintSecondLeg(SecondLeg);
                    PrintFirstLeg(FirstLeg);
                }
            }
        }

        public static void PrintHead(Head Head)
        {
            Console.WriteLine("Jarvis:");
            Console.WriteLine("#Head:");
            Console.WriteLine($"###Energy consumption: {Head.EnergyConsumption}");
            Console.WriteLine($"###IQ: {Head.IQ}");
            Console.WriteLine($"###Skin material: {Head.SkinMaterial}");
        }

        public static void PrintTorso(Torso Torso)
        {
            Console.WriteLine("#Torso:");
            Console.WriteLine($"###Energy consumption: {Torso.EnergyConsumption}");
            Console.WriteLine($"###Processor size: {Torso.ProcessorSize:f1}");
            Console.WriteLine($"###Corpus material: {Torso.HousingMaterial}");
        }

        public static void PrintFirstArm(FirstArm FirstArm)
        {
            Console.WriteLine("#Arm:");
            Console.WriteLine($"###Energy consumption: {FirstArm.EnergyConsumption}");
            Console.WriteLine($"###Reach: {FirstArm.ArmReachDistance}");
            Console.WriteLine($"###Fingers: {FirstArm.FingersCount}");
        }

        public static void PrintSecondArm(SecondArm SecondArm)
        {
            Console.WriteLine("#Arm:");
            Console.WriteLine($"###Energy consumption: {SecondArm.EnergyConsumption}");
            Console.WriteLine($"###Reach: {SecondArm.ArmReachDistance}");
            Console.WriteLine($"###Fingers: {SecondArm.FingersCount}");
        }

        public static void PrintFirstLeg(FirstLeg FirstLeg)
        {
            Console.WriteLine("#Leg:");
            Console.WriteLine($"###Energy consumption: {FirstLeg.EnergyConsumption}");
            Console.WriteLine($"###Strength: {FirstLeg.Strength}");
            Console.WriteLine($"###Speed: {FirstLeg.Speed}");
        }

        public static void PrintSecondLeg(SecondLeg SecondLeg)
        {
            Console.WriteLine("#Leg:");
            Console.WriteLine($"###Energy consumption: {SecondLeg.EnergyConsumption}");
            Console.WriteLine($"###Strength: {SecondLeg.Strength}");
            Console.WriteLine($"###Speed: {SecondLeg.Speed}");
        }
    }
}