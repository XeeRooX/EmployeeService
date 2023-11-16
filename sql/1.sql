select p."Firstname", p."Lastname" , p."Surname", p."DateOfBirth" , d."Name" ,
e."DateOfEmployment" , e."TariffRate" * pos."SurplusFactor" as "Salary" 
from "People" p, "Departments" d , "Employees" e , "Positions" pos
where p."Id" = e."PersonId" and e."DepartmentId" = d."Id" and e."PositionId" = pos."Id"