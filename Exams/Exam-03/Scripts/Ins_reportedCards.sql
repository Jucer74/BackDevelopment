DELETE FROM ReportedCards;
VACUUM;

SELECT * FROM `sqlite_sequence`;
UPDATE `sqlite_sequence` SET `seq` = 0 WHERE `name` = 'ReportedCards';

INSERT INTO ReportedCards (IssuingNetwork, CreditCardNumber, FirstName, LastName, StatusCard, ReportedDate, LastUpdatedDate) 
VALUES ('visa', '4024007124607606', 'Van Arsdalen', 'Mougeot', 'Recovered', '07/27/2021', '07/29/2021');
INSERT INTO ReportedCards (IssuingNetwork, CreditCardNumber, FirstName, LastName, StatusCard, ReportedDate, LastUpdatedDate) 
VALUES ('visa', '4485989469084883', 'Natt', 'Gellier', 'Stolen', '01/06/2022', '01/06/2022');
INSERT INTO ReportedCards (IssuingNetwork, CreditCardNumber, FirstName, LastName, StatusCard, ReportedDate, LastUpdatedDate) 
VALUES ('visa', '4716752774463791', 'Windybank', 'Matteo', 'Stolen', '05/22/2021', '05/22/2021');
INSERT INTO ReportedCards (IssuingNetwork, CreditCardNumber, FirstName, LastName, StatusCard, ReportedDate, LastUpdatedDate) 
VALUES ('visa', '4916898478434022', 'Heinicke', 'Parlot', 'Recovered', '08/29/2021', '09/05/2021');
INSERT INTO ReportedCards (IssuingNetwork, CreditCardNumber, FirstName, LastName, StatusCard, ReportedDate, LastUpdatedDate) 
VALUES ('mastercard', '5208437569456141', 'Martinson', 'Stanbridge', 'Stolen', '04/29/2021', '04/29/2021');
INSERT INTO ReportedCards (IssuingNetwork, CreditCardNumber, FirstName, LastName, StatusCard, ReportedDate, LastUpdatedDate) 
VALUES ('mastercard', '5186213093595662', 'Shervil', 'Kingsland', 'Stolen', '01/28/2022', '01/28/2022');
INSERT INTO ReportedCards (IssuingNetwork, CreditCardNumber, FirstName, LastName, StatusCard, ReportedDate, LastUpdatedDate) 
VALUES ('mastercard', '5268315740743370', 'Danson', 'O''Meara', 'Recovered', '12/30/2021', '01/04/2022');
INSERT INTO ReportedCards (IssuingNetwork, CreditCardNumber, FirstName, LastName, StatusCard, ReportedDate, LastUpdatedDate) 
VALUES ('americanexpress', '375798369127705', 'Hazelhurst', 'oldey', 'Stolen', '03/26/2021', '03/26/2021');
INSERT INTO ReportedCards (IssuingNetwork, CreditCardNumber, FirstName, LastName, StatusCard, ReportedDate, LastUpdatedDate) 
VALUES ('americanexpress', '378477541453522', 'Gilley', 'Bordis', 'Stolen', '10/25/2021', '10/25/2021');
INSERT INTO ReportedCards (IssuingNetwork, CreditCardNumber, FirstName, LastName, StatusCard, ReportedDate, LastUpdatedDate) 
VALUES ('americanexpress', '378511194973723', 'Burn', 'Loughren', 'Stolen', '05/04/2021', '05/04/2021');







