select	p.*, a.Name
from	Pilot p inner join
		Airport a on a.Oid = p.Airport
where	a.Name = 'Domodedovo'