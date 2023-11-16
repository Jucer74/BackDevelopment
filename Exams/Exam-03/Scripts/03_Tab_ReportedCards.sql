CREATE TABLE `creditbankdb`.`ReportedCards` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `IssuingNetwork` VARCHAR(50) NOT NULL,
  `CreditCardNumber` VARCHAR(20) NOT NULL,
  `FirstName` VARCHAR(50) NOT NULL,
  `LastName` VARCHAR(50) NOT NULL,
  `StatusCard` VARCHAR(20) NOT NULL DEFAULT 'Stolen',
  `ReportedDate` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `LastUpdatedDate` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`Id`));