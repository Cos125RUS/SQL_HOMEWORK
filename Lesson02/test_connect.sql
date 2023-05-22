USE homework02;
drop table if exists test_connect;
CREATE TABLE test_connect
(
	id int primary key AUTO_INCREMENT,
    user_name varchar(20) not null UNIQUE,
    pass varchar(50)
);

INSERT test_connect(user_name, pass)
VALUES
	('vano22', 'sefsdfsd234'),
    ('papko777', 'dfgbds453fbgd'),
    ('user', 'pass'),
    ('Ludmila_Ivanovna', '123');