CREATE TABLE cpumetrics(id INTEGER PRIMARY KEY,value INT, time INT);

INSERT INTO cpumetrics(value, time) VALUES(50,1231231232);

UPDATE cpumetrics SET value = 42, time = 123 WHERE id=1;

SELECT id, value, time FROM cpumetrics WHERE value>50;

SELECT * FROM cpumetrics;

DELETE FROM cpumetrics WHERE value < 50;

DROP TABLE cpumetrics;

sqlfiddle.com