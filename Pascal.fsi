// Pascal.fsi
module Pascal

// NOTE:
// These functions are defined for natural numbers n and k where 0 <= k <= n.
// For very large values of n, results may cause integer overflow or memory issues.
// The functions are therefore only reliable for reasonably small n (e.g., n < 1000).

// Takes a pair of natural numbers n and k, and returns the corresponding binomial coefficient for n choose k.
// pascal: int * int -> int
val pascal : (int * int) -> int

// Takes a pair of natural numbers n and k, and returns the corresponding binomial coefficient for n choose k.
// pascalNoRec: int * int -> int
val pascalNoRec : (int * int) -> int

// Property 1 test: Checks that C(n,0) = 1 and C(n,n) = 1 for valid n.
// Returns false if n is invalid.
val hasPropertyOne : (int * int) -> bool

// Same as hasPropertyOne, but uses the non-recursive Pascal implementation.
val hasPropertyOneNoRec : (int * int) -> bool

// Property 2 test: Checks that C(n,k) = C(n-1,k-1) + C(n-1,k) for 0 < k < n.
// Returns true for values where the property is not applicable.
val hasPropertyTwo : (int * int) -> bool

// Same as hasPropertyTwo, but uses the non-recursive Pascal implementation.
val hasPropertyTwoNoRec : (int * int) -> bool
