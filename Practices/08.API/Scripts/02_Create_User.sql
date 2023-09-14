/*DROP USER 'employeeuser'@'localhost' ;*/
CREATE USER 'employeeuser'@'localhost' IDENTIFIED BY 'Empl0y33Us3r*01';
GRANT ALL PRIVILEGES ON *.* TO 'employeeuser'@'localhost' WITH GRANT OPTION;
FLUSH PRIVILEGES;