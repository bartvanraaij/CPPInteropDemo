# CPPInteropDemo

## Overview
CPPInteropDemo is a Proof of Concept (PoC) demonstrating interoperability between C# (.NET) and native C++ code. The project shows how to call C++ functions from a C# application using Platform Invocation Services (P/Invoke) and a native DLL built with CMake.

## Features
- C++ functions (`Add`, `Multiply`) are implemented in a native DLL.
- C# application calls these functions via P/Invoke.
- Automated build process for the C++ DLL using CMake, integrated into the .NET build.

## Prerequisites
To build and run this project, you need:

- **.NET SDK 9.0 or later**
  - [Download .NET SDK](https://dotnet.microsoft.com/download)
- **CMake** (for building the C++ DLL)
  - [Download CMake](https://cmake.org/download/)
- **C++ Compiler**
  - On Windows: Visual Studio with C++ Desktop Development workload, or Build Tools for Visual Studio
  - On Linux/macOS: GCC or Clang
- **Git** (optional, for cloning the repository)

## Building and Running
1. **Clone the repository** (if you haven't already):
   ```sh
   git clone <repo-url>
   cd CPPInteropDemo
   ```

2. **Build the project**
   ```sh
   dotnet build
   ```
   This will automatically build the C++ DLL using CMake and copy it to the output directory.

3. **Run the application**
   ```sh
   dotnet run
   ```

## How the C++ and C# Interop Works

1. **C++ Source Files**: All native C++ code is located in the `cpp/` directory.

2. **CMake Build Integration**: The .NET project file (`CPPInteropDemo.csproj`) is configured to automatically invoke CMake before building the C# project. This is handled by the `BuildCppDll` target, which:
   - Runs CMake to configure the build, using the `CMakeLists.txt` file in the `cpp/` directory to generate the necessary build files in the `build/cpp` directory.
   - Then calls CMake again to build the C++ code in Release mode, producing the DLL (e.g., `AgxCpp.dll`) in `build/cpp/Release/`.

3. **Copying the DLL**: After building, the `CopyCppDlls` target copies the generated DLL(s) from the C++ build output directory into the .NET output directory (e.g., `bin/Debug/net9.0/`).

4. **Loading the DLL in C#**: The C# code (in `Program.cs`) uses the `[DllImport]` attribute to declare external functions implemented in the C++ DLL. At runtime, .NET loads the native DLL and allows the managed code to call these native functions as if they were regular C# methods.

This automated process ensures that any changes to the C++ code are rebuilt and made available to the C# application without manual steps.

## Project Structure
- `cpp/` - C++ source code and CMakeLists.txt
- `build/cpp/` - CMake build output (generated)
- `Program.cs` - C# application entry point
- `CPPInteropDemo.csproj` - .NET project file with CMake integration

## Notes
- The C++ DLL is named `AgxCpp.dll` and is built automatically as part of the .NET build process.
- If you encounter build issues, ensure your C++ compiler and CMake are correctly installed and available in your system PATH.

## License
This project is for demonstration purposes only.
