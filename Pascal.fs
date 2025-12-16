// Pascal.fs
module Pascal

// Recursive Pascal function: returns n choose k.
// Returns 0 when k < 0, k > n, or n is too large to compute safely.
let rec pascal (n:int, k:int) : int =
    match n, k with
    | _ when n < 0 || k < 0 || k > n -> 0
    | _ when n > 1000 -> 0 // Guard rail: prevent stack overflow for large n
    | _, 0 -> 1
    | m, r when m = r -> 1
    | _ -> pascal (n - 1, k - 1) + pascal (n - 1, k)

// Imperative version using a while loop
let pascalNoRec (n:int, k:int) : int =
    if n < 0 || k < 0 || k > n then 0
    elif n > 10000 then 0 // Guard rail: prevent excessive memory use
    else
        // Create a mutable 2D array to store the triangle
        let triangle = Array.init (n + 1) (fun _ -> Array.zeroCreate<int> (n + 1))

        // Initialize row index
        let mutable i = 0
        while i <= n do
            // Initialize column index
            let mutable j = 0
            while j <= i do
                if j = 0 || j = i then
                    triangle.[i].[j] <- 1
                else
                    triangle.[i].[j] <- triangle.[i - 1].[j - 1] + triangle.[i - 1].[j]
                j <- j + 1
            i <- i + 1

        // Return the requested coefficient
        triangle.[n].[k]

// Property 1: C(n,0) = 1 and C(n,n) = 1
let hasPropertyOne (n:int, _k:int) : bool =
    if n < 0 then false
    else pascal (n, 0) = 1 && pascal (n, n) = 1

let hasPropertyOneNoRec (n:int, _k:int) : bool =
    if n < 0 then false
    else pascalNoRec (n, 0) = 1 && pascalNoRec (n, n) = 1

// Property 2: C(n,k) = C(n-1,k-1) + C(n-1,k) for 0 < k < n
// If the property is not applicable (k <= 0 or k >= n or n <= 0) we return true.
let hasPropertyTwo (n:int, k:int) : bool =
    if n <= 0 || k <= 0 || k >= n then true
    else pascal (n, k) = pascal (n - 1, k - 1) + pascal (n - 1, k)

let hasPropertyTwoNoRec (n:int, k:int) : bool =
    if n <= 0 || k <= 0 || k >= n then true
    else pascalNoRec (n, k) = pascalNoRec (n - 1, k - 1) + pascalNoRec (n - 1, k)
