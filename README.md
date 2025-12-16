# F# Pascal's Triangle Implementation

Assignment exploring two different approaches to calculating binomial coefficients in F#: functional recursion and imperative mutation.

## Overview

This project implements a module for computing entries in Pascal's Triangle ($n$ choose $k$).
It contrasts a standard recursive functional approach (using pattern matching) with an imperative approach (using mutable arrays and loops).
The project is structured with a source file (`.fs`), a signature file (`.fsi`) to define the public API, and a script for testing (`.fsx`).

## Features

- **Recursive Implementation:** Calculates coefficients using standard recursion and pattern matching.
- **Imperative Implementation:** Calculates coefficients using mutable 2D arrays and `while` loops.
- **Safety Guards:** Includes limit checks ($n > 1000$) to prevent stack overflow or excessive memory usage.
- **Property Verification:** Helper functions to verify mathematical properties like Pascal's Identity: $C(n,k) = C(n-1, k-1) + C(n-1, k)$.
- **Strict Encapsulation:** Uses a signature file (`.fsi`) to strictly define input/output types and document the module.

## How to Run

You can run the test script directly using F# Interactive. This will load the module and execute the property tests:

```bash
dotnet fsi PascalTest.fsx
