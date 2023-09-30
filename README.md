# DroneTripsPlanner
Small Console application that finds the best load distribution for a Squad of Delivery Drones

**Tech Stack**
 - .NET Core 7.0
 - NUnit
 
**Walk Through**

This solution takes a specified List of Drones and Drop points from a plain text (input.txt) file, once the information is taken from the input file, the Application order the Drop points by Ascending and start to identify which of the Drones have enough capacity to carry the package. Once all data is processed, the application generates a plain text file (output.txt) with the distribution. If an exception is thrown during the life cycle of the app, it will be shown in the console, and the execution is aborted.

**Input File Format**

    [DroneA], [200], [DroneB], [250], [DroneC], [100]
    [LocationA], [200]
    [LocationB], [150]
    [LocationC], [50]

>Ensure that the input file follows the specified format, only a maximum of 100 drones are allowed. otherwise, an exception will be thrown.

**Requirements:**

 1. Visual Studio 2022
 2. .NET 7 SDK
 
 **How to Use:**
 
1. Open the Solution File with Visual Studio 2022
2. Put the output file in the bin folder of the solution. (\<root folder>\DroneTripPlanner\bin\Debug\net7.0 if the Project is in Debug Mode)
3. Start debugging or executing the Console App generated in the bin folder.
4. If the application runs successfully the output file will be generated in the bin folder, otherwise, any error will be displayed in the console.

**Time Spent:** About Six hours

**Note:** Since this application has been created using .NET Core, it could be executed on Win/Linux/MacOS