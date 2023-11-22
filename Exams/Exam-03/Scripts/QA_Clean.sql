-- Clean ReportedCards
DELETE FROM `creditbankdb`.`ReportedCards` WHERE Id >= 0;
ALTER TABLE `creditbankdb`.`ReportedCards` AUTO_INCREMENT = 1;
TRUNCATE TABLE `creditbankdb`.`ReportedCards`;

-- Insert ReportedCards
INSERT INTO ReportedCards (IssuingNetwork, CreditCardNumber, FirstName, LastName, StatusCard, ReportedDate, LastUpdatedDate) VALUES ('visa', '4024007124607606', 'Van Arsdalen', 'Mougeot', 'Recovered', '2021-07-27', '2021-07-29');
INSERT INTO ReportedCards (IssuingNetwork, CreditCardNumber, FirstName, LastName, StatusCard, ReportedDate, LastUpdatedDate) VALUES ('visa', '4485989469084883', 'Natt', 'Gellier', 'Stolen', '2022-01-06', '2022-01-06');
INSERT INTO ReportedCards (IssuingNetwork, CreditCardNumber, FirstName, LastName, StatusCard, ReportedDate, LastUpdatedDate) VALUES ('visa', '4716752774463791', 'Windybank', 'Matteo', 'Stolen', '2021-05-22', '2021-05-22');
INSERT INTO ReportedCards (IssuingNetwork, CreditCardNumber, FirstName, LastName, StatusCard, ReportedDate, LastUpdatedDate) VALUES ('visa', '4916898478434022', 'Heinicke', 'Parlot', 'Recovered', '2021-08-29', '2021-09-05');
INSERT INTO ReportedCards (IssuingNetwork, CreditCardNumber, FirstName, LastName, StatusCard, ReportedDate, LastUpdatedDate) VALUES ('mastercard', '5208437569456141', 'Martinson', 'Stanbridge', 'Stolen', '2021-04-29', '2021-04-29');
INSERT INTO ReportedCards (IssuingNetwork, CreditCardNumber, FirstName, LastName, StatusCard, ReportedDate, LastUpdatedDate) VALUES ('mastercard', '5186213093595662', 'Shervil', 'Kingsland', 'Stolen', '2022-01-28', '2022-01-28');
INSERT INTO ReportedCards (IssuingNetwork, CreditCardNumber, FirstName, LastName, StatusCard, ReportedDate, LastUpdatedDate) VALUES ('mastercard', '5268315740743370', 'Danson', 'O''Meara', 'Recovered', '2021-12-30', '2021-01-04');
INSERT INTO ReportedCards (IssuingNetwork, CreditCardNumber, FirstName, LastName, StatusCard, ReportedDate, LastUpdatedDate) VALUES ('americanexpress', '375798369127705', 'Hazelhurst', 'oldey', 'Stolen', '2021-03-26', '2021-03-26');
INSERT INTO ReportedCards (IssuingNetwork, CreditCardNumber, FirstName, LastName, StatusCard, ReportedDate, LastUpdatedDate) VALUES ('americanexpress', '378477541453522', 'Gilley', 'Bordis', 'Stolen', '2021-10-25', '2021-10-25');
INSERT INTO ReportedCards (IssuingNetwork, CreditCardNumber, FirstName, LastName, StatusCard, ReportedDate, LastUpdatedDate) VALUES ('americanexpress', '378511194973723', 'Burn', 'Loughren', 'Stolen', '2021-05-04', '2021-05-04');
