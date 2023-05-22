/*DROP USER 'netbankuser'@'localhost' ;*/
CREATE USER 'netbankuser'@'localhost' IDENTIFIED BY 'N3tB4nkUs3r*01';
GRANT ALL PRIVILEGES ON *.* TO 'netbankuser'@'localhost' WITH GRANT OPTION;
FLUSH PRIVILEGES;