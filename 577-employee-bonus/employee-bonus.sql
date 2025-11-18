# Write your MySQL query statement below
select e.name, b.bonus
from employee e
left join bonus b on e.empid = b.empid
where b.bonus IS NULL OR b.bonus < 1000;