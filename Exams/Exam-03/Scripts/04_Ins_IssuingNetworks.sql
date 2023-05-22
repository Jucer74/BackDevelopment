DELETE FROM `netbankdb`.`issuingnetworks` WHERE Id >= 0;
ALTER TABLE `netbankdb`.`issuingnetworks` AUTO_INCREMENT = 1;
INSERT INTO `netbankdb`.`issuingnetworks` (`Name`, `StartsWithNumbers`, `InRange`, `AllowedLengths`)
VALUES('American Express', '34,37', NULL, '15');
INSERT INTO `netbankdb`.`issuingnetworks` (`Name`, `StartsWithNumbers`, `InRange`, `AllowedLengths`)
VALUES('Diners Club', '300,301,302,303,304,305', NULL, '14');
INSERT INTO `netbankdb`.`issuingnetworks` (`Name`, `StartsWithNumbers`, `InRange`, `AllowedLengths`)
VALUES('Diners Club - International', '36', NULL, '14');
INSERT INTO `netbankdb`.`issuingnetworks` (`Name`, `StartsWithNumbers`, `InRange`, `AllowedLengths`)
VALUES('Discover','6011,644,645,646,647,648,649,65', '622126-622925', '16,17,18,19');
INSERT INTO `netbankdb`.`issuingnetworks` (`Name`, `StartsWithNumbers`, `InRange`, `AllowedLengths`)
VALUES('InstaPayment', '637,638,639', NULL, '16');
INSERT INTO `netbankdb`.`issuingnetworks` (`Name`, `StartsWithNumbers`, `InRange`, `AllowedLengths`)
VALUES('JCB', NULL, '3528-3589', '16,17,18,19');
INSERT INTO `netbankdb`.`issuingnetworks` (`Name`, `StartsWithNumbers`, `InRange`, `AllowedLengths`)
VALUES('Maestro', '5018,5020,5038,5893,6304,6759,6761,6762,6763', NULL, '16,17,18,19');
INSERT INTO `netbankdb`.`issuingnetworks` (`Name`, `StartsWithNumbers`, `InRange`, `AllowedLengths`)
VALUES('MasterCard', '51,52,53,54,55', '222100-272099', '16');
INSERT INTO `netbankdb`.`issuingnetworks` (`Name`, `StartsWithNumbers`, `InRange`, `AllowedLengths`)
VALUES('Visa Electron', '4026,417500,4508,4844,4913,4917', NULL, '16');
INSERT INTO `netbankdb`.`issuingnetworks` (`Name`, `StartsWithNumbers`, `InRange`, `AllowedLengths`)
VALUES('Visa', '4', NULL,  '16,17,18,19');



