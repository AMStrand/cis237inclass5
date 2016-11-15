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
            Console.WriteLine("Print the full database list of cars");
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
            Console.WriteLine("Print out a specific car using the Find method");
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
            Console.WriteLine("Find a car by ID using the Where method");
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

                // ********************************************************************************************
                // Add a new car to the database:

                // Make an instance of a new Car:
            Car newCarToAdd = new Car();
                // Add properties to the new car:
            newCarToAdd.id = "88888";
            newCarToAdd.make = "Nissan";
            newCarToAdd.model = "GT-R";
            newCarToAdd.horsepower = 550;
            newCarToAdd.cylinders = 8;
            newCarToAdd.year = "2016";
            newCarToAdd.type = "";

            try
            {
                    // Add the new car to the cars collection:
                carsEntities.Cars.Add(newCarToAdd);

                    // Persist the collection to the database:
                carsEntities.SaveChanges();
            }
            catch (Exception ex)
            {
                    // Remove the new car from the collection since we can't save it:
                carsEntities.Cars.Remove(newCarToAdd);
                    // Output error to user:
                Console.WriteLine("The record cannot be added: " + ex.Message);
            }
            
            Console.WriteLine();
            Console.WriteLine("Just added a new car.  Going to fetch and print to verify.");

            carToFind = carsEntities.Cars.Find("88888");
            Console.WriteLine(carToFind.id + " " + carToFind.make + " " + carToFind.model);

            Console.WriteLine();

                // ********************************************************************************************
                // Update a record:

                // Get the car to update:
            Car carToFindForUpdate = carsEntities.Cars.Find("88888");

            Console.WriteLine();
            Console.WriteLine("Update car #88888:");

                // Update some of the properties:
            carToFindForUpdate.make = "Nisssssssssan";
            carToFindForUpdate.model = "GT-RRRRR";

            Console.WriteLine("88888 Nissan GT-R is now " + carToFindForUpdate.id + " " + carToFindForUpdate.make + " " + carToFindForUpdate.model);
            Console.WriteLine();

                // Save the changes to the database:
            carsEntities.SaveChanges();

                // ********************************************************************************************
                // Delete a car from the database:

                // Get a car out of the database that we would like to delete:
            Car carToFindForDelete = carsEntities.Cars.Find("88888");

                // Remove the car from the collection:
            carsEntities.Cars.Remove(carToFindForDelete);

                // Save the changes to the database:
            carsEntities.SaveChanges();

            Console.WriteLine("We deleted that car.  Check to see the car was deleted:");
            Console.WriteLine();

                // Check to see if the car was deleted:
            try
            {
                carToFindForDelete = carsEntities.Cars.Find("88888");
                Console.WriteLine(carToFindForDelete.id + " " + carToFindForDelete.make + " " + carToFindForDelete.model);
            }
            catch (Exception ex)
            {
                Console.WriteLine("That vehicle does not exist: " + ex.Message);
            }

           

        }
    }
}
