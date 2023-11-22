/*DROP USER 'creditbankuser'@'localhost' ;*/
CREATE USER 'creditbankuser'@'localhost' IDENTIFIED BY 'Cr3d1tB4nkUs3r';
GRANT ALL PRIVILEGES ON *.* TO 'creditbankuser'@'localhost' WITH GRANT OPTION;
FLUSH PRIVILEGES;