# Old Phone Parser

## Overview
This project implements a parser for an old mobile phone keypad. Given an input string representing key presses, it converts them into corresponding characters based on classic T9-style input.

This project was developed as a coding challenge for **IronSoftware**.

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
To test the `OldPhoneParser` functionality, you can create a console app and call:
```csharp
using System;

class Program
{
    static void Main()
    {
        string input = "222 7777 33";
        string result = PhoneParser.OldPhoneParser.OldPhonePad(input);
        Console.WriteLine(result); // Expected Output: "CPD"
    }
}
```

## Running Tests
This project includes unit tests using **xUnit**. To run the tests, navigate to the test project directory and execute:
```sh
dotnet test
```
This will execute all test cases and display the results in the terminal.

