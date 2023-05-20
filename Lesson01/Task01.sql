-- Task01
CREATE DATABASE IF NOT EXISTS homework01;
USE homework01;
DROP TABLE IF EXISTS phone;
CREATE TABLE phone
(
	id INT PRIMARY KEY AUTO_INCREMENT,
    product_name VARCHAR(20),
    manufacturer VARCHAR(20),
    product_count INT,
    price INT
);

INSERT phone(product_name, manufacturer, product_count, price)
VALUE
	('iPhone X', 'Apple', 3, 76000),
    ('iPhone 8', 'Apple', 2, 51000),
    ('Galaxy S9', 'Samsung', 2, 56000),
    ('Galaxy S8', 'Samsung', 1, 41000),
    ('P20 Pro', 'Huawei', 5, 36000);

    
-- Task02
SELECT product_name, manufacturer, price
FROM phone
WHERE product_count > 2;


-- Task03
SELECT product_name
FROM phone
WHERE manufacturer = 'Samsung';


-- Task04
SELECT product_name, manufacturer, product_count, price, product_count * price AS total
FROM phone
WHERE product_count * price BETWEEN 100000 AND 145000;


-- Task04.1
SELECT product_name, manufacturer, product_count, price
FROM phone
WHERE product_name LIKE 'iPhone%';


-- Task04.2
SELECT product_name, manufacturer, product_count, price
FROM phone
WHERE product_name LIKE 'Galaxy%';


-- Task04.3
SELECT product_name, manufacturer, product_count, price
FROM phone
WHERE product_name RLIKE '[0-9]';


-- Task04.4
SELECT product_name, manufacturer, product_count, price
FROM phone
WHERE product_name RLIKE '[8]';