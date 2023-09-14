CREATE TABLE `studentsdb`.`students` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `FirstName` VARCHAR(50) NOT NULL,
  `LastName` VARCHAR(50) NOT NULL,
  `DateOfBirth` DATETIME NOT NULL,
  `Sex` VARCHAR(1) NOT NULL,
  PRIMARY KEY (`Id`));
