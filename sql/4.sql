update "Employees" 
set "TariffRate" = 15000 / lowSalary."SurplusFactor"
from (select e."Id" , p."SurplusFactor" from "Employees" e , "Positions" p 
where e."PositionId" = p."Id" and 
e."TariffRate" * p."SurplusFactor" < 15000 ) as lowSalary
where "Employees"."Id" = lowSalary."Id"