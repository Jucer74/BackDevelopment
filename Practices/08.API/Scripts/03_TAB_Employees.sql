CREATE TABLE `employeesdb`.`employees` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `FirstName` VARCHAR(50) NOT NULL,
  `LastName` VARCHAR(50) NOT NULL,
  `HireDate` DATETIME NOT NULL,
  `Department` VARCHAR(10) NOT NULL,
  PRIMARY KEY (`Id`));
