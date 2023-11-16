delete from "People" p
where (extract('Year' from current_date) - extract( 'Year' from p."DateOfBirth")) > 70