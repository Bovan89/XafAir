select	p.*
from	Plane p inner join
		Airport a on a.Oid = p.Airport
where	a.Name = 'Domodedovo'