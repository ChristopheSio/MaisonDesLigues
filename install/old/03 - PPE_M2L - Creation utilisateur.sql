use master;
CREATE LOGIN mdl1 WITH PASSWORD = 'mdl1';
USE PPE_M2L; 
CREATE USER mdl1 FOR LOGIN md1l;
use master;
CREATE LOGIN employemdl1 WITH PASSWORD = 'employemdl1';
USE PPE_M2L; 
CREATE USER employemdl1 FOR LOGIN employemd1l;
use master;
CREATE LOGIN benevolemdl1 WITH PASSWORD = 'benevolemdl1';
USE PPE_M2L; 
CREATE USER benevolemdl1 FOR LOGIN benevolemd1l;
grant execute to employemdl1;
go
grant excecute to benevolemdl1;
go

