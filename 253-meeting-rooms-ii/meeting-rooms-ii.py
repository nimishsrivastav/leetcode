class Solution:
    def minMeetingRooms(self, intervals: List[List[int]]) -> int:
        if not intervals:
            return 0

        # separate start and end times
        starts = sorted([interval[0] for interval in intervals])
        ends = sorted([interval[1] for interval in intervals])

        # pointers for start and end times
        s_ptr = 0               # pointer to next meeting start
        e_ptr = 0               # pointer to next meeting end

        used_rooms = 0          # currently used rooms
        max_rooms = 0           # track the maximum rooms used

        # iterate over all meetings by start time
        while s_ptr < len(intervals):
            # if the next meeting starts before the earliest end, need new room
            if starts[s_ptr] < ends[e_ptr]:
                used_rooms += 1             # use a new room
                s_ptr += 1
            else:
                # a meeting has ended, room becomes available
                used_rooms -= 1
                e_ptr += 1

            # update max rooms at every step
            max_rooms = max(max_rooms, used_rooms)

        return max_rooms

##### ALGORITHM #####
# 1. Extract all start times and end times from the intervals.
# 2. Sort both lists.
# 3. Use two pointers: one for start times, one for end times.
# 4. For each meeting:
#     - If the next meeting starts before the earliest ending meeting ends, need a new room.
#     - Else, reuse a room (move the end pointer).
# 5. Track the max number of rooms needed at any time.
#####################

# Time Complexity: O(n log n); Sorting the start and end arrays takes O(n log n). The pointers traverse the arrays in O(n).
# Space Complexity: O(n); Extra space for the start and end arrays.