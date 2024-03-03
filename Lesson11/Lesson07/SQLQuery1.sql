select s.*, c.*
from customer c
inner join sale s on c.id = s.customerId
order by c.id;