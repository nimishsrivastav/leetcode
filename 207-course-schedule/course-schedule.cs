public class Solution {
    public bool CanFinish(int numCourses, int[][] prerequisites) {
        if (numCourses <= 1) return true;

        var graph = new List<int>[numCourses];
        int[] inDegree = new int[numCourses];

        for (int i = 0; i < numCourses; i++) {
            graph[i] = new List<int>();
        }

        foreach (int[] prereq in prerequisites) {
            int courses = prereq[0];
            int prerequisite = prereq[1];

            graph[prerequisite].Add(courses);
            inDegree[courses]++;
        }

        var queue = new Queue<int>();

        for (int i = 0; i < numCourses; i++) {
            if (inDegree[i] == 0) queue.Enqueue(i);
        }

        int processedCourses = 0;

        while (queue.Count > 0) {
            int currentCourse = queue.Dequeue();
            processedCourses++;

            foreach (int nextCourse in graph[currentCourse]) {
                inDegree[nextCourse]--;

                if (inDegree[nextCourse] == 0) queue.Enqueue(nextCourse);
            }
        }

        return processedCourses == numCourses;
    }
}