public class Solution {
    public IList<IList<string>> AccountsMerge(IList<IList<string>> accounts) {
        // Base case: empty accounts
        if (accounts == null || accounts.Count == 0)
            return new List<IList<string>>();
        
        // Hash table: email -> representative email
        var emailToRep = new Dictionary<string, string>();
        // Hash table: email -> owner's name
        var emailToName = new Dictionary<string, string>();
        
        // Step 1: Process each account and build connections between emails
        foreach (var account in accounts) {
            string name = account[0];
            
            // Process all emails in this account
            for (int i = 1; i < account.Count; i++) {
                string email = account[i];

                // Store the owner's name for this email
                emailToName[email] = name;
                
                // Initialize: each email starts as its own representative
                if (!emailToRep.ContainsKey(email))
                    emailToRep[email] = email;
                
                // Connect current email with the first email of this account
                if (i > 1) {
                    // Use first email as representative
                    string firstEmail = account[1];

                    // Find the ultimate representative for both emails
                    // This handles cases where emails are already connected to other groups
                    string root1 = Find(emailToRep, firstEmail);
                    string root2 = Find(emailToRep, email);
                    
                    // Connect to two groups by making one representative point to the other
                    if (root1 != root2)
                        emailToRep[root2] = root1;
                }
            }
        }
        
        // Step 2: Group emails by their ultimate representative
        var groups = new Dictionary<string, List<string>>();
        
        foreach (var email in emailToName.Keys) {
            // Find the ultimate representative for this email
            // An email might point to another email, which points to another, etc.
            // We need to follow the chain to find the final representative
            string root = Find(emailToRep, email);
            
            // Create a list for this representative if it doesn't exist
            if (!groups.ContainsKey(root))
                groups[root] = new List<string>();
            
            // Add this email to its representative's group
            groups[root].Add(email);
        }
        
        // Step 3: Build result with sorted emails
        var result = new List<IList<string>>();
        
        foreach (var group in groups.Values) {
            // Sort emails lexicographically using ordinal (ASCII) comparison. This ensures consistent ordering
            group.Sort(StringComparer.Ordinal);
            
            // Build merged accounts: [name, email1, email2, ...]
            List<string> mergedAccount = new List<string>();
            mergedAccount.Add(emailToName[group[0]]);           // Add owner's name first
            mergedAccount.AddRange(group);                      // Add all sorted emails
            
            result.Add(mergedAccount);
        }
        
        return result;
    }
    
    // Find the ultimate representative for an email by following the chain
    // Also optimizes the chain by making emails point directly to the ultimate representative
    private string Find(Dictionary<string, string> parent, string email) {
        // If this email points to another email (not itself), keep following the chain
        if (parent[email] != email) {
            // Optimization: update this email to point directly to the ultimate representative
            // This makes future lookups faster (flattens the chain)
            parent[email] = Find(parent, parent[email]);
        }

        // Return the ultimate representative
        return parent[email];
    }
}

/*
Interview Approach Explanation
Problem Understanding: We need to merge accounts that belong to the same person. Two accounts belong to the same person if they share at least one common email address.

Key Insight: This is a grouping/clustering problem that can be solved using hash tables:
    - Each email needs to be connected to other emails from the same person
    - We can use a "representative email" concept - one email that represents a group
    - All emails pointing to the same representative belong to the same person
    - When we find emails in the same account, we connect them through representatives

Approach - Representative-Based Grouping:

1. Build mappings: Create two hash tables
    - emailToRep: Maps each email to a representative email (the "leader" of its group)
    - emailToName: Maps each email to the account owner's name

2. Connect emails: For each account, connect all emails together
    - Pick the first email as the representative for that account
    - Make all other emails in the account point to this representative
    - If emails already have representatives, connect those representatives too

3. Group by representative: Collect all emails that share the same representative
    - Format result: Sort emails lexicographically and format as [name, email1, email2, ...]

Base Cases:
    - Empty accounts list → return empty list
    - Single account → return that account

Edge Cases:
    - Multiple accounts with same name but no common emails → separate people
    - Transitive relationships: A-B in account1, B-C in account2 → A,B,C all belong together
    - Single email in account → that email is its own representative
    - All accounts merge into one person

Algorithmic Steps:
1. Initialize two hash tables: emailToRep and emailToName
2. For each account:
    - Store the name for all emails
    - Initialize each email to point to itself as representative (if not seen before)
    - Connect all emails to the first email of the account
3. Group emails by their ultimate representative using Find()
4. For each group:
    - Sort emails using ordinal (ASCII-based) comparison
    - Create merged account: [name, sorted emails]
5. Return all merged accounts

--------------------------------
Time Complexity: O(N * K * log(N*K))
    - N = number of accounts
    - K = maximum number of emails per account

Breakdown:
1. Building representative mappings: O(N * K)
    - Process N accounts with K emails each: O(N * K)
    - Each Find operation is nearly constant due to path flattening
2. Grouping emails: O(N * K)
    - One Find operation per email
    - Find is very fast due to optimization
3. Sorting emails: O(N * K * log(N*K))
    - Total emails across all groups: N * K
    - Sorting dominates the time complexity

Overall: O(N * K * log(N*K))

/////////////////////////////////////////////

Space Complexity: O(N * K)
    - emailToRep dictionary: O(N * K) - one entry per unique email
    - emailToName dictionary: O(N * K) - one entry per unique email
    - groups dictionary: O(N * K) - stores all emails
    - result list: O(N * K) - final output
    - Recursion stack for Find(): O(log(N*K)) in optimized case

Overall: O(N * K)
*/