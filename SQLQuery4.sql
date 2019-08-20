select	p.*
from	Plane p inner join
		PlanePlanes_PilotPilots pp on pp.Planes = p.Oid inner join
		Pilot pil on pil.Oid = pp.Pilots
where	pil.Name = 'Kojedub'