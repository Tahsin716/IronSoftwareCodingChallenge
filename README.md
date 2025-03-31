## Overview

This project implements a parser for an old mobile phone keypad. Given an input string representing key presses, it converts them into corresponding characters based on classic T9-style input.

The project includes dependency injection using Ninject, unit tests using xUnit, and follows clean code principles.

This project was developed as a coding challenge for **IronSoftware**.


##  Repository Structure

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


## Solution

- At first, we will keep the digit-to-letter mapping inside a Dictionary
   - A dictionary (`_keypadMap`) stores the mapping of numeric keys to letters:
     ```csharp
     {'1', "&'("}, {'2', "ABC"}, {'3', "DEF"},
     {'4', "GHI"}, {'5', "JKL"}, {'6', "MNO"},
     {'7', "PQRS"}, {'8', "TUV"}, {'9', "WXYZ"},
     {'0', " "}
     ```
     
- We initialize an empty StringBuilder `result` to store the result.

- We iterate through the input string, we use two variables `currentChar` for holding the current character and `count` to keep count of the number of times current character is repeated.

- If a key is pressed multiple times in a row, the correct character is selected cyclically:
     ```csharp
        int index = (count - 1) % letters.Length;
        return letters[index].ToString();
     ```
- If a `*` (backspace) is encountered, we remove the last character from the result.
  
- If a `#` is encountered, we finalize processing and return the result.

## Test Coverage

### 1. Sample Test Cases

- **Input:** `33#` → **Output:** `E`
- **Input:** `227*#` → **Output:** `B`
- **Input:** `4433555 555666#` → **Output:** `HELLO`
- **Input:** `8 88777444666*664#` → **Output:** `TURING`

### 2. Handling Empty Input

- **Input:** `#` → **Output:** `""` (Empty string)

### 3. Ignoring Characters After `#`

- **Input:** `22#33445` → **Output:** `B`

### 4. Single Key Press

- **Input:** `2#` → **Output:** `A`
- **Input:** `5#` → **Output:** `J`
- **Input:** `9#` → **Output:** `W`

### 5. Multi-Key Press Handling

- **Input:** `22#` → **Output:** `B`
- **Input:** `33#` → **Output:** `E`
- **Input:** `88#` → **Output:** `U`

### 6. Circular Key Press Handling

- **Input:** `22222#` → **Output:** `B`
- **Input:** `77777#` → **Output:** `P`

### 7. Handling Backspace (`*`)

- **Input:** `22***2225#` → **Output:** `CJ`
- **Input:** `22 2225**#` → **Output:** `B`
- **Input:** `***#` → **Output:** `""` 

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

