// PascalTest.fsx
#load "Pascal.fs"
open Pascal

let mutable failures = 0

// Test a few known results
printfn "Testing known results:"

let mutable n = 0
let mutable k = 0

// 5 choose 2 = 10
if pascal(5,2) <> 10 then
    printfn "pascal (5,2) failed"
    failures <- failures + 1
else
    printfn "pascal (5,2) OK"

if pascalNoRec(5,2) <> 10 then
    printfn "pascalNoRec (5,2) failed"
    failures <- failures + 1
else
    printfn "pascalNoRec (5,2) OK"

// Property 1: C(n,0) = 1 and C(n,n) = 1
printfn ""
printfn "Checking Property 1:"
n <- 0
while n <= 10 do
    if pascal(n,0) <> 1 || pascal(n,n) <> 1 then
        printfn "Property 1 failed for pascal at n=%d" n
        failures <- failures + 1

    if pascalNoRec(n,0) <> 1 || pascalNoRec(n,n) <> 1 then
        printfn "Property 1 failed for pascalNoRec at n=%d" n
        failures <- failures + 1

    n <- n + 1

// Property 2: C(n,k) = C(n-1,k-1) + C(n-1,k)
printfn ""
printfn "Checking Property 2:"
n <- 1
while n <= 10 do
    k <- 1
    while k < n do
        let a = pascal(n, k)
        let b = pascal(n-1, k-1) + pascal(n-1, k)
        if a <> b then
            printfn "Property 2 failed for pascal at n=%d k=%d" n k
            failures <- failures + 1

        let a2 = pascalNoRec(n, k)
        let b2 = pascalNoRec(n-1, k-1) + pascalNoRec(n-1, k)
        if a2 <> b2 then
            printfn "Property 2 failed for pascalNoRec at n=%d k=%d" n k
            failures <- failures + 1

        k <- k + 1
    n <- n + 1

// Final summary
printfn ""
if failures = 0 then
    printfn "All tests passed"
else
    printfn "%d test(s) failed." failures
