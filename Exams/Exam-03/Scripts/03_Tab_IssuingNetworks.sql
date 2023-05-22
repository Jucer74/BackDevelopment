CREATE TABLE `netbankdb`.`issuingnetworks` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(50) NOT NULL,
  `StartsWithNumbers`  VARCHAR(50) NULL,
  `InRange` VARCHAR(50) NULL,
  `AllowedLengths` VARCHAR(50) NOT NULL,
  PRIMARY KEY (`Id`));
  