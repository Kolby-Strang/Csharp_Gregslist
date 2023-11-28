CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';


-- SECTION sandwich playground

CREATE TABLE IF NOT EXISTS sandwiches(
  id INT NOT NULL PRIMARY KEY AUTO_INCREMENT COMMENT 'this is the id of the sandwich, it is a primary key it is unique',
  name CHAR(255) NOT NULL COMMENT "this is the cute little name for the cute little sandwich",
  breadType ENUM('wheat', 'white', 'sourdough', 'rye', 'gluten free', 'lettuce wrap') NOT NULL,
  hasCheese BOOLEAN NOT NULL DEFAULT true
)  default charset utf8 COMMENT '';

INSERT INTO sandwiches (name) VALUES('roast beef and cheddar');
INSERT INTO sandwiches (name, breadType) VALUES('reuben', 'rye');
INSERT INTO sandwiches (name, breadType, hasCheese) VALUES("BLT", "sourdough", false);

SELECT * FROM sandwiches;

DROP TABLE sandwiches;

-- SECTION start of gregslist

CREATE TABLE IF NOT EXISTS cars(
  id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  make CHAR(255) NOT NULL,
  model CHAR(255) NOT NULL,
  year YEAR NOT NULL,
  price INT UNSIGNED NOT NULL,
  imgUrl VARCHAR(1000) NOT NULL,
  runs BOOLEAN NOT NULL DEFAULT true,
  mileage INT UNSIGNED NOT NULL DEFAULT 0
) default charset utf8 COMMENT '';

INSERT INTO 
cars (make, model, year, price, imgUrl, runs) 
VALUES("Mazda", "Miata", 2009, 1000, "https://images.unsplash.com/photo-1552615526-40e47a79f9d7?q=80&w=2176&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", true);
-- ("FORD", "TRUCK", 2000, 12000, "https://images.unsplash.com/photo-1559416523-140ddc3d238c?q=80&w=2051&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", false );

DROP TABLE cars;

SELECT make, model FROM cars;

SELECT * FROM cars;

SELECT * FROM cars WHERE year > 1997 AND make = "Mazda";

SELECT * FROM cars WHERE id = 5;

-- DELETE * FROM cars; note this deletes everything

DELETE FROM cars WHERE id = 1;

UPDATE cars 
SET 
make = "mazda",
model = "miata"; -- this updated every row in our table, probably not good


UPDATE cars 
SET 
make = "FORD",
model = "TRUCK"
WHERE id = 6
;