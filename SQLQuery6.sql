select	a.Name, count(p.Oid) pilotCnt
from	Airport a left join
		Pilot p on p.Airport = a.Oid
group by a.Name
having count(p.Oid) > 10