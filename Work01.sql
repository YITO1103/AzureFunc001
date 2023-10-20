/*

--curl -s ifconfig.me
--Server=tcp:server-dev01.database.windows.net,1433;Initial Catalog=db-01;Persist Security Info=False;User ID=yuta.j.1103@gmail.com@server-dev01;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;
-- テーブルの作成
CREATE TABLE employees (
    id INT PRIMARY KEY NOT NULL,
    firstname NVARCHAR(50) NOT NULL,
    lastname NVARCHAR(50) NOT NULL,
    age INT
);

-- データの挿入
INSERT INTO employees (id, firstname, lastname, age)
VALUES 
(1, 'Taro', 'Yamada', 25),
(2, 'Hanako', 'Tanaka', 30),
(3, 'Yuki', 'Suzuki', 28);


*/




