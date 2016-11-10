using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237inclass5
{
    class Program
    {
        static void Main(string[] args)
        {
                // Make a new instance of the entities class:
            CarsAMahlerEntities carsEntities = new CarsAMahlerEntities();

                // ********************************************************************************************
                // List all the cars in the table:
            Console.WriteLine("Print the list");
            Console.WriteLine();
            foreach (Car car in carsEntities.Cars)
            {
                Console.WriteLine(car.id + " " + car.make + " " + car.model);
            }

                // ********************************************************************************************
                // Find a specific car by the primary key:
            Car foundCar = carsEntities.Cars.Find("V0LCD1814");

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Print out a found car using the Find method");
            Console.WriteLine();
            Console.WriteLine(foundCar.id + " " + foundCar.make + " " + foundCar.model);
            Console.WriteLine();

                // ********************************************************************************************
                // Find a specific car by any property:
                // Call the Where method on the table Cars and pass in a lambda expression
                // for the criteria we're looking for. This loops through the DB and runs 
                // the expression against each of them - when true, it returns that car.
                // SQL equivalent:      Select * From Cars Where id = "V0LCD1814" Limit 1
            Car carToFind = carsEntities.Cars.Where(car => car.id == "V0LCD1814").First();
            Console.WriteLine("Find a car by ID");
            Console.WriteLine();
            Console.WriteLine(carToFind.id + " " + carToFind.make + " " + carToFind.model);
            Console.WriteLine();

                // To find multiple objects by a shared property and save as a list:
            List<Car> foundCars = carsEntities.Cars.Where(car => car.cylinders == 8).ToList<Car>();
                // To output each car in the list:
            Console.WriteLine();
            Console.WriteLine("To find all cars in the list that have 8 cylinders");
            Console.WriteLine();
            foreach (Car car in foundCars)
            {
                Console.WriteLine(car.id + " " + car.make + " " + car.model);
            }
            Console.WriteLine();



        }
    }
}
