public class Solution {
    public IList<bool> CheckIfPrerequisite(int numCourses, int[][] prerequisites, int[][] queries) {
        // step 1: build adjacency matrix to track direct prerequisites
        // if isPrereq[i][j] = true, that means i is a prerequisite of j
        bool[,] isPrereq = new bool[numCourses, numCourses];

        // step 2: mark all direct prerequisites
        foreach (int[] prereq in prerequisites) {
            int from = prereq[0];   // prerequisite course
            int to = prereq[1];     // dependent course
            isPrereq[from, to] = true;
        }

        // step 3: floyd-warshall algo to find all transitive prerequisites
        // if i is prereq of k, and k is prereq of j, then i is prereq of j
        for (int k = 0; k < numCourses; k++) {
            for (int i = 0; i < numCourses; i++) {
                for (int j = 0; j < numCourses; j++) {
                    if (isPrereq[i, k] && isPrereq[k, j])
                        isPrereq[i, j] = true;
                }
            }
        }

        // step 4: answer queries in O(1) time using precomputed matrix
        List<bool> result = new List<bool>();

        foreach (int[] query in queries) {
            int u = query[0];
            int v = query[1];
            result.Add(isPrereq[u, v]);
        }

        return result;
    }
}

// Time: O(n^3 + q), where n = numCourses, q = number of queries
// Space: O(n^2), for the adjacency matrix isPrereq