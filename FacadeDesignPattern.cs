/*The Facade defines a unified, higher level interface to a subsystem 
that makes it easier to use. Consumers encounter a Facade when ordering 
from a catalog. The consumer calls one number and speaks with a customer 
service representative. The customer service representative acts as a Facade, 
providing an interface to the order fulfillment department, the billing department, 
and the shipping department.
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_7
{

    // Subsystem components
    class Amplifier
    {
        public void On()
        {
            Console.WriteLine("Amplifier is turned on");
        }

        public void SetVolume(int volume)
        {
            Console.WriteLine($"Volume set to {volume}");
        }

        public void Off()
        {
            Console.WriteLine("Amplifier is turned off");
        }
    }

    class DVDPlayer
    {
        public void On()
        {
            Console.WriteLine("DVD Player is turned on");
        }

        public void Play(string movie)
        {
            Console.WriteLine($"Playing movie: {movie}");
        }

        public void Off()
        {
            Console.WriteLine("DVD Player is turned off");
        }
    }

    class Projector
    {
        public void On()
        {
            Console.WriteLine("Projector is turned on");
        }

        public void SetInput(DVDPlayer dvdPlayer)
        {
            Console.WriteLine("Setting DVD player as input to projector");
        }

        public void Off()
        {
            Console.WriteLine("Projector is turned off");
        }
    }

    // Facade for the Home Theater system
    class HomeTheaterFacade
    {
        private Amplifier amplifier;
        private DVDPlayer dvdPlayer;
        private Projector projector;

        public HomeTheaterFacade()
        {
            amplifier = new Amplifier();
            dvdPlayer = new DVDPlayer();
            projector = new Projector();
        }

        public void WatchMovie(string movie)
        {
            Console.WriteLine("Get ready to watch a movie...");
            amplifier.On();
            amplifier.SetVolume(10);

            dvdPlayer.On();
            dvdPlayer.Play(movie);

            projector.On();
            projector.SetInput(dvdPlayer);
        }

        public void EndMovie()
        {
            Console.WriteLine("Shutting down the Home Theater...");
            amplifier.Off();
            dvdPlayer.Off();
            projector.Off();
        }
    }

    // Subsystem components
    class CPU
    {
        public void Freeze()
        {
            Console.WriteLine("CPU: Freezing...");
        }

        public void Jump(long position)
        {
            Console.WriteLine($"CPU: Jumping to position {position}");
        }

        public void Execute()
        {
            Console.WriteLine("CPU: Executing...");
        }
    }

    class Memory
    {
        public void Load(long position, byte[] data)
        {
            Console.WriteLine($"Memory: Loading data to position {position}");
        }
    }

    class HardDrive
    {
        public byte[] Read(long lba, int size)
        {
            Console.WriteLine($"Hard Drive: Reading data at LBA {lba}, Size: {size}");
            return new byte[size];
        }
    }

    // Facade for computer boot process
    class ComputerBootFacade
    {
        private CPU cpu;
        private Memory memory;
        private HardDrive hardDrive;

        public ComputerBootFacade()
        {
            cpu = new CPU();
            memory = new Memory();
            hardDrive = new HardDrive();
        }

        public void Start()
        {
            Console.WriteLine("Starting computer boot process...");
            byte[] bootSector = hardDrive.Read(0, 512);
            memory.Load(0, bootSector);
            cpu.Freeze();
            cpu.Jump(0);
            cpu.Execute();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---------------------------------EXAMPLE 1---------------------------------");
            // Using the Home Theater Facade
            HomeTheaterFacade homeTheater = new HomeTheaterFacade();

            homeTheater.WatchMovie("Inception");
            Console.WriteLine("Enjoying the movie...");

            homeTheater.EndMovie();

            Console.WriteLine("---------------------------------EXAMPLE 2---------------------------------");
            // Using the Computer Boot Facade
            ComputerBootFacade computerBoot = new ComputerBootFacade();

            computerBoot.Start();
        }
    }

}

