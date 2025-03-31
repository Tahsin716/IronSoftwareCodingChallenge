## Overview
This project implements a parser for an old mobile phone keypad. Given an input string representing key presses, it converts them into corresponding characters based on classic T9-style input.

The project includes dependency injection using Ninject, unit tests using xUnit, and follows clean code principles.

This project was developed as a coding challenge for **IronSoftware**.

## Repository Structure

The project uses Clean Code and SOLID principles for achieving separation of concerns. The files inside the PhoneParser, which is inside the  src folder, are structured as follows:

- `Contracts`: Contains the abstractions, such as interfaces.
   - `IOldPhoneParser.cs`: Defines the interface for the OldPhonePad method.
- `DI`: Contains the dependency injection files
   - `ServiceRegistration`: Handles dependency injection using Ninject and fetching services as well.
- `Services`: Contains the implementations of the services
   - `OldPhoneParser.cs`: Implements the IOldPhoneParser interface for converting old phone pad input to text.
- `Program.cs`: Example usage of the Old Phone Parser.

The test folder contains the PhoneParser.Test the xUnit project, which contains the following files:
- `OldPhoneParserTests`: Unit tests ensuring correctness and edge case handling.


## Requirements
- **.NET Core 8.0+** is required to run this project.
- A test framework (**xUnit**) is used for unit testing.

## Installation & Setup
1. Ensure you have **.NET Core 8.0+** installed on your system. You can check your installed version by running:
   ```sh
   dotnet --version
   ```
2. Clone the repository:
   ```sh
   git clone <repository_url>
   cd <repository_name>
   ```
3. Restore dependencies:
   ```sh
   dotnet restore
   ```

## Running the Application
To test the `OldPhoneParser` functionality, navigate to the src project directory and execute:
```sh
dotnet run
```

## Running Tests
This project includes unit tests using **xUnit**. To run the tests, navigate to the test project directory and execute:
```sh
dotnet test
```
This will execute all test cases and display the results in the terminal.

