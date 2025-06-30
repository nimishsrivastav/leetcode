class Solution:
    def displayTable(self, orders: List[List[str]]) -> List[List[str]]:
        # Step 1: Use sets to collect unique food items and table numbers
        food_items = set()
        table_numbers = set()
        
        # Step 2: Use dictionary to count orders for each (table, food) pair
        order_count = {}

        # Step 3: Process each order to extract information
        for order in orders:
            customer_name = order[0]
            table_num = order[1]
            food_item = order[2]

            # Add to the collectins
            table_numbers.add(int(table_num))               # Convert to int for proper sorting
            food_items.add(food_item)

            # Count the order
            key = (table_num, food_item)
            order_count[key] = order_count.get(key, 0) + 1

        # Step 4: Sort food items aplhabetically and table numbers numerically
        sorted_foods = sorted(food_items)
        sorted_tables = sorted(table_numbers)

        # Step 5: Build the result table
        result = []

        # Create the header row: ["Table"] + sorted food items
        header = ["Table"] + sorted_foods
        result.append(header)

        # Step 6: Create data rows for each table
        for table_num in sorted_tables:
            row = [str(table_num)]                          # First column is table number as string

            # For each food item, add the count (or "0" if no orders)
            for food in sorted_foods:
                count = order_count.get((str(table_num), food), 0)
                row.append(str(count))                      # Convert count to string

            result.append(row)

        return result

"""
Algorithmic Steps:
    1. Extract all unique food items and sort them alphabetically
    2. Extract all unique table numbers and sort them numerically
    3. Count occurrences of each (table, food) combination
    4. Build the result table with header row and data rows
    
Time Complexity: O(N + F*log(F) + T*log(T) + T*F)
    where N = number of orders, F = number of unique food items, T = number of unique tables
    - O(N) to process all orders
    - O(F*log(F)) to sort food items
    - O(T*log(T)) to sort table numbers
    - O(T*F) to build the final result table
    
Space Complexity: O(N + F + T)
    - O(N) for the count dictionary (worst case: all orders are unique)
    - O(F) for storing unique food items
    - O(T) for storing unique table numbers
"""